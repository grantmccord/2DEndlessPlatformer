using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health: MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int maxHealth = 100;

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        bool healthOverMax = health + amount > maxHealth;

        if (healthOverMax)
        {
            this.health = maxHealth;
        }
        else
        {
            this.health += amount;
        }
        
    }

    private void Death()
    {
        Debug.Log("You died");
        Destroy(gameObject);
    }
}
