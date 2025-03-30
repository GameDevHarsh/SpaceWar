using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    [SerializeField]
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadLevel()
    {
        Time.timeScale = 0f;
        yield return new WaitForSeconds(10f);
        Time.timeScale = 1f;
    }
   
}
