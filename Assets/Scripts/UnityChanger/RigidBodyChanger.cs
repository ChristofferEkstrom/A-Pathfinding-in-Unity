using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyChanger : MonoBehaviour {

    public Rigidbody RigBody;

    void Start ()
    {
        RigBody = GetComponent<Rigidbody>();
        RigBody.AddForce(Random.Range(-1.0f, 1.0f), Random.Range(0.75f,1.5f), Random.Range(-1.0f, 1.0f), ForceMode.Impulse);
    }
}
