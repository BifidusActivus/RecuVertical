using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    public float speed;

    public Vector2 offset;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        offset.y += speed / 10000;
        offset.y %= 1;

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
