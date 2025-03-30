using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject shoot_effect;
    [SerializeField] private GameObject hit_effect;
    public int ScoreValue;
    void Start()
    {
        GameObject obj = (GameObject)Instantiate(shoot_effect, transform.position - new Vector3(0, 0, 0), Quaternion.identity); //Spawn muzzle flash
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);//bullet moves upward
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        //Don't want to collide with the ship who shooting the bullet, nor another projectile.
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Projectile" && col.gameObject.tag != "Shield")
        {
            if (col.gameObject.tag != "EnemyBullet")
            {
                Score.ScoreVal += ScoreValue;
            }
            Instantiate(hit_effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
