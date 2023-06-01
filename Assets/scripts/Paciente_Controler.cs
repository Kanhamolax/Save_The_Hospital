
using System.Collections;

using UnityEngine;
using DG.Tweening;




public class Paciente_Controler : MonoBehaviour
{
    public GameObject entrada1, entrada2,pacient, pacient2;
    public Transform spawPoint;
    public float vel;
    public Transform [] wpoints, wpoints2;
    public int selectRote,nWp,randomNUmber;
    public int[] randonVector, randonVector2, randonVector3, randonVector4;
     Vector3 [] tragetoria,tragetoria2;


    private void Awake()
    {

        Data_Controler.route = 1;
        Data_Controler.pacientNumeber = 0;
        tragetoria = new Vector3[nWp];
        tragetoria2 = new Vector3[nWp];
        for (int i = 0; i < nWp; i++)
        {
            tragetoria[i] = wpoints[i].position;
            tragetoria2[i] = wpoints2[i].position;
        }



    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawPacient(5    ));
        
    }

    // Update is called once per frame
    void Update()
    {
        selectRote = Data_Controler.route;
    }
    public void RandonIllnes()
    {
        if(Data_Controler.currentSeason==0)
        {
            randomNUmber= UnityEngine.Random.Range(0,3);
            Data_Controler.illness = randonVector[randomNUmber];
        }
        else if (Data_Controler.currentSeason == 1)
        {
            randomNUmber = UnityEngine.Random.Range(0, 3);
            Data_Controler.illness = randonVector2[randomNUmber];
        }
       else if (Data_Controler.currentSeason == 2)
        {
            randomNUmber = UnityEngine.Random.Range(0, 3);
            Data_Controler.illness = randonVector3[randomNUmber];
        }
       else if (Data_Controler.currentSeason == 3)
        {
            randomNUmber = UnityEngine.Random.Range(0, 3);
            Data_Controler.illness = randonVector4[randomNUmber];
        }
    }
    public IEnumerator SpawPacient(float waitTime)
    {
        while (true)
        {
            RandonIllnes();
           
            Instantiate(pacient, spawPoint);
            if(Data_Controler.illness==0)
            {
                GameObject.FindGameObjectWithTag("pacient").GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (Data_Controler.illness==1)
            {
                GameObject.FindGameObjectWithTag("pacient").GetComponent<SpriteRenderer>().color = Color.green;
            }
            else if (Data_Controler.illness == 2)
            {
                GameObject.FindGameObjectWithTag("pacient").GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (Data_Controler.illness == 3)
            {
                GameObject.FindGameObjectWithTag("pacient").GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            
           
           
            
            // Random.Range(0, 3);

            if (Data_Controler.route == 1)
            {
                Data_Controler.route = 2;

                GameObject.FindGameObjectWithTag("pacient").transform.DOPath(tragetoria, vel, PathType.CatmullRom, PathMode.Ignore).SetEase(Ease.Linear).SetLookAt(0).OnComplete(() =>
                {
                    Destroy(GameObject.FindGameObjectWithTag("pacient"));
                    if(Data_Controler.pacientNumeber < 20)
                    {
                        Data_Controler.pacientNumeber++;
                       
                    }
                    else
                    {
                        Data_Controler.pacientsLost++;
                    }
                   

                });
            }
            else if (Data_Controler.route == 2)
            {
                Data_Controler.route = 1;
                GameObject.FindGameObjectWithTag("pacient").transform.DOPath(tragetoria2, vel+1, PathType.CatmullRom, PathMode.Ignore).SetEase(Ease.Linear).SetLookAt(0).OnComplete(() =>
                {
                    Destroy(GameObject.FindGameObjectWithTag("pacient"));
                    if (Data_Controler.pacientNumeber < 20)
                    {
                        Data_Controler.pacientNumeber++;
                    }
                    else
                    {
                        Data_Controler.pacientsLost++;
                    }

                });
            }
            yield return new WaitForSeconds(waitTime);


        }
    }
}
