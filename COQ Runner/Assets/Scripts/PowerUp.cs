using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float velocity = 30; 
    public GameMaster currentTime;

    public GameMaster powerUpActive;

    public GameMaster powerUpEggActive;

    public GameMaster powerUpBullActive;

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
        powerUpEggActive = FindObjectOfType<GameMaster>();
        powerUpBullActive = FindObjectOfType<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = currentTime.currentVelocity.velocity;
        transform.position += new Vector3(0, 0, velocity) * Time.deltaTime;


        if (powerUpActive.powerUpActive == true || powerUpEggActive.powerUpEggActive == true || powerUpBullActive.powerUpBullActive == true)
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
            
                powerUpActive.powerUpActive = true;
              
                Destroy(gameObject);
            }
        }

        if (gameObject.CompareTag("Egg"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                powerUpEggActive.powerUpEggActive = true;
               
                Destroy(gameObject);
            }
        }

        if (gameObject.CompareTag("Bull"))
        {
            if (other.gameObject.CompareTag("Player"))
            {

                powerUpBullActive.powerUpBullActive = true;

                Destroy(gameObject);
            }
        }

    }
}
