using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    public MoneySystem moneySystem;
    private List<string[]> tokens;

    // Start is called before the first frame update
    private void Awake()
    {
        lr = GetComponent<LineRenderer> ();
        tokens = moneySystem.tokens;
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length();
        this.points = points;
    }

    private void Update()
    {
        for(int i = 0; i < lr.positionCount; i++) 
        {
            Random rnd = new Random();
            int num = rnd.Next();
            lr.SetPosition(i, points[i].position + (Vector3.up * num).normalized * 10);
        }
    }
}
