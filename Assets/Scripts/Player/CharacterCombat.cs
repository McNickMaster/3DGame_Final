using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public static CharacterCombat instance;
    public GameObject Wand;
    public Transform firepoint;
    public Animator anim;
    public bool CanAttack = true, CanCast = true;
    public float AttackCooldown = 1.0f;
    public bool IsAttacking = false, IsCasting = false;

    public Spell moleSpell;

    void Awake()
    {
        instance = this;
    }
    
    void Update()
    {
        if(moleSpell == null)
        {
            CanCast = false;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                WandAttack();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (CanCast)
            {
                CastSpell();
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

    public void CastSpell()
    {
        GameObject spellObject;
        Projectile projectile;
        spellObject = Instantiate(moleSpell.spellObject, firepoint.position, PlayerMovement.instance.orientation.rotation);

        projectile = spellObject.GetComponent<Projectile>();

        projectile.damage = moleSpell.damage;
        CanCast = false;
        StartSpellCooldown();
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

    //Spell Cooldown
    void StartSpellCooldown()
    {
        StartCoroutine(ResetSpellBool());
    }


    IEnumerator ResetSpellBool()
    {
        yield return new WaitForSeconds(moleSpell.spell_cooldown);
        IsCasting = false;
        CanCast = true;
        //anim.SetBool("casting", false);
    }
}