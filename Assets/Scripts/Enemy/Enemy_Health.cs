using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public float Health = 100f;

    public void Removehealth(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void RemoveParenthealth(float amount)
    {
        Health -= amount;

        if (Health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}

