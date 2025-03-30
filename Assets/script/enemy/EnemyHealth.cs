using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    public float EnemyCurrenthealth { get; private set; }
    private bool dead;
    [SerializeField] private GameObject Blast_Effect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume;
    private SpriteRenderer EnemySprite;
    private EnemyMovement movement;
    private LAstFire lastFire;
    private void Awake()
    {
        EnemyCurrenthealth = StartingHealth;
        EnemySprite = this.GetComponent<SpriteRenderer>();
        movement = this.GetComponent<EnemyMovement>();
        lastFire= this.GetComponent<LAstFire>();
    }
    public void takedamage(float damage)
    {
        EnemyCurrenthealth = Mathf.Clamp(EnemyCurrenthealth - damage, 0, StartingHealth);
        if (EnemyCurrenthealth > 0)
        {
            if(EnemyCurrenthealth<3&& !lastFire.startedHellFire)
            {
                lastFire.StartFiring();
            }
        }
        else
        {
            if (!dead)
            {
                GameObject obj = (GameObject)Instantiate(Blast_Effect, transform.position - new Vector3(0, 0, 0), Quaternion.identity); //Spawn Blast effect
                movement.enabled = false; EnemySprite.enabled = false;
                StartCoroutine(destroy());
                dead = true;
            }
        }
        if (EnemyCurrenthealth == 0)
        {
            audioSource.PlayOneShot(audioClip, volume);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //takedamage(EnemyCurrenthealth);
            takedamage(0.025f);
        }
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    void FixedUpdate()
    {
        
    }
}
