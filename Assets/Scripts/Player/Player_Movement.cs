using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    #region VARIABLES

        #region CREATED

        public float MoveSpeed = 7;
        public float TurnSpeed = 5;
        public float JumpForce = 3;

        public float SmoothMoveTime = 0.1f;
        float SmoothMoveMagnitude;
        float SmoothMoveVelociyt;

        float ViewAngle;
        float Angle;

        bool CanJump;
        bool OnGround;

        #endregion

        #region UNITY

        public Rigidbody RigBody;
        public Collider Col;
        public LayerMask Mask;

        public Vector3 Velocity;

        #endregion

    #endregion

    void Start ()
    {
        RigBody = GetComponent<Rigidbody>();
        Col = GetComponent<Collider>();
	}

	void Update ()
    {
        #region Move

        float MoveHorizontal = Input.GetAxisRaw("Horizontal");
        float MoveVertical = Input.GetAxisRaw("Vertical");
        Vector3 MoveDirection = new Vector3(MoveHorizontal, 0, MoveVertical).normalized;

        float InputMagnitude = MoveDirection.magnitude;
        SmoothMoveMagnitude = Mathf.SmoothDamp(SmoothMoveMagnitude, InputMagnitude, ref SmoothMoveVelociyt, SmoothMoveTime);

            #region Rotate
            float TargetAngle = Mathf.Atan2(MoveDirection.x, MoveDirection.z) * Mathf.Rad2Deg;
            Angle = Mathf.LerpAngle(Angle, TargetAngle, Time.deltaTime * TurnSpeed * InputMagnitude);
            transform.eulerAngles = Vector3.up * Angle;
            #endregion

        Velocity = transform.forward * MoveSpeed * SmoothMoveMagnitude;

            #region Jump
            if (Input.GetKeyDown(KeyCode.Space) && (OnGround))
            {
                CanJump = true;
            }
            #endregion

        #endregion
    }

    private void FixedUpdate()
    {
        RigBody.MoveRotation(Quaternion.Euler(Vector3.up * Angle));
        RigBody.MovePosition(RigBody.position + Velocity * Time.deltaTime);

        if ((CanJump) && (OnGround))
        {
            OnGround = false;
            CanJump = false;
            RigBody.AddForce(0, JumpForce, 0, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider Other)
    {
        if(Other.tag == "Ground")
        {
            OnGround = true;
        }
    }
}
