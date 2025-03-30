using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]private PlayerHealth playerHealth;
    [SerializeField] private PlayerHealth currenthealth;
    [SerializeField] private Image  TotalHealthBar;
    [SerializeField] private Image CurrentHealthBar;
    
    private void Start()
    {
        TotalHealthBar.fillAmount = playerHealth.currenthealth/10 ;
    }
    private void Update()
    {
        CurrentHealthBar.fillAmount = playerHealth.currenthealth/10;
    }
}
