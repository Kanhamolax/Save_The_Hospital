using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacientSelector : MonoBehaviour
{
    public int pacinetSelected;
    public GameObject arrowSelect;
    void Start()
    {
        
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


            arrowSelect.transform.position = new Vector3(0, 1,0) + this.transform.position;
            Data_Controler.pacientSelect = pacinetSelected;



        }
    }

    void OnMouseExit()
    {
        this.transform.localScale = new Vector2(1, 1);

    }
}
