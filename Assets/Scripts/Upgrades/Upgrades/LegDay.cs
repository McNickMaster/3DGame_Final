using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegDay : Upgrade
{

    [Header("LegDay Config")]
    public float speedMod = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Apply();
        }
    }

    public override void Apply()
    {
        base.ApplyUpgrade(this);
        GameManager.instance.playerInstance.movementSpeedMod = speedMod;
    }
}
