using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArray : MonoBehaviour
{
    public static StatArray instance;
    public int damage;
    public int health;

    private void Awake()
    {
        instance = this;
    }
    public void TakeDamage(int amount)
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
}
