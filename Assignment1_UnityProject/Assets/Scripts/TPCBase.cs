using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    // The base class for all third-person camera controllers
    public abstract class TPCBase
    {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }


        private void ObstacleCeiling()
        {
            RaycastHit hit;
            Vector3 direction = (mPlayerTransform.position - mCameraTransform.position).normalized;

            if (Physics.Raycast(mCameraTransform.position, direction, out hit, 2.0f))
            {
                // Calculate the new camera position to show the player's height
                float targetHeight = mPlayerTransform.position.y + CameraConstants.CameraPositionOffset.y; 

                if (hit.point.y > targetHeight)
                {
                    float newHeight = Mathf.Lerp(mCameraTransform.position.y, targetHeight, Time.deltaTime * 5.0f); 

                    // Set the new camera position with the updated height
                    Vector3 newPosition = new Vector3(hit.point.x, newHeight, hit.point.z);
                    mCameraTransform.position = newPosition;
                }
            }


        }

        private void ObstacleWall()
        {
            RaycastHit hit;
            Vector3 direction = (mPlayerTransform.position - mCameraTransform.position).normalized;
            if (Physics.Raycast(mCameraTransform.position, direction, out hit, 2.0f))
            {
                // Calculate the new camera position to show the player's height
                float targetHeight = mPlayerTransform.position.y + CameraConstants.CameraPositionOffset.y; 
                
                // Lerp the current camera height to the target height
                float newHeight = Mathf.Lerp(mCameraTransform.position.y, targetHeight, Time.deltaTime * 5.0f);

                Vector3 newPosition = new Vector3(hit.point.x, newHeight, hit.point.z);
                mCameraTransform.position = newPosition;

                
            }
        }

        public void RepositionCamera()
        {
            ObstacleWall();
            ObstacleCeiling();
        }


        


        public abstract void Update();
    }
}
