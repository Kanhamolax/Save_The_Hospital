using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class CuraData : MonoBehaviour
{
    public TextMeshProUGUI xray, respirator, antpoison, remedy,moneyTotal;
    public TextMeshProUGUI xray2, respirator2, antpoison2, remedy2;
    public TextMeshProUGUI xray3, respirator3, antpoison3, remedy3;

    void Start()
    {
       
        Data_Controler.money = 1000;
        Data_Controler.costRespirator = 20;
        Data_Controler.costAntPOison = 15;
        Data_Controler.costXray = 20;
        Data_Controler.costRemedy = 10;
        Data_Controler.pacinetGotratament = -1;
        Data_Controler.tratamentUse = 0;


    }
    void FixedUpdate()
    {
        Stok();
        GameOver();
    }
    public void CuraUtilizada(int cura)
    {
        if (cura == 1&& Data_Controler.quantRespirator>=1)
        {
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantRespirator--;
        }
        if (cura == 2 && Data_Controler.quantAntPOison>=1)
        {
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantAntPOison--;
        }
        if (cura == 3 && Data_Controler.quantXray>=1)
        {
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantXray--;
        }
        if (cura == 4 && Data_Controler.quantRemedy>=1)
        {
            Data_Controler.tratamentUse = cura;
            Data_Controler.quantRemedy--;
        }

       
    }
    public void BuyStok(int prodt)
    {
        if(prodt==1)
        {
            Data_Controler.quantRespirator++;
            Data_Controler.money -= Data_Controler.costRespirator;
        }
        if (prodt == 2)
        {
            Data_Controler.quantAntPOison++;
            Data_Controler.money -= Data_Controler.costAntPOison;
        }
        if (prodt == 3)
        {
            Data_Controler.quantXray++;
            Data_Controler.money-= Data_Controler.costXray;
        }
        if (prodt == 4)
        {
            Data_Controler.quantRemedy++;
            Data_Controler.money -= Data_Controler.costRemedy;

        }

    }
    public void Stok()
    {
        moneyTotal.text = Data_Controler.money.ToString()+",00";
        xray.text=Data_Controler.costXray.ToString() + ",00";
        xray2.text=Data_Controler.quantXray.ToString();
        xray3.text = Data_Controler.quantXray.ToString();

        respirator.text=Data_Controler.costXray.ToString() + ",00";
        respirator2.text=Data_Controler.quantRespirator.ToString();
        respirator3.text = Data_Controler.quantRespirator.ToString();


        antpoison.text=Data_Controler.costAntPOison.ToString() + ",00";
        antpoison2.text = Data_Controler.quantAntPOison.ToString();
        antpoison3.text = Data_Controler.quantAntPOison.ToString();

        remedy.text=Data_Controler.costRemedy.ToString() + ",00";
        remedy2.text=Data_Controler.quantRemedy.ToString();
        remedy3.text = Data_Controler.quantRemedy.ToString();
    }

    public void GameOver()
    {
        if(Data_Controler.pacientsLost==20)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
