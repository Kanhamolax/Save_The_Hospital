using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controler_Menu_Info : MonoBehaviour
{
    public TextMeshProUGUI season, risk, number,numberLost;
    public GameObject winter, sumer, autunm, spring;
    public float time,timetochange;
    public int seasonFlag;
    
    // Start is called before the first frame update
    void Start()
    {
        seasonFlag = 1;
    }

    // Update is called once per frame
    void Update()
    {
        number.text = Data_Controler.pacientNumeber.ToString();
        numberLost.text = Data_Controler.pacientsLost.ToString();

        SeanonControler();
    }
    void SeanonControler()
    {
        time += Time.deltaTime;
        if (time >= timetochange)
        {
            seasonFlag++;
            if (seasonFlag == 4)
            {
                seasonFlag = 1;
            }
            time = 0;
        }
        switch (seasonFlag) 
        {
            case 1:
                season.text = "WINTER";
                risk.text = "INFLUENZA";
                sumer.SetActive(false);
                autunm.SetActive(false);
                spring.SetActive(false);
                winter.SetActive(true);
                break;
            case 2:
                season.text = "SPRING";
                risk.text = "POISON";
                winter.SetActive(false);
                sumer.SetActive(false);
                autunm.SetActive(false);
                spring.SetActive(true);
                break;
            case 3:
                season.text = "SUMER";
                risk.text = "ACIDENT";

                autunm.SetActive(false);
                winter.SetActive(false);
                spring.SetActive(false);
                sumer.SetActive(true);
                break;
            case 4:
                season.text = "AUTUNM";
                risk.text = "GRIPPE";
                sumer.SetActive(false);
                winter.SetActive(false);
                spring.SetActive(false);
                autunm.SetActive(true);

                break;

        }
    }
}
