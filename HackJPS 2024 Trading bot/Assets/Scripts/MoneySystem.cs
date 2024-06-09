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
    private RaycastHit hitinfo;

    // Start is called before the first frame update
    void Start()
    {
        moneyLeft.text = "Money Left(Bank and Stock Value): $" + money;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(transform.position + cam.transform.position, cam.transform.forward, out hitinfo, 100f);
            print(hitinfo);
            print(cam.transform.forward);
            print("1");
            if(hitinfo.rigidbody.gameObject.tag == "Buy")
            {
                hitinfo.rigidbody.gameObject.GetComponent<Reciever>().Buy(moneyLeft, money);
            }
            else if(hitinfo.rigidbody.gameObject.tag == "Sell")
            {
                hitinfo.rigidbody.gameObject.GetComponent<Reciever>().Sell(moneyLeft, money);
            }
        }
    }
}
