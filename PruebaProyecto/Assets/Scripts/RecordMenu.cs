using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordMenu : MonoBehaviour
{
    public float record;
    public Text recordText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        record = PlayerPrefs.GetFloat("record");
        if (record > 999)
        {
            recordText.text = "Record: " + (record / 1000) + "k";
        }
        else if (record > 999999)
        {
            recordText.text = "Record: " + (record / 1000000) + "M";
        }
        else
        {
            recordText.text = "Record: " + record;
        }
    }
}
