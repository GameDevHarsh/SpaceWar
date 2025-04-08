using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LAstFire : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private Coroutine fireCoroutine;
    [HideInInspector]
    public bool startedHellFire = false;

    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        PoolingManager.instance.ReturnObjectToPool(bullet);
    }
    private void Spray()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject bullet = PoolingManager.instance.GetObjectFromPool("Last Bullet");
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
