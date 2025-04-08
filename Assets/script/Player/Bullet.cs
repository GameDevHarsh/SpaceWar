using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public int ScoreValue;
    private void Start()
    {
        GameObject muzzle = PoolingManager.instance.GetObjectFromPool("Muzzle");
        muzzle.transform.position = transform.position - new Vector3(0, 0, 0);
        muzzle.transform.rotation = Quaternion.identity;
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
            GameObject explosionEffect = PoolingManager.instance.GetObjectFromPool("Small Explosion");
            explosionEffect.transform.position = transform.position - new Vector3(0, 0, 0);
            explosionEffect.transform.rotation = Quaternion.identity;
            PoolingManager.instance.ReturnObjectToPool(this.gameObject);
        }
    }
}
