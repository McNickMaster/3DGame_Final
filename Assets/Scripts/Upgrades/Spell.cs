using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : Upgrade
{
    

    public float spell_cooldown = 1;
    public float damage = 20;
    public GameObject spellObject;
}
