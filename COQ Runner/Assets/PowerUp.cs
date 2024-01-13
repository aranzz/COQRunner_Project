using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float velocity = 30; 
    public GameMaster currentTime;

    public GameMaster powerUpActive;


    public Move currentVelocity;
    public bool inmmunity;

    public bool boost;
    // Start is called before the first frame update
    void Start()
    {
        boost = false;
        inmmunity = false;
        currentTime = FindObjectOfType<GameMaster>();
        currentVelocity = FindObjectOfType<Move>();

        powerUpActive = FindObjectOfType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = currentTime.currentVelocity.velocity;
        transform.position += new Vector3(0, 0, velocity) * Time.deltaTime;


        if (powerUpActive.powerUpActive == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }



        if (gameObject.CompareTag("Crown"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                inmmunity = true;
              //boost = true;
                powerUpActive.powerUpActive = true;
              //currentVelocity.velocity = 150;
              //currentVMultiplier.velocityMultiplier = 20;  
                Destroy(gameObject);
            }
        }

    }
}
