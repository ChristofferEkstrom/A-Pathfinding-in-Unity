using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Spawner : MonoBehaviour
{

    public GameObject Coin;

    public Vector2 XPosition;
    public Vector2 YPosition;
    public Vector2 ZPosition;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(XPosition.x, XPosition.y), Random.Range(YPosition.x, YPosition.y), Random.Range(ZPosition.x, ZPosition.y));
            Vector3 randomSpawnRotation = Vector3.up * Random.Range(0, 360);

            GameObject newCoin = (GameObject)Instantiate(Coin, randomSpawnPosition, Quaternion.Euler(randomSpawnRotation));
            newCoin.transform.parent = transform;
        }
	}
}
