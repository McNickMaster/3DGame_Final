using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [Header("Upgrade Base Info")]
    public string upgrade_name;
    public string upgrade_desc;


   


    public abstract void Apply();
    public void ApplyUpgrade(Upgrade upgrade)
    {
        GameManager.instance.currentUpgrades.Add(upgrade);
    }
}
