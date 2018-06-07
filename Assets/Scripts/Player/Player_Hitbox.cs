using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hitbox : MonoBehaviour
{

    public GameObject Hitbox;
    public float HitTime = 0.5f;

    public static int KillCount;
    public float Damage = 25f;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Hitbox.SetActive(true);
            StartCoroutine(HitDetect());
        }
    }

    IEnumerator HitDetect()
    {
        yield return new WaitForSeconds(HitTime);
        Hitbox.SetActive(false);
    }

    void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.tag == "Enemy")
        {
            triggerCollider.GetComponent<Enemy_Health>().RemoveParenthealth(Damage);
            print("HIT" + triggerCollider.name);
            Hitbox.SetActive(false);
        }
    }
}
