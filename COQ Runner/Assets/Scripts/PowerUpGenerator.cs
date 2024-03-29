using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public GameObject[] powerUps;
    public GameObject[] positions;

    public GameMaster powerUpActive;

    public GameMaster powerUpEggActive;

    public GameMaster powerUpBullActive;


    // Start is called before the first frame update
    void Start()
    {
        powerUpEggActive = FindObjectOfType<GameMaster>();
        powerUpActive = FindObjectOfType<GameMaster>();
        powerUpBullActive = FindObjectOfType<GameMaster>();

        GameObject selectedItem = powerUps[Random.Range(0, powerUps.Length)];
        GameObject pos = positions[Random.Range(0, positions.Length)];

        GameObject selectedPowerUp  = Instantiate(selectedItem, pos.transform.position, Quaternion.identity);

      

    }

    // Update is called once per frame
    void Update()
    {
        if (powerUpActive.powerUpActive == true || powerUpEggActive.powerUpEggActive == true || powerUpBullActive.powerUpBullActive == true)
        {
            Destroy(gameObject);
        }
    }
}
