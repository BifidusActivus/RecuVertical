using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float respawnTime;
    public static float time = 15;
    public GameObject featherParticles;


    // Start is called before the first frame update
    void Start()
    {
        respawnTime = time;
    }

    // Update is called once per frame
    void Update()
    {
      
        respawnTime -= Time.deltaTime;
        if (respawnTime <= 0)
        {
            
            Destroy(gameObject);
        }
       
    }

    private void OnTriggerEnter(Collider colPlayer)
    {
        if (colPlayer.tag == "Player")
        {
            Instantiate(featherParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    
    }
}
