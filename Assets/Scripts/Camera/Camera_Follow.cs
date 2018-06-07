using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{

    public Transform Target;

    public float SmoothSpeed = 0.125f;

    public Vector3 Offset;

    public bool CameraFollow = true;

	void Update ()
    {
        if (CameraFollow)
        {
            Vector3 DesiredPosition = Target.position + Offset;
            Vector3 SmoothPosition = Vector3.Lerp(transform.position, DesiredPosition, SmoothSpeed);

            transform.position = SmoothPosition;
            transform.LookAt(Target);
        }
    }
}
