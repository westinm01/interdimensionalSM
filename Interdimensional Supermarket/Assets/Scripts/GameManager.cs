using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasStarted;
    public EnemySpawner blueSpawner;
    public EnemySpawner redSpawner;
    public EnemySpawner yellowSpawner;
    public GameObject gameOverScreen;
    public MapSwitch switcher;
    public PowerupSpawner ps;
    private Alan alan;

    public void StartGame(){
        hasStarted = true;
        blueSpawner.InitializeEnemies();
        redSpawner.InitializeEnemies();
        yellowSpawner.InitializeEnemies();
        // Time.timeScale = 1;
        switcher.state = 0;
        switcher.timer = 0;
        switcher.startTime = switcher.initialStartTime;
        switcher.UpdateStates();
        ps.ClearPowerups();
        ps.ResetTimer();
        if (alan.heldItem != null){
            Destroy(alan.heldItem.gameObject);
        }
        alan.DisableCouponCounter();
        alan.Spawn();
    }
    public void EndGame(){
        hasStarted = false;
        blueSpawner.FreezeEnemies();
        redSpawner.FreezeEnemies();
        yellowSpawner.FreezeEnemies();
        gameOverScreen.SetActive(true);
        // Time.timeScale = 0;
    }

    void Start(){
        hasStarted = false;
        alan = GameObject.FindGameObjectWithTag("Player").GetComponent<Alan>();
    }
}
