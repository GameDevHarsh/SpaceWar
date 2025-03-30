using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject SmallBullet;
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
        Instantiate(SmallBullet, GunnerTop1.position, GunnerTop1.rotation);
        Instantiate(SmallBullet, GunnerTop2.position, GunnerTop2.rotation);
        audioSource.PlayOneShot(audioClip, volume);
    }
    void StartFire()
    {
        InvokeRepeating("fire", 0.2f, 0.2f);
    }
}
