using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1f;
    private Transform player;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            PoolingManager.instance.ReturnObjectToPool(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Player"))
        {
            PoolingManager.instance.ReturnObjectToPool(this.gameObject);
        }
    }
}