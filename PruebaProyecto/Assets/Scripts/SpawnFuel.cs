using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFuel : MonoBehaviour
{
    
    public GameObject Fuel;
    public float respawnTime;
    public float time;

    Vector3 SpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnTime = time;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnPosition = new Vector3(Random.Range(-7.7f, 7.7f), transform.position.y, transform.position.z);
        respawnTime -= Time.deltaTime;
        if (respawnTime <= 0)
        {
            Instantiate(Fuel, SpawnPosition, transform.rotation);
            respawnTime = time;


        }
    }
}
