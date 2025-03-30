using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFire : MonoBehaviour
{
    public GameObject projectile;
    public GameObject projectileStartingPos;
    [SerializeField] private int poolSize = 10;
    private GameObject bulletParent;
    private Queue<GameObject> bulletPool;
    private Coroutine fireCoroutine;
    public static RandomFire instance;
    void Awake()
    {
        if (instance == null)
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
        bulletParent = new GameObject("Bullet Pool(Seeking bullets)");
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(projectile, bulletParent.transform);
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
            GameObject bullet = Instantiate(projectile, bulletParent.transform);
            return bullet;
        }
    }
    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }


    void Fire()
    {
        GameObject bullet = GetPooledBullet();
        bullet.transform.position = projectileStartingPos.transform.position;
        bullet.transform.rotation = transform.rotation;

        StartCoroutine(DeactivateBulletAfterTime(bullet, 4f)); // Adjust bullet lifespan
    }
    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnBulletToPool(bullet);
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
