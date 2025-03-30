using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject powerup;
 [SerializeField]private GameObject projectileStartingPos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private EnemyHealth health;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void SpawnTime()
    {
        if(health.EnemyCurrenthealth<=9)
        {
            Spawn();
        }
        if(health.EnemyCurrenthealth<=8)
        {
            Spawn();
        }
    }
    // Update is called once per frame
    void Update()
    {
        SpawnTime();
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void Spawn()
    {
        Instantiate(powerup, projectileStartingPos.transform.position, transform.rotation);
    }
}
