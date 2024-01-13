using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Move currentVelocity;

    public float time;

    public bool timerOn = false;

    public bool powerUpActive = false;

    public bool powerUpEggActive = false;

    public int score;

    public float velocityMultiplier = 10; 

    public float powerUpLife = 0;

    void IncreaseSpeed()
    {
         currentVelocity.velocity = currentVelocity.velocity + velocityMultiplier;

        if (currentVelocity.velocity >= 60)
        {
            currentVelocity.velocity = 60;
        }

    }

   
    // Start is called before the first frame update
    void Start()
    {
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
      

        if (powerUpActive)
        {
            powerUpLife += Time.deltaTime;

            if(powerUpLife >= 6)
            {
                powerUpActive = false;
                powerUpLife = 0;
             
            }
          
        }

        if (powerUpEggActive)
        {

            Debug.Log("huevo activado");
            
        }
        else
        {
            Debug.Log("huevo NO activado");

        }

        if (timerOn)
        {
            time += Time.deltaTime;
        }

        Debug.Log("velocity: " + currentVelocity.velocity);
    }
}
