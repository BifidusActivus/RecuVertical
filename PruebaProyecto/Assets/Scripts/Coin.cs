using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float respawnTime;
    public static float time = 5;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        respawnTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        coin.transform.Rotate(0.0f, -3.0f, 0.0f);
        respawnTime -= Time.deltaTime;
        if(respawnTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider colPlayer)
    {
        if(colPlayer.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
