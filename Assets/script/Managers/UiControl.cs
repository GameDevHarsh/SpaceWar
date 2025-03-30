using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiControl : MonoBehaviour
{
    
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject option;
    [SerializeField] private GameObject QuitOption;
    private void Awake()
    {
      
    }

    private void Start()
    {
        pause.SetActive(true);
        Time.timeScale = 1f;
        resume.SetActive(false);
        play.SetActive(false );
        option.SetActive(false);
        QuitOption.SetActive(false);
    }
    public void PauseButtonOnClick()
    {
        Time.timeScale = 0f;
        pause.SetActive(false);
        resume.SetActive(true);
        play.SetActive(true);
    }
    public void ResumeButtonOnClick()
    {
    Time.timeScale = 1f;
    resume.SetActive(false);
    pause.SetActive(true);
    play.SetActive(false);
    }

        
        public void OptionButtonOnClick()
    {
        resume.SetActive(false);
        option.SetActive(true);
    }
    public void CrossOnClick()
    {
        option.SetActive(false);
      resume.SetActive(true) ;
    }
    public void QuitButtonOnCLick()
    {
        resume.SetActive(false) ;
        QuitOption.SetActive(true);
    }
    public void YesButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NoButtonOnCLick()
    {
        resume.SetActive(true);
        QuitOption.SetActive(false);
    }
}
