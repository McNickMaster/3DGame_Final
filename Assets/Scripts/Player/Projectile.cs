using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float damage = 0;
    public float movespeed = 1;

    public GameObject fireballExplosionEffect;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(0, 0, 1 * movespeed), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(new Vector3(0, 0, 1 * movespeed), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        Instantiate(fireballExplosionEffect, transform.position, Quaternion.identity, null);

        if(other.gameObject.layer.Equals(13))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }
}
