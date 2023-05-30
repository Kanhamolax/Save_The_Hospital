using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remedy : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    public void TratamentoRemedy()
    {

        if(Data_Controler.quantRemedy>=1&& Data_Controler.pacinetGotratament>0)
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
