using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<Level> possibleLevels;
    public Level stemLevel;

    private Level currentLevelBranch;

    public int room_amount = 5;


    void Awake()
    {
        currentLevelBranch = stemLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMap()
    {
        Transform roomSpawn;
        for(int i = 0; i < room_amount; i++)
        {
        
            roomSpawn = currentLevelBranch.AttachPoints[Random.Range(0, currentLevelBranch.AttachPoints.Length)].transform;
            



        }
    }
}
