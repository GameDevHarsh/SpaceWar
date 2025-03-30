using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private GameObject smallBulletPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int poolSize = 10;
    private GameObject bulletParent;
    public static EnemyFire instance;
    private Queue<GameObject> bulletPool;
    private Coroutine fireCoroutine;

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        InitializePool();
    }

    void Start()
    {
        fireCoroutine= StartCoroutine(Starting());
    }

    private void InitializePool()
    {
        bulletParent = new GameObject("Bullet Pool(mini bullets)");
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(smallBulletPrefab, bulletParent.transform);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }
    }

    private GameObject GetPooledBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            GameObject bullet = Instantiate(smallBulletPrefab, bulletParent.transform);
            return bullet;
        }
    }

    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    private void Fire()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject bullet = GetPooledBullet();
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = spawnPoint.rotation;

            StartCoroutine(DeactivateBulletAfterTime(bullet, 4f)); // Adjust bullet lifespan
        }
    }

    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnBulletToPool(bullet);
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
