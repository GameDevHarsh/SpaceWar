using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Transform[] Spawnpoint;
    private Coroutine fireCoroutine;

    void Start()
    {
        fireCoroutine= StartCoroutine(StartingSpray());
    }

    private void Spray()
    {
        foreach (Transform spawnPoint in Spawnpoint)
        {
            GameObject bullet = PoolingManager.instance.GetObjectFromPool("Green Bullet");
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
