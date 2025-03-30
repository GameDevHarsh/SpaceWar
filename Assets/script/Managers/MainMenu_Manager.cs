using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour
{

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject ExitMenu;
    [SerializeField] private GameObject SoundMenu;

   
    private void Start()
    {
        Time.timeScale = 1f;
        MainMenu.SetActive(true);
        SoundMenu.SetActive(false);
        ExitMenu.SetActive(false);
    }

    public void ExitButtonOnClick()
    {
        MainMenu.SetActive(false);
        ExitMenu.SetActive(true);

    }
    public void OptionButtonOnClick()
    {
        MainMenu.SetActive(false);
        SoundMenu.SetActive(true);

    }
    public void crossbuttonOnclick()
    {
        MainMenu.SetActive(true);
        SoundMenu.SetActive(false);
    }
    public void yesbuttonOnClick()
    {
        ExitMenu.SetActive(false);
        Application.Quit();
    }
    public void noButtonOnClick()
    {
        MainMenu.SetActive(true);
        ExitMenu.SetActive(false);
    }
    public void playButtonOnClick()
    {
        SceneManager.LoadScene("Level 1");
    }

}
