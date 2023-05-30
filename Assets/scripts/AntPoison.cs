using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntPoison : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    public void TratamentoAntPOison()
    {
        if(Data_Controler.quantAntPOison>=1 && Data_Controler.pacinetGotratament > 0)
        {
            obj.SetActive(true);





            StartCoroutine(EndAnimation(obj));

        }
       
           
    }
    public IEnumerator EndAnimation(GameObject obj2)
    {
        yield return new WaitForSeconds(2.2f);
        obj2.SetActive(false);
       


    }
}
