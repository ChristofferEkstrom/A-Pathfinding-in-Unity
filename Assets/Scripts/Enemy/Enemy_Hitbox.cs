using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Hitbox : MonoBehaviour {

    public float Damage = 1f;
    public Collider Col;

    void Start()
    {
        Col = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider PlayerCollider)
    {
        if (PlayerCollider.tag == "Player")
        {
            PlayerCollider.GetComponent<Player_Health>().DealDamage(Damage);
            print("Collision");
        }
    }
}