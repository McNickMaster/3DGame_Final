using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceOrb : Spell
{

    
    

    

    public override void Apply()
    {
        CharacterCombat.instance.moleSpell = this;
        base.ApplyUpgrade(this);

        Debug.Log("Iceorb applied");
    }
}
