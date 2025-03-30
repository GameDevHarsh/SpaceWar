using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    public float ShieldCurrentHealth { get; private set; }
    private bool destroyed;
    private void Awake()
    {
        ShieldCurrentHealth = StartingHealth;
    }
    public void takeDamage(float damage)
    {
        ShieldCurrentHealth = Mathf.Clamp(ShieldCurrentHealth - damage, 0, StartingHealth);
        if (ShieldCurrentHealth > 0)
        {

        }
        else
        {
            if (!destroyed)
            {
                StartCoroutine(destroy());
                destroyed = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(ShieldCurrentHealth);
        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            takeDamage(0.5f);
        }
        if(collision.gameObject.CompareTag("Powerup")&&ShieldCurrentHealth>0&&ShieldCurrentHealth<10)
        {
            ShieldCurrentHealth++;
        }
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    void Update()
    {

    }
}
