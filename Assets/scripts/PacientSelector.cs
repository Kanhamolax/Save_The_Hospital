using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacientSelector : MonoBehaviour
{
    public int pacinetSelected,pacientIllnes;
    public GameObject arrowSelect;
    void Start()
    {
        pacientIllnes = -1;
       
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnMouseOver()
    {
        this.transform.localScale = new Vector2(1.09f, 1.09f);



        if (Input.GetMouseButtonUp(0))
        {
          
            if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.blue)
            {
                Data_Controler.pacinetGotratament = 1;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.green)
            {
                Data_Controler.pacinetGotratament = 2;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
            {
                Data_Controler.pacinetGotratament = 3;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.yellow)
            {
                Data_Controler.pacinetGotratament = 4;
            }

            arrowSelect.transform.position = new Vector3(0, 1,0) + this.transform.position;
            Data_Controler.pacientSelect = pacinetSelected;



        }
    }

    void OnMouseExit()
    {
        this.transform.localScale = new Vector2(1, 1);

    }
  
}
