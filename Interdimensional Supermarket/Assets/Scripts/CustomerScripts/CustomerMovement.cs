using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{   
    public float moveFrequency; // How often the enemy moves
    // public float walkSpeed;     // How fast the enemy moves
    public int staticBoardPos;
    private Rigidbody2D rb;
    private float moveTimer;
    public virtual void move(){
        gameObject.transform.position += new Vector3(1,0);
    }
    public bool CheckOccupied(Vector2 pos){
        for (int i=0; i < StaticBoard.numEnemies; i++){
            if (StaticBoard.occupiedPositions[i,0] == pos.x && StaticBoard.occupiedPositions[i,1] == pos.y){
                return true;
            }
        }
        return false;
    }
    public virtual void UpdateBoardPos(){
        StaticBoard.occupiedPositions[staticBoardPos, 0] = (int)gameObject.transform.position.x;
        StaticBoard.occupiedPositions[staticBoardPos, 1] = (int)gameObject.transform.position.y;

        Debug.Log(gameObject.name + " pos: ");
        Debug.Log(StaticBoard.occupiedPositions[staticBoardPos, 0]);
        Debug.Log(StaticBoard.occupiedPositions[staticBoardPos, 1]);
    }

    protected virtual void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        moveTimer = 0;
    }


    void Update()
    {
        if (moveTimer > moveFrequency){
            move();
            UpdateBoardPos();
            moveTimer = 0;
        }
        else{
            moveTimer += Time.deltaTime;
        }
    }
}
