using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{

    public Slider Healthbar;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

	void Start ()
    {
        MaxHealth = 20;
        CurrentHealth = MaxHealth;

        Healthbar.value = CalculateHealth();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(5);
        }
    }
    public void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        Healthbar.value = CalculateHealth();
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die()
    {
        CurrentHealth = 0;
        print("You Died");
    }


}
