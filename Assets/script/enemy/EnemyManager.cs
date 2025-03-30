using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth health;
    private EnemyMovement EnemyMovement;
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private AudioSource bulletSound;
    // Start is called before the first frame update
    void Start()
    {
        bullet[0].SetActive(true);
        bullet[1].SetActive(true);
        bullet[2].SetActive(true);
        bullet[3].SetActive(true);
        bullet[4].SetActive(true);
        bulletSound.Play();
        EnemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.currenthealth==0)
        {
         EnemyMovement.enabled = false;
            bullet[0].SetActive(false);
            bullet[1].SetActive(false);
            bullet[2].SetActive(false);
            bullet[3].SetActive(false);
            bullet[4].SetActive(false);
        }
    }

}
