using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static float speedUp = 2800.0f;
    public static float superSpeedUp = 7000.0f;
    public static float speedDown = -400f;
    public static float speedRightAndLeft = 50;
    public Rigidbody rb;
    public GameObject rocked;
    public bool finished;
    public bool check;
    public float respawnTime;
    public static float time = 2;
    public GameObject player;
    public float maxPositionLeft;
    public float maxPositionRight;
    public float distanceTraveled;
    public int maxDistanceTraveled;
    public Text distance;
    public Text record;
    public Canvas PlayAgain;
    public ParticleSystem particleRocked;
    public AudioSource audioMusicLoop;
    public BirdSound soundB;
    public Canvas onBoarding;
    public Button onBoardingB;
    public float playerPrefRecord;
    public GameObject recordObj;
    public Image imageCooldownBoost;
    public float cooldownB = 10;
    public float timerB;
    public Color cooldownC;
    public Color originalC;
    public bool boostOn;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 0;
        respawnTime = time;
        check = false;
        finished = false;
        rb.AddForce(transform.up * speedUp);
        maxPositionLeft = -8.8f;
        maxPositionRight = 8.8f;
        distanceTraveled = 0;
        maxDistanceTraveled = 0;
        onBoarding.enabled = true;
        onBoardingB.interactable = true;
        PlayAgain.enabled = false;
        audioMusicLoop = GetComponent<AudioSource>();
        audioMusicLoop.Stop();
        timerB = cooldownB;
        boostOn = true;
        PlayerPrefs.SetFloat("record", 0);
        
        if (playerPrefRecord != 0) {
            playerPrefRecord = PlayerPrefs.GetFloat("record");
        }
        else
        {
            playerPrefRecord = PlayerPrefs.GetFloat("record", 0);
        }
    }

    private void Update()
    {
        Boost();
        if (playerPrefRecord != 0)
        {
            recordObj.SetActive(true);
            recordObj.transform.position = new Vector3(0, playerPrefRecord, -2);
        }
        else
        {
            recordObj.SetActive(false);
        }
        if (maxDistanceTraveled > 999)
        {
            distance.text = "" + (maxDistanceTraveled / 1000) + "k";
        }
        else if(maxDistanceTraveled > 999999)
        {
            distance.text = "" + (maxDistanceTraveled / 1000000) + "M";
        }
        else
        {
            distance.text = "" + maxDistanceTraveled;
        }
        if (maxDistanceTraveled > playerPrefRecord)
        {
            record.text = "Record: " + maxDistanceTraveled;
           
        }
        else
        {
            record.text = "Record: " + playerPrefRecord;
       
        }
        
        rocked.transform.Rotate(0.0f, 2.0f, 0.0f);
    
        CalculateMaxDistanceTraveled();

        

        if (!check && distanceTraveled < maxDistanceTraveled) {
            respawnTime -= Time.deltaTime;
            if (respawnTime < 0)
            {
                finished = true;
            } 
        }
        else
        {
            respawnTime = time;
            check = false;
        }

        
            
        
        if (!finished)
        {
            Movement();
           
        }
        else
        {
            Time.timeScale = 0;
             audioMusicLoop.Stop();
            PlayAgain.enabled = true;
        }
    }

   

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Coin")
        {
            check = true;
            rb.velocity = rb.velocity.normalized;
            rb.AddForce(transform.up * speedUp);
            particleRocked.Play();
        }
        else if (col.tag == "SuperCoin")
        {
            check = true;
            rb.AddForce(transform.up * superSpeedUp);
            particleRocked.Play();
        }
        else if (col.tag == "Bird")
        {
            check = true;
            rb.AddForce(transform.up * speedDown);
            soundB.check = true;
        }
        else
        {
            check = false;
        }
    }

 
    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(transform.right * -speedRightAndLeft);
            if (player.transform.position.x < maxPositionLeft)
            {
                player.transform.position = new Vector3(maxPositionRight, player.transform.position.y, player.transform.position.z);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * speedRightAndLeft);
            if (player.transform.position.x > maxPositionRight)
            {
                player.transform.position = new Vector3 (maxPositionLeft, player.transform.position.y, player.transform.position.z);
            }
        }
    }

    void CalculateMaxDistanceTraveled()
    {
        distanceTraveled = transform.position.y;
        if (distanceTraveled > maxDistanceTraveled)
        {
            maxDistanceTraveled = (int)distanceTraveled;
        }
    }


    public void ReplayScene()
    {
        if (playerPrefRecord <= maxDistanceTraveled)
        {
            PlayerPrefs.SetFloat("record", maxDistanceTraveled);
        }
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        if (playerPrefRecord <= maxDistanceTraveled)
        {
            PlayerPrefs.SetFloat("record", maxDistanceTraveled);
        }
        SceneManager.LoadScene("Menu");  
    }
    public void StartGame()
    {
            onBoarding.enabled = false;
            onBoardingB.interactable = false;
            audioMusicLoop.Play();
            Time.timeScale = 1;
    }

    public void Boost()
    {
        if (Input.GetKeyDown(KeyCode.Space) && boostOn)
        {
            check = true;
            rb.velocity = Vector3.zero;
            rb.AddForce(transform.up * superSpeedUp);
            particleRocked.Play();
            boostOn = false;
        }
        else
        {
            cooldownB -= Time.deltaTime;
        }
        if (boostOn)
        {
            imageCooldownBoost.color = originalC;
        }
        else
        {
            imageCooldownBoost.color = cooldownC;
        }
        if (cooldownB <= 0)
        {
            cooldownB = timerB;
            boostOn = true;
        }
    }
    
}
