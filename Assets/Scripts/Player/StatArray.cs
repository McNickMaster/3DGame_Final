using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArray : MonoBehaviour
{

    public float damage;
    public float health;
    public float maxHealth;


    private void Awake()
    {
        health = maxHealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<StatArray>();
        if(atm != null)
        {
            atm.TakeDamage(damage);
        }
    }

    public void HealToFull()
    {
        health = maxHealth;
    }

}
