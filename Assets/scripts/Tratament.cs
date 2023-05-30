using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tratament : MonoBehaviour
{
    public  GameObject pacinet,obj,obj2;

    // Start is called before the first frame update

   

    // Update is called once per frame
    void FixedUpdate()
    {
        Identifica();
        Cura();
    }
    void Cura()
    {
        if(Data_Controler.tratamentUse==Data_Controler.pacinetGotratament)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Data_Controler.pacientNumeber--;
            Data_Controler.money += 200;
            StartCoroutine(EndAnimation(pacinet));
            Data_Controler.tratamentUse = 0;
            Data_Controler.pacinetGotratament = -1;
          

        }
    }
    void Identifica()
    {
        if (Data_Controler.movepacient)
        {
            if (Data_Controler.pacinetGotratament == 1)
            {

                this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

            }
            if (Data_Controler.pacinetGotratament == 2)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;

            }
            if (Data_Controler.pacinetGotratament == 3)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;


            }
            if (Data_Controler.pacinetGotratament == 4)
            {
                this.GetComponent<SpriteRenderer>().color = Color.yellow;

            }

        }
    }

    public void Tratamento(int op)
    {
        if(op == 1 && Data_Controler.quantRespirator>=1 && Data_Controler.pacinetGotratament > 0) 
        {
            obj.SetActive(true);
            pacinet.GetComponent<Animator>().SetInteger("TratamentoS",op);
            StartCoroutine(EndAnimation(obj));
        }
        else if (op==3 && Data_Controler.quantXray>=1 && Data_Controler.pacinetGotratament > 0)
        {
            pacinet.GetComponent<Animator>().SetInteger("TratamentoS", op);
            obj2.SetActive(true);
            StartCoroutine(EndAnimation(obj2));
        }
       
        
       
    }
    public  IEnumerator EndAnimation(GameObject obj2)
    {
        yield return new WaitForSeconds(1.5f);
        obj2.SetActive(false);
        pacinet.GetComponent<Animator>().SetInteger("TratamentoS", 0);


    }
}
