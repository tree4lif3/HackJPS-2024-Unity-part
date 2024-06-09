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
    public int money = 10000;
    public Camera cam;
    private float distance = 100f;
    [SerializeField] private LayerMask mask;
    private int stockBuySellAmount = 0;
    private int currentStocksHeld = 0;
    private int currentStockPrice = 0;
    private int currentEntry = 0;
    private List<string[]> tokens;

    // Start is called before the first frame update
    void Start()
    {
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;

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
        currentStockPrice = Int32.Parse(tokens[0][0]);
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
                if (hitInfo.rigidbody.gameObject.tag == "Buy" && stockBuySellAmount != 0)
                {
                    print("buy");
                    Buy(moneyLeft);
                    DisplayEntry(currentEntry);
                }
                else if (hitInfo.rigidbody.gameObject.tag == "Sell" && stockBuySellAmount != 0)
                {
                    print("sell");
                    Sell(moneyLeft);
                    DisplayEntry(currentEntry);
                }
                else if (hitInfo.rigidbody.gameObject.tag == "More")
                {
                    stockBuySellAmount++;
                    stockAmounts.text = stockBuySellAmount.ToString();
                }
                else if (hitInfo.rigidbody.gameObject.tag == "Less" && stockBuySellAmount != 0)
                {
                    stockBuySellAmount--;
                    stockAmounts.text = stockBuySellAmount.ToString();
                }
                else
                {
                    Buy(moneyLeft);
                }
            }
        }
    }

<<<<<<< HEAD
    public void Buy(TMP_Text moneyLeft)
=======
    public void Buy(TMP_Text moneyLeft, int money)
>>>>>>> parent of 07e7167 (Finished everything, so yummy laskjdflkajsd lkfjalskdj skibidi)
    {
        this.money -= stockBuySellAmount * currentStockPrice;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
        currentStocksHeld += stockBuySellAmount;
<<<<<<< HEAD
        moneyLeft.text = "Money Left(Bank): $" + this.money + " (Stock): $" + currentStocksHeld * currentStockPrice + " Total: $" + (this.money + currentStocksHeld * currentStockPrice);
    }

    public void Sell(TMP_Text moneyLeft)
=======
    }

    public void Sell(TMP_Text moneyLeft, int money)
>>>>>>> parent of 07e7167 (Finished everything, so yummy laskjdflkajsd lkfjalskdj skibidi)
    {
        this.money += stockBuySellAmount * currentStockPrice;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
        currentStocksHeld -= stockBuySellAmount;
<<<<<<< HEAD
        moneyLeft.text = "Money Left(Bank): $" + this.money + " (Stock): $" + currentStocksHeld * currentStockPrice + " Total: $" + (this.money + currentStocksHeld * currentStockPrice);
=======
>>>>>>> parent of 07e7167 (Finished everything, so yummy laskjdflkajsd lkfjalskdj skibidi)
    }

    private void DisplayEntry(int entryNumber)
    {
        
        currentEntry++;
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
