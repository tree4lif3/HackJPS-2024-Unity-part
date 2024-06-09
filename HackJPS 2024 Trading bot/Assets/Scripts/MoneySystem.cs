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
    private RaycastHit hitInfo;
    private float distance = 3f;

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
            Ray ray = new Ray(transform.position + cam.transform.localPosition, cam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * distance);
            Physics.Raycast(ray, out hitInfo, distance);
            print(hitInfo);
            print(cam.transform.forward);
            print("1");
            if(hitInfo.rigidbody.gameObject.tag == "Buy")
            {
                hitInfo.rigidbody.gameObject.GetComponent<Reciever>().Buy(moneyLeft, money);
            }
            else if(hitInfo.rigidbody.gameObject.tag == "Sell")
            {
                hitInfo.rigidbody.gameObject.GetComponent<Reciever>().Sell(moneyLeft, money);
            }
        }
    }
}
