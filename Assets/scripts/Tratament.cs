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

    public void Tratamento(int cura)
    {
        Data_Controler.camChange = false;
      
        if (cura == 1 && Data_Controler.quantRespirator >= 1 && Data_Controler.pacinetGotratament > 0)
        {
            obj.SetActive(true);
            pacinet.GetComponent<Animator>().SetInteger("TratamentoS", cura);
            StartCoroutine(EndAnimation(obj));
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantRespirator--;
        }
        if (cura == 2 && Data_Controler.quantAntPOison >= 1 && Data_Controler.pacinetGotratament > 0)
        {
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantAntPOison--;
            StartCoroutine(WaitAnimation());
        }
        if (cura == 3 && Data_Controler.quantXray >= 1 && Data_Controler.pacinetGotratament > 0)
        {
            pacinet.GetComponent<Animator>().SetInteger("TratamentoS", cura);
            obj2.SetActive(true);
            StartCoroutine(EndAnimation(obj2));
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantXray--;
        }
        if (cura == 4 && Data_Controler.quantRemedy >= 1 && Data_Controler.pacinetGotratament > 0)
        {
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantRemedy--;
            StartCoroutine(WaitAnimation());
        }



    }
    public  IEnumerator EndAnimation(GameObject obj2)
    {
        yield return new WaitForSeconds(3);
        obj2.SetActive(false);
        pacinet.GetComponent<Animator>().SetInteger("TratamentoS", 0);
        Data_Controler.camChange = true;


    }
    public IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(3);
       
        Data_Controler.camChange = true;


    }
}
