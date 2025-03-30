using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAstFire : MonoBehaviour
{ 
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
        Instantiate(Bullet, Spawnpoint[4].position, Spawnpoint[4].rotation);
        Instantiate(Bullet, Spawnpoint[5].position, Spawnpoint[5].rotation);
        Instantiate(Bullet, Spawnpoint[6].position, Spawnpoint[6].rotation);
        Instantiate(Bullet, Spawnpoint[7].position, Spawnpoint[7].rotation);
        Instantiate(Bullet, Spawnpoint[8].position, Spawnpoint[8].rotation);
        Instantiate(Bullet, Spawnpoint[9].position, Spawnpoint[9].rotation);
        Instantiate(Bullet, Spawnpoint[10].position, Spawnpoint[10].rotation);
        Instantiate(Bullet, Spawnpoint[11].position, Spawnpoint[11].rotation);
    }

void StartSpray()
{
    InvokeRepeating("Spray", 0.1f, 0.3f);
}

IEnumerator StartingSpray()
{
    yield return new WaitForSeconds(120f);
    StartSpray();
    yield return new WaitForSeconds(6f);
    StopSpray();
    yield return new WaitForSeconds(5f);
    StartCoroutine(StartingSpray());
}
void StopSpray()
{
    CancelInvoke();
}
}
