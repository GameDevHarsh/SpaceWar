using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private GameObject SmallBullet;
    [SerializeField] private Transform Spawnpoint1;
    [SerializeField] private Transform Spawnpoint2;
    [SerializeField] private Transform Spawnpoint3;
    [SerializeField] private Transform Spawnpoint4;
    void Start()
    {
        StartCoroutine(Starting());
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void fire()
    {
        
            Instantiate(SmallBullet, Spawnpoint1.position, Spawnpoint1.rotation);
            Instantiate(SmallBullet, Spawnpoint2.position, Spawnpoint2.rotation);
            Instantiate(SmallBullet, Spawnpoint3.position, Spawnpoint3.rotation);
            Instantiate(SmallBullet, Spawnpoint4.position, Spawnpoint4.rotation);
    }
   void StartFire()
    {
        
            InvokeRepeating("fire", 1, 0.5f);
    }
    void StopFire()
    {
        CancelInvoke();
    }
    IEnumerator Starting()
    {
       
        StartFire();
        yield return new WaitForSeconds(6f);
        StopFire();
        yield return new WaitForSeconds(2f);
        StartCoroutine(Starting());
    }
}
