using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCam : MonoBehaviour
{
    public GameObject[] cam;
    // Start is called before the first frame update
  
    public void ChangeSene(string sene)
    {
        SceneManager.LoadScene(sene);
    }
    public void Changecam(int k)
    {

        for (int j = 0; j < cam.Length; j++)
        {
            if (k == j)
            {

                cam[k].SetActive(true);
            }
            else
            {

                cam[j].SetActive(false);

            }
        }
        
        
    }
    public void Sair()
    {
        Application.Quit();

    }
}

