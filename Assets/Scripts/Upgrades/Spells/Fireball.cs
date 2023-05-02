using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{

    
    

    

    public override void Apply()
    {
        CharacterCombat.instance.moleSpell = this;
        base.ApplyUpgrade(this);

        Debug.Log("Fireball applied");
    }
}
