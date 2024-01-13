using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] positions;

    // Start is called before the first frame update
    void Start()
    {
        GameObject selectedItem = obstacles[Random.Range(0, obstacles.Length)];

        if(selectedItem.CompareTag("Coin"))
        {
            GameObject pos = positions[Random.Range(0, positions.Length)];

            GameObject selectedObstacle = Instantiate(selectedItem, pos.transform.position, Quaternion.identity);

            selectedObstacle.transform.Rotate(90f, 0f, 0f);


        }

        if (selectedItem.CompareTag("Obstacle"))
        {
            GameObject pos = positions[Random.Range(0, positions.Length)];

            GameObject selectedObstacle = Instantiate(selectedItem, pos.transform.position, Quaternion.identity);
        }
  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
