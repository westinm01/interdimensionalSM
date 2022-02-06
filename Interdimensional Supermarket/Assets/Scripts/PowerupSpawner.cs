using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public float spawnSpeed;
    public Powerup power;
    public GameManager gm;
    public GameObject currMap;
    public Powerup spawnedSlushie;
    public Powerup spawnedBolt;
    public Powerup spawnedCoup;
    private float spawnTimer = 0;

    void Start(){
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer >= spawnSpeed){
            int randX = Random.Range(0, StaticBoard.numCols - 1);
            int randY = -Random.Range(0, StaticBoard.numRows - 1);
            switch (currMap.name){
                case "Blue":
                    if (spawnedSlushie == null){
                        spawnedSlushie = Instantiate(power, new Vector3(randX, randY), Quaternion.identity, currMap.transform);
                    }
                    break;
                case "Red":
                    if (spawnedBolt == null){
                        spawnedBolt = Instantiate(power, new Vector3(randX, randY), Quaternion.identity, currMap.transform);
                    }
                    break;
                case "Yellow":
                        if (spawnedCoup == null){
                            spawnedCoup = Instantiate(power, new Vector3(randX, randY), Quaternion.identity, currMap.transform);
                        }
                    break;
                default:
                    Debug.Log("Name not found: " + currMap.name);
                    break;
            }
            spawnTimer = 0;
        }
        else if (gm.hasStarted){
            spawnTimer += Time.deltaTime + Random.Range(0, 0.01f);
        }
    }
}
