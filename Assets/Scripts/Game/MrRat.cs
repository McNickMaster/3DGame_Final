using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrRat : Interactable
{
    public static MrRat instance;
    private UpgradeSystem upgradeSystem;
    private GameObject upgradeUI;

    private bool upgradeTaken = false;


    void Awake()
    {
        instance = this;
        upgradeUI = GameManager.instance.upgradeUI;
        upgradeSystem = GameManager.instance.upgradeSystem;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if(upgradeTaken)
        {

        } else {
            
            upgradeSystem.GenerateUpgrades();
            upgradeUI.SetActive(true);
            GameManager.instance.Pause();
            GameManager.instance.StartUIMode();

            upgradeTaken = true;
        }
    }

    public void StopInteracting()
    {
        upgradeUI.SetActive(false);
        GameManager.instance.UnPause();
        GameManager.instance.StopUIMode();
    }


    
}
