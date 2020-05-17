using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner1 : MonoBehaviour
{
    public GameObject Fuel;
    public float respawnTime;
    public static float time = 2.5f;

    Vector3 SpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnTime = 2.5f;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnPosition = new Vector3(7.7f, transform.position.y, transform.position.z);
        respawnTime -= Time.deltaTime;
        if (respawnTime <= 0)
        {
            Instantiate(Fuel, SpawnPosition, transform.rotation);
            respawnTime = time;


        }
    }
}
