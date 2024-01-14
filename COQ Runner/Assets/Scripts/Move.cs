using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public PowerUp powerUpinmmunity;

    public GameMaster powerUpActive;
    public GameMaster powerUpEggActive;
    public GameMaster powerUpBullActive;



    public GameMaster currentTime;
    public GameMaster currentScore;
    public float velocity = 50;

    public GameObject player;

    bool coinMagnet;

    // Start is called before the first frame update
    void Start()
    {
        coinMagnet = false; 
        player = GameObject.FindWithTag("Player");

        powerUpinmmunity = FindObjectOfType<PowerUp>();

        powerUpEggActive = FindObjectOfType<GameMaster>();
        powerUpActive = FindObjectOfType<GameMaster>();
        powerUpBullActive = FindObjectOfType<GameMaster>();

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
            transform.position += new Vector3(0, 0, velocity * 2f) * Time.deltaTime;

            if (coinMagnet)
            {
                if (gameObject.CompareTag("Coin"))
                {
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 80);
                }
            }
        }
       

        if (gameObject.CompareTag("Coin"))
        {
            transform.Rotate(0, 0, 70 * Time.deltaTime);

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
                    if(powerUpEggActive.powerUpEggActive == false)
                    {
                        Time.timeScale = 0;
                    }
                    else
                    {

                        StartCoroutine(ExtraLife());
                       // Destroy(gameObject);
                    }
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
                if(powerUpBullActive.powerUpBullActive == false)
                {
                    currentScore.score++;
                    Debug.Log(currentScore.score);
                    Destroy(gameObject);
                }
                else
                {
                    currentScore.score = currentScore.score + 10;
                    Debug.Log(currentScore.score);
                    Destroy(gameObject);
                }
              
            }
        }

    }

    IEnumerator ExtraLife()
    {

        yield return new WaitForSeconds(3);

        powerUpEggActive.powerUpEggActive = false;
    }
}
