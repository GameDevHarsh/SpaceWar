using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldHealthBar : MonoBehaviour
{
    [SerializeField] private ShieldHealth playerHealth;
    [SerializeField] private ShieldHealth currenthealth;
    [SerializeField] private Image TotalHealthBar;
    [SerializeField] private Image CurrentHealthBar;

    private void Start()
    {
        TotalHealthBar.fillAmount = playerHealth.ShieldCurrentHealth / 10;
    }
    private void Update()
    {
        CurrentHealthBar.fillAmount = playerHealth.ShieldCurrentHealth / 10;
    }
}
