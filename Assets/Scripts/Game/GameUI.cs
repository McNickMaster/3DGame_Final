using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public static GameUI instance;
    public GameObject[] healthCells;
    public Animator portraitAnimator;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateHealthUI();

        if(Input.GetKeyDown(KeyCode.K))
        {
            Hurt();
        }
    }

    public void Hurt()
    {
        portraitAnimator.SetTrigger("hurt");
    }

    public void UpdateHealthUI()
    {
        
        for(int i = 0; i < PlayerMovement.instance.stats.maxHealth; i++)
        {
            healthCells[i].SetActive(true);
        }

        float healthDiff = PlayerMovement.instance.stats.maxHealth - PlayerMovement.instance.stats.health;
        for(int i = 0; i < healthDiff; i++)
        {
            healthCells[(int)(PlayerMovement.instance.stats.maxHealth - i - 1)].SetActive(false);
        }
    }

}
