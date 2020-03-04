using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Joel.SwerveTurnMovement
{
    public class SewerveTurnMovement : MonoBehaviour
    {
        #region Variables

        [Header("Input Properties")]
        public float forwardSpeed = 5f;
        public float turnSpeed = 200f;
        public  float minRotation = -45;
        public  float maxRotation = 45;
        public float damp = 5f;
        float dragDistance;
        public VariableJoystick vJoy;
      public  float dragAmount;
        Vector3 firstTouch, currentTouch;
        public Vector3   totalTouch;
        Rigidbody rb;
        #endregion


        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            dragDistance = Screen.width * 0.5f / 100;
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void Update()
        {
            GetInput();
            Move();
            ClampRotation();
        }

        private void FixedUpdate()
        {
           rb.MovePosition(transform.position + transform.forward * forwardSpeed * Time.deltaTime);
         //  rb.velocity = transform.forward*forwardSpeed*Time.deltaTime;
        }
        #endregion


        #region Custom Methods
        protected virtual void Move()
        {
            //transform.position += transform.forward * forwardSpeed * Time.deltaTime;

            var target = new Vector3(0f, vJoy.Horizontal * turnSpeed * Time.deltaTime, 0f);
             var rotate = Quaternion.LookRotation(target - transform.position);
           transform.rotation  = Quaternion.Slerp(transform.rotation,Quaternion.Euler( target + transform.eulerAngles), Time.deltaTime * damp);
         //transform.Rotate(new Vector3(0f, dragAmount * turnSpeed * Time.deltaTime, 0f));
        }

        protected virtual void GetInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstTouch = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                currentTouch = Input.mousePosition;
                totalTouch = currentTouch - firstTouch;
                dragAmount = Mathf.InverseLerp(-dragDistance, dragDistance, totalTouch.x);/// (Screen.width );
                dragAmount = Mathf.Lerp(-1f, 1f, dragAmount);
                firstTouch = Input.mousePosition ;
            }
            if (Input.GetMouseButtonUp(0))
            {
                firstTouch = Vector3.zero;
                currentTouch = Vector3.zero;
                totalTouch = Vector3.zero;
                dragAmount = 0f;
            }
        }
        void ClampRotation()
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            currentRotation.y = ClampAngle(currentRotation.y, minRotation, maxRotation);
            transform.rotation = Quaternion.Euler(currentRotation);
        }
        float ClampAngle(float angle, float from, float to)
        {
            // accepts e.g. -80, 80
            if (angle < 0f) angle = 360 + angle;
            if (angle > 180f) return Mathf.Max(angle, 360 + from);
            return Mathf.Min(angle, to);
        }
        #endregion

    }
}
