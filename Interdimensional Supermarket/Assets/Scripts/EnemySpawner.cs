using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Pokoon;
    public GameObject Octole;
    public GameObject Fuzlin;
    public GameObject EyeGuy;
    public GameObject Coin;
    public GameObject[] enemies;    // Initialize to 1 of each kind of enemy
    private GameObject gameCoin;
    // private GameManager gm;

    /*
        Checks if there is an existing enemy on the input position
    */
    public bool CheckPositionConflict(Vector2 pos){
        foreach (GameObject enemy in enemies){
            if (enemy != null){
                Vector3 enemyPos = enemy.transform.position;
                if (enemyPos.x == pos.x && enemyPos.y == pos.y){
                    return true;
                }
            }
        }
        return false;
    }

    public void ClearEnemies(){
        foreach (GameObject enemy in enemies){
            if (enemy != null){
                Destroy(enemy.gameObject);
            }
        }
        Destroy(gameCoin.gameObject);
    }

    public void InitializeEnemies(){
        int randX = 0;
        int randY = 0;
        bool hasConflict;
        GameObject enemy;
        for (int i=0; i < 4; i++){  // For each type of enemy
            hasConflict = true;
            while (hasConflict){
                randX = Random.Range(0, StaticBoard.numCols - 1);
                randY = -Random.Range(0, StaticBoard.numRows - 1);
                hasConflict = CheckPositionConflict(new Vector2(randX, randY));
            }

            switch(i){
                case 0:
                    enemy = Pokoon;
                    break;
                case 1:
                    enemy = Octole;
                    break;
                case 2:
                    enemy = Fuzlin;
                    break;
                case 3:
                    enemy = EyeGuy;
                    break;
                default:
                    enemy = Pokoon;
                    Debug.Log("Switch case can't be found");
                    break;
            }
            enemies[i] = Instantiate(enemy, new Vector3(randX, randY), Quaternion.identity, transform.parent);
        }


        randX = Random.Range(0, StaticBoard.numCols - 1);
        randY = -Random.Range(0, StaticBoard.numRows - 1);
        gameCoin = Instantiate(Coin, new Vector3(randX, randY), Quaternion.identity, transform.parent);
    }
    void Start()
    {
        // gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
}
