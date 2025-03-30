using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFire : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectileStartingPos;
    void Start()
    {
        StartCoroutine(Starting());
       
    }
    void Update()
    {
        
    }

    void Fire()
    {
        Instantiate(projectile, projectileStartingPos.transform.position, transform.rotation);
    }
    void StartFire()
    {

        InvokeRepeating("Fire", 2, 0.3f);
    }
    void StopFire()
    {
        CancelInvoke("Fire");
    }
    IEnumerator Starting()
    {

        StartFire();
        yield return new WaitForSeconds(5f);
        StopFire();
        yield return new WaitForSeconds(8f);
        StartCoroutine(Starting());
    }
   
}
