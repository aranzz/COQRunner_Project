using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public PowerUp powerUpinmmunity;

    public GameMaster powerUpActive;

    public GameMaster currentTime;
    public GameMaster currentScore;
    public float velocity = 30;

    public GameObject player;

    bool coinMagnet;

    // Start is called before the first frame update
    void Start()
    {
        coinMagnet = false; 
        player = GameObject.FindWithTag("Player");

        powerUpinmmunity = FindObjectOfType<PowerUp>();
        powerUpActive = FindObjectOfType<GameMaster>();

        currentTime = FindObjectOfType<GameMaster>();
        currentScore = FindObjectOfType<GameMaster>();

    }

    // Update is called once per frame
    void Update()
    {
        

       

        if (powerUpActive.powerUpActive == false) 
        {
            velocity = currentTime.currentVelocity.velocity;
            transform.position += new Vector3(0, 0, velocity) * Time.deltaTime;
        }
        else
        {
            velocity = currentTime.currentVelocity.velocity;
            transform.position += new Vector3(0, 0, velocity * 2) * Time.deltaTime;

            if (coinMagnet)
            {
                if (gameObject.CompareTag("Coin"))
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 60);
                }
            }
        }
       

        if (gameObject.CompareTag("Coin"))
        {
            transform.Rotate(0, 0, 50 * Time.deltaTime);

        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }


        if (powerUpActive.powerUpActive == false)
        {
            if (gameObject.CompareTag("Obstacle"))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    Time.timeScale = 0; 
                }
            }

        }

        


        if (gameObject.CompareTag("Coin"))
        {
            if (other.gameObject.CompareTag("CoinDetector"))
            {
                coinMagnet = true;

            }


                if (other.gameObject.CompareTag("Player"))
            {
                currentScore.score++;
                Debug.Log(currentScore.score);
                Destroy(gameObject);
            }
        }

    }
}
