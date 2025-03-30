using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform[] Spawnpoint;
    void Start()
    {
        StartCoroutine(StartingSpray());
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void Spray()
    {
            Instantiate(Bullet, Spawnpoint[0].position, Spawnpoint[0].rotation);
        Instantiate(Bullet, Spawnpoint[1].position, Spawnpoint[1].rotation);
        Instantiate(Bullet, Spawnpoint[2].position, Spawnpoint[2].rotation);
        Instantiate(Bullet, Spawnpoint[3].position, Spawnpoint[3].rotation);
    }

    void StartSpray()
    {
        InvokeRepeating("Spray", 0.1f, 0.05f);
    }

    IEnumerator StartingSpray()
    {
        yield return new WaitForSeconds(22f);
        StartSpray();
        yield return new WaitForSeconds(8f);
        StopSpray();
        yield return new WaitForSeconds(5f);
        StartCoroutine(StartingSpray());
    }
    void StopSpray()
    {
        CancelInvoke();
    }
}
