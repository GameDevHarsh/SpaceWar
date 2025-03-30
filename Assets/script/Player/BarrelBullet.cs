using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBullet : MonoBehaviour
{
    [SerializeField] private Transform BarrelTop;
    [SerializeField] private float speed = 3f;
    [SerializeField] private GameObject hit_effect;
    public int ScoreValue;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

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
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
