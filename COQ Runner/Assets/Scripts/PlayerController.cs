using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject[] positions;

    public GameObject player;

    int currentPos;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = 1;

        player.transform.position = Vector3.MoveTowards(player.transform.position, positions[currentPos].transform.position, Time.deltaTime * 100);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentPos == 0)
            {
                player.transform.position = new Vector3(positions[0].transform.position.x, positions[0].transform.position.y, positions[0].transform.position.z);
            }
            else
            {
                currentPos--;
                player.transform.position = new Vector3(positions[currentPos].transform.position.x, positions[currentPos].transform.position.y, positions[currentPos].transform.position.z);
            }
           
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentPos == 2)
            {
                player.transform.position = new Vector3(positions[2].transform.position.x, positions[2].transform.position.y, positions[2].transform.position.z);
            }
            else
            {
                currentPos++;
                player.transform.position = new Vector3(positions[currentPos].transform.position.x, positions[currentPos].transform.position.y, positions[currentPos].transform.position.z);
            }
        }
    }
}
