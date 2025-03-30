using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAstFire : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] spawnPoints;
    private GameObject bulletParent;
    [SerializeField] private int poolSize = 100;

    private Queue<GameObject> bulletPool;
    private Coroutine fireCoroutine;
    [HideInInspector]
    public bool startedHellFire = false;
    public static LAstFire instance;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        InitializePool();
    }

    private void InitializePool()
    {
        bulletPool = new Queue<GameObject>();
        bulletParent = new GameObject("Bullet Pool");
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletParent.transform);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    private GameObject GetPooledBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletParent.transform);
            return bullet;
        }
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnBulletToPool(bullet);
    }
    private void Spray()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject bullet = GetPooledBullet();
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;
            bullet.SetActive(true);
            StartCoroutine(DeactivateBulletAfterTime(bullet, 5f));
        }
    }


    private void StartSpray()
    {
        InvokeRepeating(nameof(Spray), 0.1f, 0.3f);
    }

    public void StartFiring()
    {
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
        fireCoroutine = StartCoroutine(StartingSpray());
    }

    private IEnumerator StartingSpray()
    {
        startedHellFire = true;
        StartSpray();
        yield return new WaitForSeconds(6f);
        StopSpray();
        yield return new WaitForSeconds(10f);
        startedHellFire = false;
    }

    private void StopSpray()
    {
        CancelInvoke(nameof(Spray));
    }
}
