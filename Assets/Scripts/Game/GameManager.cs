using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
        
    public GameObject playerPrefab;
    public GameObject playerObjInstance;
    public PlayerMovement playerInstance;
    private int currentLevelIndex = 0;

    [SerializeField]
    public GameState gameState = GameState.Ready;

    public Level currentLevel;


    public List<Upgrade> currentUpgrades = new List<Upgrade>();

    private void Awake()
        {
            instance = this;
        }

        private void Update()
        {

            switch (gameState)
            {
                case GameState.Ready:
                {
                    gameState = GameState.Starting;
                    StopUIMode();
                    break;
                }

                case GameState.Starting:
                {
                    
                    Debug.Log("Game starting...");
                    
                    gameState = GameState.Running;
                    
                    
                    //playerObjInstance = Instantiate(playerPrefab, currentLevel.spawnpoint.position, Quaternion.identity);

                    
                    break;
                }
                case GameState.Running:
                {

                    if(Input.GetKeyDown(KeyCode.Escape))
                    {
                        QuitGame();
                    }

                    if(Input.GetKeyDown(KeyCode.R))
                    {
                        RestartGame();
                    }

                    

                    break;
                }
                case GameState.Win:
                {
                    
                    break;
                }
            }
        }

        public void PlayerDied()
        {
            gameState = GameState.Lost;
        }

        private void SwitchGameState(GameState newState)
        {
            gameState = newState;
        }

        public void Pause()
        {
            SwitchGameState(GameState.Paused);

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }

        public void UnPause()
        {
            SwitchGameState(GameState.Running);
            
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void StartUIMode()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            //PlayerWeapon.instance.can_activate = false;
            //disable player aiming and movement
        }

        public void StopUIMode()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //PlayerWeapon.instance.can_activate = true;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }

    public enum GameState
    {
        Ready, Paused, Running, Starting, Win, Lost
    }