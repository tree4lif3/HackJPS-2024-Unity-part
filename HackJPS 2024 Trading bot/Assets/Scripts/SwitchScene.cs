using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public Animator animator;
    public GameObject mainMenu;
    public GameObject controls;

    public GameObject loadText;

    private void Start()
    {
        controls.SetActive(false);
        mainMenu.SetActive(true);
        loadText.SetActive(false);

        animator.SetBool("Back Button", false);
        animator.SetBool("ControlButton", false);
    }

    // Start is called before the first frame update
    public void Controls()
    {
        mainMenu.SetActive(false);

        animator.SetBool("ControlButton", true);
        animator.SetBool("Back Button", false);
        controls.SetActive(true);
    }
    public void Back()
    {
        controls.SetActive(false);
        mainMenu.SetActive(true);

        animator.SetBool("Back Button", true);
        animator.SetBool("ControlButton", false);
    }
    public void BusinessGame()
    {
        loadText.SetActive(true);
        SceneManager.LoadScene("Business Game");
    }
    public void TradingBot()
    {
        SceneManager.LoadScene("Trading Bot");
    }
}
