using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WriteJson : MonoBehaviour
{
    public PlayerRecord player = new PlayerRecord(0, "default", 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
    public class PlayerRecord
    {
        public int id;
        public string name;
        public int record;

        public PlayerRecord(int id, string name, int record)
        {
            this.id = id;
            this.name = name;
            this.record = record;
        }
    }


