using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBullet : MonoBehaviour
{
    [SerializeField] private Transform BarrelTop;
    [SerializeField] private float speed = 3f;
    public int ScoreValue;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(BarrelTop.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //Don't want to collide with the ship that's shooting this thing, nor another projectile.
        if (col.gameObject.tag!= "Player" && col.gameObject.tag != "Projectile"&&col.gameObject.tag!="Shield")
        {
          if(col.gameObject.tag!="EnemyBullet")
            {
                Score.ScoreVal += ScoreValue;
            }
            GameObject explosionEffect = PoolingManager.instance.GetObjectFromPool("Big Explosion");
            explosionEffect.transform.position = transform.position;
            explosionEffect.transform.rotation = Quaternion.identity;
            PoolingManager.instance.ReturnObjectToPool(this.gameObject);
        }
    }

}
