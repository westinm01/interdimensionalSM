using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public float spawnSpeed;
    public Powerup power;
    private Powerup spawnedP;
    private float spawnTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer >= spawnSpeed){
            if (spawnedP == null){          // Doesn't spawn an item if already on board.
                int randX = Random.Range(0, StaticBoard.numCols - 1);
                int randY = -Random.Range(0, StaticBoard.numRows - 1);
                spawnedP = Instantiate(power, new Vector3(randX, randY), Quaternion.identity);
                spawnTimer = 0;
            }
        }
        else{
            spawnTimer += Time.deltaTime;
        }
    }
}
