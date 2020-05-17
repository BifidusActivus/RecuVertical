using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherParticle : MonoBehaviour
{
   
    public float respawnTime;
    public static float time = 1f;

    

    // Start is called before the first frame update
    void Start()
    {
        respawnTime = 1f;

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
}
