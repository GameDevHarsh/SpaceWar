using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField]
    private Transform barreltop;
    [SerializeField] private GameObject bullet;
    private Vector2 lookdirection;
    private float lookangle;


    //[SerializeField] private float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        lookdirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookangle = Mathf.Atan2(lookdirection.y, lookdirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookangle - 90);
    }
    private void FireBullet()
    {
        Instantiate(bullet, barreltop.position, barreltop.rotation);
    }
    void StartFire()
    {
            InvokeRepeating("FireBullet", 0.5f, 0.6f);
       
    }
    void Start()
    {
        StartFire();
    }
}
