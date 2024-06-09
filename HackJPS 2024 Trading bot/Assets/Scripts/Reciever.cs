using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Reciever : MonoBehaviour
{
    public int stockBuySellAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Buy(TMP_Text moneyLeft, int money)
    {
        money -= stockBuySellAmount;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
    }

    public void Sell(TMP_Text moneyLeft, int money)
    {
        money += stockBuySellAmount;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
    }
}
