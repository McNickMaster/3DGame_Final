using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrRat : Interactable
{
    public UpgradeSystem upgradeSystem;
    public GameObject upgradeUI;


    void Awake()
    {
        upgradeSystem.GenerateUpgrades();
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
        upgradeUI.SetActive(true);
        GameManager.instance.Pause();
        GameManager.instance.StartUIMode();
    }

    public void StopInteracting()
    {
        upgradeUI.SetActive(false);
        GameManager.instance.UnPause();
        GameManager.instance.StopUIMode();
    }


    
}
