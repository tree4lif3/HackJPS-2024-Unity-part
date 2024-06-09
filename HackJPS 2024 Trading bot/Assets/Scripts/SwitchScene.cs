using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controls;

    private void Start()
    {
        controls.SetActive(false);
    }

    // Start is called before the first frame update
    public void Controls()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void Back()
    {
        controls.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void BusinessGame()
    {
        SceneManager.LoadScene("Business Game");
    }

}
