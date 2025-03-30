using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Bullet;
    [SerializeField] private Transform[] Spawnpoint;
    [SerializeField] private int poolSize = 10;
    private GameObject bulletParent;
    public static Fire instance;
    private Queue<GameObject> bulletPool;
    private Coroutine fireCoroutine;
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
        fireCoroutine= StartCoroutine(StartingSpray());
    }
    private void InitializePool()
    {
        bulletParent = new GameObject("Bullet Pool(Green bullets)");
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(Bullet, bulletParent.transform);
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
            GameObject bullet = Instantiate(Bullet, bulletParent.transform);
            return bullet;
        }
    }
    public void ReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }

    private void Spray()
    {
        foreach (Transform spawnPoint in Spawnpoint)
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
    void StartSpray()
    {
        InvokeRepeating(nameof(Spray), 0.1f, 0.05f);
    }

    IEnumerator StartingSpray()
    {
        yield return new WaitForSeconds(22f);
        StartSpray();
        yield return new WaitForSeconds(8f);
        StopSpray();
        yield return new WaitForSeconds(5f);
        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }
        fireCoroutine = StartCoroutine(StartingSpray());
    }
    void StopSpray()
    {
        CancelInvoke(nameof(Spray));
    }
}
