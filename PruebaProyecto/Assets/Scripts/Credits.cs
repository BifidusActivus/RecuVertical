using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Credits : MonoBehaviour
{
    public Text text;
    public Canvas returnButton;
    public bool check;
    public static float time = 5;
    public float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        respawnTime = time;
        returnButton.enabled = false;
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        respawnTime -= Time.deltaTime;
        if(!check)
        {
            text.rectTransform.transform.position -= new Vector3(0, 2 + Time.deltaTime, 0);
        }
        else
        {  
            returnButton.enabled = true;
        }
        if (respawnTime <= 0)
        {
            check = true; 
        }
       
    }
}
