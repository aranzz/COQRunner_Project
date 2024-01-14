using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SectionTrigger : MonoBehaviour
{
    private Transform Player;
  //  public SwipeControls Controls;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    public GameObject roadSection;

    private void Start()
    {
        Player = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trigger"))
        {
            GameObject g = Instantiate(roadSection, new Vector3(-0.9f, 0,-200f), Quaternion.identity); 
            g.transform.Rotate(0f, 90f, 0f);
        }   
    }

    private void Update()
    {
        /*
        if (Lane3 == true && Player.position.x < 1.1f)
        {
            Player.position += new Vector3(10.5f, 0, 0 * Time.deltaTime);
        }
        else if (Lane1 == true && Player.position.x > -1.1f)
        {
            Player.position += new Vector3(-10.5f, 0, 0 * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.x <= -0.1f)
        {
            Player.position += new Vector3(10.5f, 0, 0 * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.x >= 0.1f)
        {
            Player.position += new Vector3(-10.5f, 0, 0 * Time.deltaTime);
        }

        ///

        if (Controls.swiperight == true && Lane3 == false && Lane1 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        else if (Controls.swipeleft == true && Lane2 == true && Player.position.x <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        else if (Controls.swiperight == true && Lane2 == true && Player.position.x >= -0.2f)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        else if (Controls.swipeleft == true && Lane1 == false && Lane3 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }

        */
        ///Player.transform.Rotate(0f, 90f, 0f);

    }

}
