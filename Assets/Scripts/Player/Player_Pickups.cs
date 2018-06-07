using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Pickups : MonoBehaviour
{
    #region COUNTER

    int Coin;

    #endregion


    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Coin")
        {
            Destroy(Other.transform.parent.gameObject);
            Coin++;
            print("You have" + Coin + " Coins");
        }
    }

}
