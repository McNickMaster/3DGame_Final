using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whetstone : Upgrade
{

    [Header("Upgrade Config")]
    public float dmgMod = 1.5f;

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
        StatArray.instance.damage = (int)(StatArray.instance.damage * dmgMod);
    }
}
