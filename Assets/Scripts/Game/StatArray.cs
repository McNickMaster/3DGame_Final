using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArray : MonoBehaviour
{
    public static StatArray instance;
    public float totalHealth = 100;
    public float currentHealth { get; private set; }

    public Stat damage;
    public Stat defence;

    void Awake ()
    {
        instance = this;
        currentHealth = totalHealth;
    }

    void Update()
    {
        
    }


    public void TakeDamage (float damage)
    {
        damage -= defence.GetValue();
        damage = Mathf.Clamp(damage, 0, float.MaxValue);

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
