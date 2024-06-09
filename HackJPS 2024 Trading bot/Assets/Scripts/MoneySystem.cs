using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneySystem : MonoBehaviour
{
    public TMP_Text moneyLeft;
    public int money = 10000;
    public Camera cam;
    private float distance = 100f;
    [SerializeField] private LayerMask mask;
    private int stockBuySellAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
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
                }
                else if (hitInfo.rigidbody.gameObject.tag == "Sell")
                {
                    Sell(moneyLeft, money);
                }
            }
        }
    }

    public void Buy(TMP_Text moneyLeft, int money)
    {
        this.money -= stockBuySellAmount;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
    }

    public void Sell(TMP_Text moneyLeft, int money)
    {
        this.money += stockBuySellAmount;
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
    }
}
