using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour
{
    public float time;
    public float timer;
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 circlePos1;
    public Vector3 circlePos2;
    public Vector3 circlePos3;
    public Vector3 circlePos4;
    public int circlePos;
    public int randomPatron;
    public bool isGoingRight;

    // Start is called before the first frame update
    void Start()
    {
        circlePos = 1;
        isGoingRight = false;
        randomPatron = Random.Range(1, 3);
        startPos = transform.position;
        if (gameObject.layer == 9)
        {
            circlePos1 = new Vector3(transform.position.x -6, transform.position.y, transform.position.z);;
            circlePos2 = new Vector3(transform.position.x -9, transform.position.y + 1.5f, transform.position.z);;
            circlePos3 = new Vector3(transform.position.x -6, transform.position.y + 3, transform.position.z);;
            circlePos4 = new Vector3(transform.position.x - 3, transform.position.y + 1.5f, transform.position.z); ;
            endPos = new Vector3(transform.position.x -9, transform.position.y + 5f, transform.position.z);
        }
        else if (gameObject.layer == 10)
        {
            circlePos1 = new Vector3(transform.position.x + 6, transform.position.y, transform.position.z); ;
            circlePos2 = new Vector3(transform.position.x + 9, transform.position.y + 1.5f, transform.position.z); ;
            circlePos3 = new Vector3(transform.position.x + 6, transform.position.y + 3, transform.position.z); ;
            circlePos4 = new Vector3(transform.position.x + 3, transform.position.y + 1.5f, transform.position.z); ;
            endPos = new Vector3(transform.position.x + 9, transform.position.y + 5f, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (randomPatron)
        {
            case 1:
                LateralMov();
                break;
            case 2:
                CircleMov();
                break;
            case 3:
                if (gameObject.layer == 9)
                {
                    transform.position += Vector3.left * 3 * Time.deltaTime;
                }
                else
                {
                    transform.position += Vector3.right * 3 * Time.deltaTime;
                }
                break;
        }
    }

    void LateralMov()
    {
        if (!isGoingRight) {
            transform.position = Vector3.MoveTowards(transform.position, endPos, 4 * Time.deltaTime);
            if (transform.position == endPos)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
                isGoingRight = true;
            }
        }
        if (isGoingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, 4 * Time.deltaTime);
            if (transform.position == startPos)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                isGoingRight = false;
            }
        }
    }
  
    void CircleMov()
    {
        if (circlePos == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, circlePos1, 4 * Time.deltaTime);
            if (transform.position == circlePos1)
            {
                circlePos = 2;
            }
        }
        else if (circlePos == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, circlePos2, 4 * Time.deltaTime);
            if (transform.position == circlePos2)
            {
                transform.rotation = Quaternion.Euler(0, -180, 0);
                circlePos = 3;
            }
        }
        else if (circlePos == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, circlePos3, 4 * Time.deltaTime);
            if (transform.position == circlePos3)
            {
                circlePos = 4;
            }
        }
        else if (circlePos == 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, circlePos4, 4 * Time.deltaTime);
            if (transform.position == circlePos4)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                circlePos = 1;
            }
        }
    }
}
