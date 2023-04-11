using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArray : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat defence;

    void Awake ()
    {
        currentHealth = totalHealth;
    }

    void Update()
    {
        
    }


    public void TakeDamage (int damage)
    {
        damage -= defence.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }


    public virtual void Death ()
    {
        //player dies lol
    }
}
