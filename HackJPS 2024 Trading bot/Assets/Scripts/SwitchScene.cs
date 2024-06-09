using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void Back()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
