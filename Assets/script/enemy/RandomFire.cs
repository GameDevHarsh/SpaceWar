using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFire : MonoBehaviour
{
    public GameObject projectileStartingPos;
    private Coroutine fireCoroutine;
    void Start()
    {
        fireCoroutine= StartCoroutine(Starting());
       
    }
    void Fire()
    {
        GameObject bullet = PoolingManager.instance.GetObjectFromPool("Seeking Bullet");
        bullet.transform.position = projectileStartingPos.transform.position;
        bullet.transform.rotation = transform.rotation;

        StartCoroutine(DeactivateBulletAfterTime(bullet, 4f)); // Adjust bullet lifespan
    }
    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        PoolingManager.instance.ReturnObjectToPool(bullet);
    }
    void StartFire()
    {
        InvokeRepeating(nameof(Fire), 2, 0.3f);
    }
    void StopFire()
    {
        CancelInvoke(nameof(Fire));
    }
    IEnumerator Starting()
    {

        StartFire();
        yield return new WaitForSeconds(5f);
        StopFire();
        yield return new WaitForSeconds(8f);
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
        fireCoroutine = StartCoroutine(Starting());
    }
   
}
