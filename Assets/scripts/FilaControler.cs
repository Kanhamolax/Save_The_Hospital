using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaControler : MonoBehaviour
{
    public GameObject[] pacinetWait;
    int[] emptyChair;
    // Start is called before the first frame update
    void Awake()
    {
        emptyChair= new int[pacinetWait.Length];
        for (int i = 0; i < emptyChair.Length; i++)
        {
            emptyChair[i] = 0;
            pacinetWait[i].SetActive(false);
        }
    }
    void Start()
    {
        StartCoroutine(LocPacinetsSpam(1));

    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void LocPacients()
    {
        if(Data_Controler.pacientNumeber>0)
        {
            emptyChair[Data_Controler.pacientNumeber - 1] = 1;
            pacinetWait[Data_Controler.pacientNumeber - 1].SetActive(true);
        }
        

    }

    public IEnumerator LocPacinetsSpam(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            LocPacients();



        }
    }
}
