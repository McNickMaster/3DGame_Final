using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public CharacterCombat cc;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && cc.IsAttacking)
        {
            Debug.Log("player hit " + other.name);
        }
    }
}
