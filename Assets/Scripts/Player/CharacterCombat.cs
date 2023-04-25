using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public GameObject Wand;
    public Animator anim;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool IsAttacking = false;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                WandAttack();
            }
        }
    }

    //Attack Properties
    public void WandAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        anim.SetBool("attacking", true);
        StartCoroutine(ResetAttackCooldown());
    }

    //Attack Cooldown
    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
        anim.SetBool("attacking", false);
    }
}