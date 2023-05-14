using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public bool cutsceneDone = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cutsceneDone)
        {
            LoadGame();
        }
    }


    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
}
