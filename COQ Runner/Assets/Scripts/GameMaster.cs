using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public GameObject runningSmall;

    public GameObject running;
    public ParticleSystem dirt;

    public bool dirtLife;

    public Move currentVelocity;

    public float time;

    public bool timerOn = false;

    public bool powerUpActive = false;

    public bool powerUpEggActive = false;

    public bool powerUpBullActive = false;

    public Text scoreVa;

    public Text powerUpVa;


    public int score;

    public float velocityMultiplier = 10; 

    public float powerUpLife = 0;

    void IncreaseSpeed()
    {
         currentVelocity.velocity = currentVelocity.velocity + velocityMultiplier;

        if (currentVelocity.velocity >= 75)
        {
            currentVelocity.velocity = 75;
        }

    }

   
    // Start is called before the first frame update
    void Start()
    {
        runningSmall.SetActive(false);
        running.SetActive(false);
        scoreVa.text = "0";
        score = 0;
        powerUpLife = 0;

        currentVelocity = FindObjectOfType<Move>();

      InvokeRepeating("IncreaseSpeed", 5f, 15); 

        timerOn = true;
        //unpause when player moves key 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentVelocity.velocity >= 75)
        {
            runningSmall.SetActive(true);
        }
        else
        {
            runningSmall.SetActive(false);

        }


        scoreVa.text = score.ToString();

        if (powerUpActive)
        {
            running.SetActive(true);

            powerUpVa.text = "Crown Active";

            powerUpLife += Time.deltaTime;

            if(powerUpLife >= 6)
            {
                powerUpActive = false;
                powerUpLife = 0;
                running.SetActive(false);


            }

        }
        
        if (powerUpBullActive)
        {
            powerUpLife += Time.deltaTime;
            powerUpVa.text = "Bull Active";

            if (powerUpLife >= 10)
            {
                powerUpBullActive = false;
                powerUpLife = 0;

            }

        }
     

        if (powerUpEggActive)
        {
            powerUpVa.text = "Egg Active";

        }
       
        if(powerUpActive == false && powerUpEggActive == false && powerUpBullActive == false)
        {
            powerUpVa.text = " ";
        }


        if (timerOn)
        {
            time += Time.deltaTime;
        }

        Debug.Log("velocity: " + currentVelocity.velocity);


        if(dirtLife == false)
        {
            dirt.Stop();
        }

    }
}
