using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Coin")
        {

            player.finished = true;
        }
    }

}
