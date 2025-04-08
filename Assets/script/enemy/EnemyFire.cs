using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private Coroutine fireCoroutine;


    void Start()
    {
        fireCoroutine= StartCoroutine(Starting());
    }
    private void Fire()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject bullet = PoolingManager.instance.GetObjectFromPool("Mini Bullet");
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;

            StartCoroutine(DeactivateBulletAfterTime(bullet, 4f)); // Adjust bullet lifespan
        }
    }

    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        PoolingManager.instance.ReturnObjectToPool(bullet);
    }

    private void StartFire()
    {
        InvokeRepeating(nameof(Fire), 1f, 0.5f);
    }

    private void StopFire()
    {
        CancelInvoke(nameof(Fire));
    }

    private IEnumerator Starting()
    {
        StartFire();
        yield return new WaitForSeconds(6f);
        StopFire();
        yield return new WaitForSeconds(2f);
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
        fireCoroutine= StartCoroutine(Starting());
    }
}
