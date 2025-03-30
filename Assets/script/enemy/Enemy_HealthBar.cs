using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth EnemyHealth;
    [SerializeField] private EnemyHealth EnemyCurrenthealth;
    [SerializeField] private Image TotalHealthBar;
    [SerializeField] private Image CurrentHealthBar;

    private void Start()
    {
        TotalHealthBar.fillAmount = EnemyHealth.EnemyCurrenthealth / 10;
    }
    private void Update()
    {
        CurrentHealthBar.fillAmount = EnemyHealth.EnemyCurrenthealth / 10;
    }
}
