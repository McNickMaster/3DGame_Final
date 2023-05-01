using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public List<Level> possibleLevels;

    public List<Level> L_levels;
    public List<Level> R_levels;
    public List<Level> U_levels;
    public List<Level> D_levels;


    public Level stemLevel;
    public Level endCap;

    public Level currentLevelBranch;
    public Level lastLevelBranch;

    public List<Vector3Int> usedPositions;

    public int room_amount = 5;
    public float room_size = 15;

    public GameObject door;


    void Awake()
    {
        instance = this;
        currentLevelBranch = stemLevel;

        usedPositions.Add(new Vector3Int((int)stemLevel.transform.position.x, (int)stemLevel.transform.position.y, (int)stemLevel.transform.position.z));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap()
    {
        Transform roomSpawn;
        Level nextRoom = null;

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


            //change each level name to match the attachpoints. will remove the neeed to have a loop within the loop, and possible fix the crash problem
            
            /*
            int c = 0;
            do
            {
                nextRoom = possibleLevels[Random.Range(0, possibleLevels.Count)];
                c++;   
            }
            while((!RoomNameHasPoint(nextRoom.name, roomBranchDir)) && c < possibleLevels.Count);
            */
            /*
            for(int j = 0; j < possibleLevels.Count; j++)
            {
                nextRoom = possibleLevels[Random.Range(0, possibleLevels.Count)];
                if(RoomNameHasPoint(nextRoom.name, roomBranchDir))
                {
                    break;
                }

            }
            */

            switch(roomBranchDir)
            {
                case ("U"):
                {
                    nextRoom = D_levels[Random.Range(0, D_levels.Count)];
                    break;
                }
                case ("D"):
                {
                    nextRoom = U_levels[Random.Range(0, U_levels.Count)];
                    break;
                }
                case ("L"):
                {
                    nextRoom = R_levels[Random.Range(0, R_levels.Count)];
                    break;
                }
                case ("R"):
                {
                    nextRoom = L_levels[Random.Range(0, L_levels.Count)];
                    break;
                }

            }

            


            

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

/*
            int c = 0;
            if(Physics.BoxCast(roomSpawnOffset + roomSpawn.gameObject.transform.position + Vector3.up * 5, Vector3.one, Vector3.down) && c < room_amount * 2)
            {
                i--;
                c++;
//                Debug.Log("something collided");
            } else
            {
                
                lastLevelBranch = currentLevelBranch;
                currentLevelBranch = Instantiate(nextRoom, roomSpawnOffset + roomSpawn.gameObject.transform.position, Quaternion.identity).GetComponent<Level>();
//                Destroy(roomSpawn.gameObject);
            }
            */

            Vector3 pos = (roomSpawnOffset + roomSpawn.gameObject.transform.position);
            Vector3Int posInt = new Vector3Int((int)pos.x, (int)pos.y, (int)pos.z);
            if(usedPositions.Contains(posInt))
            {
                
            } else 
            {
                
                lastLevelBranch = currentLevelBranch;
                currentLevelBranch = Instantiate(nextRoom, pos, Quaternion.identity).GetComponent<Level>();
                usedPositions.Add(posInt);
            }

            //SpawnEndcaps(lastLevelBranch);

            
            

        }

        SpawnDoor();

        SpawnEndcapsOnEmptyPoints(GetEmptyAttachPoints());
    }

    void SpawnDoor()
    {
        Instantiate(door, currentLevelBranch.transform.position, Quaternion.identity);
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
                    endcapPos = level.gameObject.transform.position + Vector3.forward * room_size * 2;
                    endcapAngle = 0;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("D"):
                {
                    endcapPos = level.gameObject.transform.position + Vector3.back * room_size * 2;
                    endcapAngle = 180;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("L"):
                {
                    endcapPos = level.gameObject.transform.position + Vector3.left * room_size *2 ;
                    endcapAngle = -90;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("R"):
                {
                    endcapPos = level.gameObject.transform.position + Vector3.right * room_size * 2;
                    endcapAngle = 90;
                    
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
            
            }
        }
    }

    GameObject[] GetEmptyAttachPoints()
    {
        return GameObject.FindGameObjectsWithTag("AttachPoint");
    }

    void SpawnEndcapsOnEmptyPoints(GameObject[] points)
    {
        
        Vector3 endcapPos = Vector3.zero;
        float endcapAngle = 0;
        
        for(int i = 0; i < points.Length; i++)
        {
            //Debug.Log(points[i].name);
            switch(points[i].name)
            {
                case ("U"):
                {
                    endcapPos = points[i].transform.position + Vector3.forward * room_size;
                    endcapAngle = 0;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("D"):
                {
                    endcapPos =  points[i].transform.position + Vector3.back * room_size;
                    endcapAngle = 180;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("L"):
                {
                    endcapPos =  points[i].transform.position + Vector3.left * room_size;
                    endcapAngle = -90;
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
                case ("R"):
                {
                    endcapPos =  points[i].transform.position + Vector3.right * room_size;
                    endcapAngle = 90;
                    
                    SpawnEndcap(endcapPos, endcapAngle);
                    break;
                }
            
            }
        }
    }

    void SpawnEndcap(Vector3 pos, float endcapAngle)
    {
        //Debug.Log("spawning endcap");
       
        if(!(Physics.BoxCast(pos + Vector3.down, new Vector3(0.1f, 0.1f, 0.1f), Vector3.up)))
        {
            Instantiate(endCap, pos, Quaternion.AngleAxis(endcapAngle, Vector3.up));
        } else 
        {
            //Debug.Log("spawning endcap failed");
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

    bool RoomNameHasPoint(string name, string s)
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

       
        if (name.ToLower().Contains(switched_s.ToLower()))
        {
            return true;
        }

        return false;
    }



}
