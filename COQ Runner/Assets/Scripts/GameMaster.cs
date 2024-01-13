using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Move currentVelocity;

    public PowerUp powerUpinmmunity;

    public PowerUp powerUpBoost;

    public float time;

    public bool timerOn = false;

    public bool powerUpActive = false;

    public int score;

    public float velocityMultiplier = 10; 

    public float powerUpLife = 0;

    void IncreaseSpeed()
    {
     currentVelocity.velocity = currentVelocity.velocity + velocityMultiplier;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        powerUpLife = 0;

        powerUpinmmunity = FindObjectOfType<PowerUp>();
        powerUpBoost = FindObjectOfType<PowerUp>();
        currentVelocity = FindObjectOfType<Move>();

      InvokeRepeating("IncreaseSpeed", 5f, 20f); 

        timerOn = true;
        //unpause when player moves key 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentVelocity.velocity >= 80)
        {
            currentVelocity.velocity = 80;
        }

        if (powerUpActive)
        {
            powerUpLife += Time.deltaTime;

            if(powerUpLife >= 6)
            {
                powerUpActive = false;
                powerUpLife = 0;
             
            }
          
        }


        if(timerOn)
        {
            time += Time.deltaTime;
        }

        Debug.Log("velocity: " + currentVelocity.velocity);
    }
}
