using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : Upgrade
{

    [Header("Upgrade Config")]
    public float maxHealthMod = 2f;

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
        PlayerMovement.instance.stats.HealToFull();
    }
}
