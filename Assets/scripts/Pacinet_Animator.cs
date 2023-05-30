using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Pacinet_Animator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject entrada1, entrada2, pacient;
    void Start()
    {
        entrada1 = GameObject.FindGameObjectWithTag("Rote1");
        entrada2 = GameObject.FindGameObjectWithTag("Rote2");

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("pacient").transform.position.x <= entrada1.transform.position.x && Data_Controler.route==2)
        {
            gameObject.GetComponent<Animator>().SetBool("up", true);
        }
        if (GameObject.FindGameObjectWithTag("pacient").transform.position.x <= entrada2.transform.position.x+1 && Data_Controler.route==1)
        {
            gameObject.GetComponent<Animator>().SetBool("up", true);
        }

    }
    
}
