using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public Move currentVelocity;

    public float time;

    public bool timerOn = false;

    public bool powerUpActive = false;

    public bool powerUpEggActive = false;

    public bool powerUpBullActive = false;

    public TextMeshProUGUI scoreVa;

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
        scoreVa.text = "0";
        score = 0;
        powerUpLife = 0;

        currentVelocity = FindObjectOfType<Move>();

      InvokeRepeating("IncreaseSpeed", 5f, 20f); 

        timerOn = true;
        //unpause when player moves key 
    }

    // Update is called once per frame
    void Update()
    {
        scoreVa.text = score.ToString();

        if (powerUpActive)
        {
            powerUpLife += Time.deltaTime;

            if(powerUpLife >= 6)
            {
                powerUpActive = false;
                powerUpLife = 0;
             
            }
          
        }

        if (powerUpBullActive)
        {
            powerUpLife += Time.deltaTime;
            Debug.Log("bull  activado");

            if (powerUpLife >= 10)
            {
                powerUpBullActive = false;
                powerUpLife = 0;

            }

        }
       

        if (timerOn)
        {
            time += Time.deltaTime;
        }

        Debug.Log("velocity: " + currentVelocity.velocity);
    }
}
