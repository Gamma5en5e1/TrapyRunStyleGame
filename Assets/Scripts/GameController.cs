using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class GameController : MonoBehaviour
{
    public EnemyWaveSpawner MainSpawner;
    public bool GameStarted;
    public bool GameEnded;
    private bool used;
    public bool Lose;

    public GameObject LoseMenu;
    public GameObject WinMenu;
    public GameObject Obstacle;
    private void Awake()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }
    public void UseSpawner()
    {
        MainSpawner.SpawnMore();
    }
    public void CreateObstacle(Vector3 pos)
    {
        Instantiate(Obstacle, new Vector3(pos.x,0,pos.z), Quaternion.identity);

    }

    private void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            GameStarted = true;
        }



        if (GameStarted)
        {
            if (!used)
            {
                UseSpawner();
            }
        }
            


        if(Lose)
        {
            Time.timeScale = 0f;
            LoseMenu.SetActive(true);
        }

        if(GameEnded)
        {
            WinMenu.SetActive(true);
        }

    }
}
