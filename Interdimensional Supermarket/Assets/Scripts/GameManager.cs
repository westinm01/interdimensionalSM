using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasStarted;
    public EnemySpawner blueSpawner;
    public EnemySpawner redSpawner;
    public EnemySpawner yellowSpawner;

    public void StartGame(){
        hasStarted = true;
        blueSpawner.InitializeEnemies();
        redSpawner.InitializeEnemies();
        yellowSpawner.InitializeEnemies();
    }
    public void EndGame(){
        hasStarted = false;
    }
    void Start(){
        hasStarted = false;
    }
}
