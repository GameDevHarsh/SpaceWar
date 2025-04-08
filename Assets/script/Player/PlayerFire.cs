using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform GunnerTop1;
    [SerializeField] private Transform GunnerTop2;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume;
    void Start()
    {
       StartFire();
    }
    private void fire()
    {
        GameObject bullet = PoolingManager.instance.GetObjectFromPool("Small Bullet");
        bullet.transform.position = GunnerTop1.position;
        bullet.transform.rotation = GunnerTop1.rotation;
        GameObject bullet1 = PoolingManager.instance.GetObjectFromPool("Small Bullet");
        bullet1.transform.position = GunnerTop2.position;
        bullet1.transform.rotation = GunnerTop2.rotation;
        StartCoroutine(DeactivateBulletAfterTime(bullet, 4f));
        StartCoroutine(DeactivateBulletAfterTime(bullet1, 4f));
        audioSource.PlayOneShot(audioClip, volume);
    }

    private IEnumerator DeactivateBulletAfterTime(GameObject bullet, float time)
    {
        yield return new WaitForSeconds(time);
        PoolingManager.instance.ReturnObjectToPool(bullet);
    }

    void StartFire()
    {
        InvokeRepeating("fire", 0.2f, 0.2f);
    }
}
