using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera cam,cam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Changecam(int i)
    {
       if(i== 0) 
       {
            cam.gameObject.SetActive(true);
            cam2.gameObject.SetActive(false);
       }
        if (i == 1)
        {
            cam.gameObject.SetActive(false);
            cam2.gameObject.SetActive(true);
        }
    }
}
