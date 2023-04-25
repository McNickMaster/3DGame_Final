using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Upgrade
{

    [Header("Upgrade Config")]
    public float damage = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Apply()
    {
        base.ApplyUpgrade(this);
        //CharacterCombat.instance.secondarySkill = SecondarySkills.Fireball;
    }
}
