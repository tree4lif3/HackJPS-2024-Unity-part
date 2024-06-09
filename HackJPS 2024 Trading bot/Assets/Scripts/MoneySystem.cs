using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System.Text.RegularExpressions;

public class MoneySystem : MonoBehaviour
{
    public TMP_Text moneyLeft;
    public TMP_Text stockAmounts;
    public float money = 10000f;
    public Camera cam;
    private float distance = 100f;
    [SerializeField] private LayerMask mask;
    private float stockBuySellAmount = 0f;
    private float currentStocksHeld = 0f;
    private float currentStockPrice = 0f;
    private int currentEntry = 1;
    private List<string[]> tokens;

    // Start is called before the first frame update
    void Start()
    {
        moneyLeft.text = "Money Left(Bank): $10000 (Stock): $0 Total: $10000";

        /*TextReader reader = File.OpenText("Assets/all_stocks_5yr.csv");
        for(int i = 0; i < 619040;  i++)
        {
            for(int j = 0; j < 8;  j++)
            {
                string line = reader.ReadLine();
                tokens[i, j] = line.Split(',')[j];
            }
        }*/

        tokens = GetCsvContent("Assets/all_stocks_5yr.csv");
        currentStockPrice = float.Parse(tokens[currentEntry][1]);
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
                    print("buy");
                    Buy(moneyLeft, money);
                    DisplayEntry(currentEntry);
                }
                else if (hitInfo.rigidbody.gameObject.tag == "Sell")
                {
                    print("sell");
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

    public void Buy(TMP_Text moneyLeft, float money)
    {
        this.money -= stockBuySellAmount * currentStockPrice;
        currentStocksHeld += stockBuySellAmount;
        moneyLeft.text = "Money Left(Bank): $" + this.money + " (Stock): $" + currentStocksHeld * currentStockPrice + " Total: $" + this.money + currentStocksHeld * currentStockPrice;
    }

    public void Sell(TMP_Text moneyLeft, float money)
    {
        this.money += stockBuySellAmount * currentStockPrice;
        currentStocksHeld -= stockBuySellAmount;
        moneyLeft.text = "Money Left(Bank): $" + this.money + " (Stock): $" + currentStocksHeld * currentStockPrice + " Total: $" + this.money + currentStocksHeld * currentStockPrice;
    }

    private void DisplayEntry(int entryNumber)
    {
        currentEntry++;
        currentStockPrice = float.Parse(tokens[currentEntry][1]);
    }

    public List<string[]> GetCsvContent(string iFileName)
    {
        var table = new List<string[]>();
        using (var r = new StreamReader(iFileName))
        {
            while (!r.EndOfStream)
            {
                string line = r.ReadLine();
                table.Add(Regex.Split(line, @"\s|[;]|[,]"));
            }

            r.Close();
        }

        return table;
    }
}
