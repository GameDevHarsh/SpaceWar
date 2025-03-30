using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private EnemyHealth health;
    [SerializeField] private float speed;
    private Playermovment move;
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private AudioSource bulletSound;
    // Start is called before the first frame update
    void Start()
    {
        move=GetComponent<Playermovment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.EnemyCurrenthealth==0)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            move.enabled = false;
            bullet[0].SetActive(false);
            bullet[1].SetActive(false);
            bullet[2].SetActive(false);
            bullet[3].SetActive(false);
            bullet[4].SetActive(false);
            bulletSound.Pause();
        }
    }
}
