using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private GameObject WinScoreBoard;
    [SerializeField] private GameObject LossScoreBoard;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text score;
    [SerializeField] private Text Record;
    [SerializeField] private Text L_Score;
    [SerializeField] private Text L_Record;
    [SerializeField] private int CurrentLevel;
    private int value;
    private int HighValue;
    // Start is called before the first frame update
    void Start()
    {

        WinScoreBoard.SetActive(false);
        LossScoreBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         value = Score.ScoreVal;
        score.GetComponent<Text>().text = "" + value;
        L_Score.GetComponent<Text>().text = "" + value;
        HighValue = HighScore.HighScoreVal;
        Record.GetComponent<Text>().text = "" + HighValue;
        L_Record.GetComponent<Text>().text = "" + HighValue;
        StartCoroutine(LoadScoreBoard());

    }
    public void ReplayButtonOnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(CurrentLevel);
        
    }
    public void ContinueButtonOnClick()
    {
        Time.timeScale = 1f;
        if(health.currenthealth==0)
        {
            SceneManager.LoadScene("Level 1");
        }
        if(health.currenthealth>0)
        {
            SceneManager.LoadScene("Level 2");
        }
    }
    public void CloseButtonOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator LoadScoreBoard()
    {
        yield return new WaitForSeconds(1f);
        if (health.currenthealth == 0)
        {
            
            yield return new WaitForSeconds(0.5f);
            canvas.SetActive(false);
            yield return new WaitForSeconds(1f);
            LossScoreBoard.SetActive(true);
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0f;
        }
        else if(enemyHealth.EnemyCurrenthealth==0)
        {
            yield return new WaitForSeconds(5f);
            WinScoreBoard.SetActive(true);

            if (Score.ScoreVal > 5000)
            {
            }
            else if (Score.ScoreVal < 5000)
            {
            }
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0f;
        }
    }
}
