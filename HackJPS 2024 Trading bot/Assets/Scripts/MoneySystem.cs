using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public TMP_Text moneyLeft;
    public TMP_Text stockAmounts;
    public int money = 10000;
    public Camera cam;
    private float distance = 100f;
    [SerializeField] private LayerMask mask;
    private int stockBuySellAmount = 0;
    private int currentStocksHeld = 0;
    private int currentStockPrice = 0;
    private int currentEntry = 0;
    private string[,] tokens = new string[619040, 8];

    // Start is called before the first frame update
    void Start()
    {
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;

        TextReader reader = File.OpenText("Assets/all_stocks_5yr.csv");
        for(int i = 0; i < 619040;  i++)
        {
            for(int j = 0; j < 8;  j++)
            {
                string line = reader.ReadLine();
                tokens[i, j] = line.Split(',')[j];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance);
            if(Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                if (hitInfo.rigidbody.gameObject.tag == "Buy")
                {
                    Buy(moneyLeft, money);
                    DisplayEntry(currentEntry);
                }
                else if (hitInfo.rigidbody.gameObject.tag == "Sell")
                {
                    Sell(moneyLeft, money);
                    DisplayEntry(currentEntry);
                }
                else if (hitInfo.rigidbody.gameObject.tag == "More")
                {
                    stockBuySellAmount++;
                    stockAmounts.text = stockBuySellAmount.ToString();
                }
                else if (hitInfo.rigidbody.gameObject.tag == "Less")
                {
                    stockBuySellAmount--;
                    stockAmounts.text = stockBuySellAmount.ToString();
                }
                else
                {
                    Buy(moneyLeft, 0);
                }
            }
        }
    }

    public void Buy(TMP_Text moneyLeft, int money)
    {
        this.money -= stockBuySellAmount * currentStockPrice;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
        currentStocksHeld += stockBuySellAmount;
    }

    public void Sell(TMP_Text moneyLeft, int money)
    {
        this.money += stockBuySellAmount * currentStockPrice;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
        currentStocksHeld -= stockBuySellAmount;
    }

    private void DisplayEntry(int entryNumber)
    {
        
        currentEntry++;
    }
}
