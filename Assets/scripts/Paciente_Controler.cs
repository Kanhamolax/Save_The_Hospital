using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEditor.Animations;


public class Paciente_Controler : MonoBehaviour
{
    public GameObject entrada1, entrada2,pacient;
    public Transform spawPoint;
    public float vel;
    public Transform [] wpoints, wpoints2;
    public int selectRote,nWp;
     Vector3 [] tragetoria,tragetoria2;


    private void Awake()
    {
        Data_Controler.route = 1;
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
        StartCoroutine(SpawPacient(5));
        
    }

    // Update is called once per frame
    void Update()
    {
        selectRote = Data_Controler.route;
    }
    public IEnumerator SpawPacient(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(pacient, spawPoint);
            if (Data_Controler.route == 1)
            {
                Data_Controler.route = 2;
                GameObject.FindGameObjectWithTag("pacient").transform.DOPath(tragetoria, vel, PathType.CatmullRom, PathMode.Ignore).SetEase(Ease.Linear).SetLookAt(0).OnComplete(() =>
                {
                    Destroy(GameObject.FindGameObjectWithTag("pacient"));

                });
            }
            else if (Data_Controler.route == 2)
            {
                Data_Controler.route = 1;
                GameObject.FindGameObjectWithTag("pacient").transform.DOPath(tragetoria2, vel+1, PathType.CatmullRom, PathMode.Ignore).SetEase(Ease.Linear).SetLookAt(0).OnComplete(() =>
                {
                    Destroy(GameObject.FindGameObjectWithTag("pacient"));

                });
            }
           

        }
    }
}
