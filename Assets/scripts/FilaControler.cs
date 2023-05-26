using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilaControler : MonoBehaviour
{
    public GameObject[] pacinetWait;
    int[] emptyChair;
    bool positionVoid;
    int firstPositionVoid, counter, newpacients,positionLoc,ocupedPositions;
    // Start is called before the first frame update
    void Awake()
    {
        firstPositionVoid = 0;
        emptyChair= new int[pacinetWait.Length];
        for (int i = 0; i < emptyChair.Length; i++)
        {
            emptyChair[i] = 0;
            pacinetWait[i].SetActive(false);
        }
    }
    void Start()
    {
        StartCoroutine(LocPacinetsSpam(5));

    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void LocPacients()
    {
        if( Data_Controler.pacientNumeber>0)
        {
            positionLoc = FindVoidPosition();
            emptyChair[positionLoc] = 1;
            pacinetWait[positionLoc].SetActive(true);
        }
        

    }
    public int FindVoidPosition()
    {
        counter = 0;
        while(counter<emptyChair.Length)
        {
            if (emptyChair[counter] == 0)
            {
                firstPositionVoid= counter;
                counter = 1000;
            }
            counter++;
        }
        Debug.Log("primei posicao livre "+firstPositionVoid);
        return firstPositionVoid;
    }

    public bool NewPacient()
    {
        newpacients = 0;
        ocupedPositions= 0;
        for (int j = 0; j < emptyChair.Length; j++)
        {
            if(emptyChair[j] == 0)
            {
                newpacients++;

            }
            if (emptyChair[j] == 1)
            {
                ocupedPositions++;

            }
            
            
           
        }
        Debug.Log("vagas"+newpacients);
        Debug.Log("pacientes"+Data_Controler.pacientNumeber);
        Debug.Log("resultado "+ (newpacients-20 -Data_Controler.pacientNumeber));

        if (newpacients-ocupedPositions<= Data_Controler.pacientNumeber)
        {
            return true;
        }

       
        {
            return false;
        }
       


       
    }
    public void MovePacient()
    {
        if (emptyChair[Data_Controler.pacientSelect] == 1)
        {
            pacinetWait[Data_Controler.pacientSelect].SetActive(false);
            emptyChair[Data_Controler.pacientSelect] = 0;
            Data_Controler.pacientNumeber--;
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
