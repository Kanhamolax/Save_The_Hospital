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
        Data_Controler.money= 1000;
        Data_Controler.costRespirator = 20;
        Data_Controler.costAntPOison = 15;
        Data_Controler.costXray = 20;
        Data_Controler.costRemedy = 10;
        Data_Controler.pacinetGotratament = -1;
        Data_Controler.tratamentUse = 0;
        

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
                Data_Controler.currentSeason = 0;
                season.text = "WINTER";
                risk.text = "INFLUENZA";
                sumer.SetActive(false);
                autunm.SetActive(false);
                spring.SetActive(false);
                winter.SetActive(true);
                Data_Controler.costRespirator = 25;
                Data_Controler.costAntPOison = 10;
                Data_Controler.costXray = 15;
                Data_Controler.costRemedy = 5;
                break;
            case 2:
                Data_Controler.currentSeason = 1;
                season.text = "SPRING";
                risk.text = "POISON";
                winter.SetActive(false);
                sumer.SetActive(false);
                autunm.SetActive(false);
                spring.SetActive(true);
                Data_Controler.costRespirator = 15;
                Data_Controler.costAntPOison = 20;
                Data_Controler.costXray = 15;
                Data_Controler.costRemedy = 5;
                break;
            case 3:
                Data_Controler.currentSeason = 2;
                season.text = "SUMER";
                risk.text = "ACIDENT";

                autunm.SetActive(false);
                winter.SetActive(false);
                spring.SetActive(false);
                sumer.SetActive(true);
                Data_Controler.costRespirator = 15;
                Data_Controler.costAntPOison = 10;
                Data_Controler.costXray = 25;
                Data_Controler.costRemedy = 5;
                break;
            case 4:
                Data_Controler.currentSeason = 3;
                season.text = "AUTUNM";
                risk.text = "GRIPPE";
                sumer.SetActive(false);
                winter.SetActive(false);
                spring.SetActive(false);
                autunm.SetActive(true);
                Data_Controler.costRespirator = 15;
                Data_Controler.costAntPOison = 10;
                Data_Controler.costXray = 15;
                Data_Controler.costRemedy = 15;

                break;

        }
    }
}
