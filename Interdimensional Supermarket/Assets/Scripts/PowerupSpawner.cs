using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public float spawnSpeed;
    public Powerup power;
    public GameManager gm;
    private Powerup spawnedP;
    private float spawnTimer = 0;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float willSpawn = Random.Range(spawnTimer, spawnSpeed);
        if (spawnTimer >= spawnSpeed){
            // if (spawnedP == null){          // Doesn't spawn an item if already on board.
                int randX = Random.Range(0, StaticBoard.numCols - 1);
                int randY = -Random.Range(0, StaticBoard.numRows - 1);
                spawnedP = Instantiate(power, new Vector3(randX, randY), Quaternion.identity);
                spawnTimer = 0;
            // }
        }
        else if (gm.hasStarted){
            spawnTimer += Time.deltaTime;
        }
    }
}
