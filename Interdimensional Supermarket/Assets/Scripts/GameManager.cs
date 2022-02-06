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
    private Alan alan;

    public void StartGame(){
        hasStarted = true;
        blueSpawner.InitializeEnemies();
        redSpawner.InitializeEnemies();
        yellowSpawner.InitializeEnemies();
        Time.timeScale = 1;
        switcher.state = 0;
        switcher.timer = 0;
        switcher.UpdateStates();
        alan.Spawn();
    }
    public void EndGame(){
        hasStarted = false;
        blueSpawner.ClearEnemies();
        redSpawner.ClearEnemies();
        yellowSpawner.ClearEnemies();
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void Start(){
        hasStarted = false;
        alan = GameObject.FindGameObjectWithTag("Player").GetComponent<Alan>();
    }
}
