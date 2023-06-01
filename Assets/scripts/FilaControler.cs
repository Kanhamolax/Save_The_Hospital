using DG.Tweening;
using System.Collections;

using UnityEngine;

public class FilaControler : MonoBehaviour
{
    public GameObject[] pacinetWait;
    public GameObject pacinext;
    int[] emptyChair;
    bool positionVoid;
    int firstPositionVoid, counter, newpacients,positionLoc,ocupedPositions;
    // Start is called before the first frame update
    void Awake()
    {
        Data_Controler.movepacient = false;
        Data_Controler.pacinetGotratament = -1;
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
            if (Data_Controler.illness == 0)
            {
                pacinetWait[positionLoc].GetComponent<SpriteRenderer>().color = Color.blue;
               // StartCoroutine(PacientLost(pacinetWait[positionLoc],57,positionLoc));
            }
            else if (Data_Controler.illness == 1)
            {
                pacinetWait[positionLoc].GetComponent<SpriteRenderer>().color = Color.green;
               // StartCoroutine(PacientLost(pacinetWait[positionLoc], 37,positionLoc));
            }
            else if (Data_Controler.illness == 2)
            {
                pacinetWait[positionLoc].GetComponent<SpriteRenderer>().color = Color.red;
                //StartCoroutine(PacientLost(pacinetWait[positionLoc], 57, positionLoc));
            }
            else if (Data_Controler.illness == 3)
            {
                pacinetWait[positionLoc].GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
        

    }
    public int FindVoidPosition()
    {
        counter = 0;
        positionVoid = false;
        while(counter<emptyChair.Length)
        {
            if (emptyChair[counter] == 0)
            {
               
                    firstPositionVoid = counter;
                
                        counter = 1000;
                      
                      
                  
                   
            }
                positionVoid= true;
                
          
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
            Data_Controler.movepacient = true;
            pacinetWait[Data_Controler.pacientSelect].SetActive(false);
            emptyChair[Data_Controler.pacientSelect] = 0;
           
            pacinext.SetActive(true);
           
          
            StartCoroutine(RealocPemition());
        }

    }
    public IEnumerator RealocPemition()
    {
        yield return new WaitForSeconds(0.5f);
        Data_Controler.movepacient = false;

    }
    public IEnumerator PacientLost(GameObject pacientlost, int time2, int possition)
    {
        yield return new WaitForSeconds(time2);
        pacientlost.SetActive(false);
        if (emptyChair[possition] == 1) 
        {
            emptyChair[possition] = 0;
            Data_Controler.pacientNumeber--;
            Data_Controler.pacientsLost++;
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
