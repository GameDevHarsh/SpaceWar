using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float StartingHealth;
    public float currenthealth { get; private set; }
    private bool dead;
    [SerializeField] private GameObject Blast_Effect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private float volume;
    private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer barrel;
    private Playermovment movement;
    [SerializeField] private ShieldHealth shield;
    private void Awake()
    {
        currenthealth = StartingHealth;
        playerSprite = GetComponent<SpriteRenderer>();
        movement = GetComponent<Playermovment>();
    }
    public void TakeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, StartingHealth);
        if (currenthealth > 0)
        {

        }
        else
        {
            if (!dead)
            {
                GameObject obj = (GameObject)Instantiate(Blast_Effect, transform.position - new Vector3(0, 0, 0), Quaternion.identity); //Spawn Blast effect
                movement.enabled = false;barrel.enabled = false;playerSprite.enabled = false;
                StartCoroutine( destroy());
                dead = true;
            }
        }
        if (currenthealth == 0)
        {
            audioSource.PlayOneShot(audioClip, volume);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag =="Enemy" && shield.ShieldCurrentHealth==0)
        {
            TakeDamage(currenthealth);
        }
        if (collision.gameObject.CompareTag("EnemyBullet") && shield.ShieldCurrentHealth == 0)
        {
            TakeDamage(0.25f);
        }
            if (collision.gameObject.CompareTag("Powerup")&&shield.ShieldCurrentHealth==0)
            {
               currenthealth ++;
            }
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    void Update()
    {

    }
}
