using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public List<Level> possibleLevels;
    public Level stemLevel;
    public Level endCap;

    public Level currentLevelBranch;
    public Level lastLevelBranch;

    public int room_amount = 5;
    public float room_size = 15;


    void Awake()
    {
        currentLevelBranch = stemLevel;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateMap()
    {
        Transform roomSpawn;
        Level nextRoom;

        string lastDir = "D";

        for(int i = 0; i < room_amount; i++)
        {
            

            roomSpawn = currentLevelBranch.AttachPoints[Random.Range(0, currentLevelBranch.AttachPoints.Length)].transform;

            string roomBranchDir = roomSpawn.gameObject.name;

            if(roomBranchDir == lastDir)
            {
                roomSpawn = currentLevelBranch.AttachPoints[Random.Range(0, currentLevelBranch.AttachPoints.Length)].transform;
                roomBranchDir = roomSpawn.gameObject.name;
            }

            lastDir = roomBranchDir;

            do
            {
                nextRoom = possibleLevels[Random.Range(0, possibleLevels.Count)];
            }
            while(!ListContains(nextRoom.AttachPoints, roomBranchDir));

            

            Vector3 roomSpawnOffset = Vector3.zero;

            if(roomBranchDir.Equals("U"))
            {
                roomSpawnOffset += Vector3.forward * room_size;
            } else
            if(roomBranchDir.Equals("D"))
            {
                roomSpawnOffset += Vector3.back * room_size;
            } else
            if(roomBranchDir.Equals("L"))
            {
                roomSpawnOffset += Vector3.left * room_size;
            } else
            if(roomBranchDir.Equals("R"))
            {
                roomSpawnOffset += Vector3.right * room_size;
            }

            if(Physics.BoxCast(roomSpawnOffset + roomSpawn.gameObject.transform.position + Vector3.up * 5, Vector3.one, Vector3.down))
            {
                i--;
                Debug.Log("something collided");
            } else
            {
                lastLevelBranch = currentLevelBranch;
                currentLevelBranch = Instantiate(nextRoom, roomSpawnOffset + roomSpawn.gameObject.transform.position, Quaternion.identity).GetComponent<Level>();
            }

            SpawnEndcaps(lastLevelBranch);

            
            

        }
    }

    void SpawnEndcaps(Level level)
    {
        Vector3 endcapPos = Vector3.zero;
        float endcapAngle = 0;
        
        for(int i = 0; i < level.AttachPoints.Length; i++)
        {
            Debug.Log(level.AttachPoints[i].name);
            switch(level.AttachPoints[i].name)
            {
                case ("U"):
                {
                    endcapPos = level.gameObject.transform.position + Vector3.forward * room_size * 1.5f;
                    endcapAngle = 0;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("D"):
                {
                    endcapPos = level.gameObject.transform.position + Vector3.back * room_size * 1.5f;
                    endcapAngle = 180;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("L"):
                {
                    endcapPos = level.gameObject.transform.position + Vector3.left * room_size * 1.5f;
                    endcapAngle = -90;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("R"):
                {
                    endcapPos = level.gameObject.transform.position + Vector3.right * room_size * 1.5f;
                    endcapAngle = 90;
                    
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
            
            }
        }
    }

    void SpawnEndcap(Vector3 pos, float endcapAngle)
    {
        Debug.Log("spawning endcap");
       
        if(!(Physics.BoxCast(pos + Vector3.down, new Vector3(0.1f, 0.1f, 0.1f), Vector3.up)))
        {
            Instantiate(endCap, pos, Quaternion.AngleAxis(endcapAngle, Vector3.up));
        } else 
        {
            Debug.Log("spawning endcap failed");
        }
    }


    bool ListContains(GameObject[] list, string s)
    {
        string switched_s = "";

        if(s == "U")
        {
            switched_s = "D";
        }
        if(s == "D")
        {
            switched_s = "U";
        }
        if(s == "R")
        {
            switched_s = "L";
        }
        if(s == "L")
        {
            switched_s = "R";
        }

        
        foreach (GameObject obj in list)
        {
            if (obj.name.ToLower().Contains(switched_s.ToLower()))
            {
                return true;
            }
        }

        return false;
    }


}
