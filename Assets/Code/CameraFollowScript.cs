using UnityEngine;

namespace Joel.SimpleCameraFollow
{
    public class CameraFollowScript : MonoBehaviour
    {


        #region Variables
        [Header("Camera Properties")]
        public Transform target;
        public float smoothTime = 0.5f;
        public bool lookAtTarget = true;
        Vector3 offset, wantedPosition;

        private Vector3 currentVelocity;
        #endregion


        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            CalculateOffset();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            HandleCamera();
        }

        #endregion

        #region Custom Methods
        void CalculateOffset()
        {
            offset = target.position + transform.position;
        }

        protected virtual void HandleCamera()
        {
            if (target)
            {
                wantedPosition = target.position + offset;
                wantedPosition.x = transform.position.x;
                transform.position = Vector3.SmoothDamp(transform.position, wantedPosition, ref currentVelocity, smoothTime);

                if (lookAtTarget)
                {
                    transform.LookAt(target);
                }
            }
        }
        #endregion
    }

}