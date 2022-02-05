using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokoonMovement : CustomerMovement
{
    private int direction;
    public override void move(){
        Vector3 oldPos = gameObject.transform.position;
        if (gameObject.transform.position.x >= StaticBoard.numRows - 1){
            direction = -1;
        }
        else if (gameObject.transform.position.x <= 0){
            direction = 1;
        }

        if (direction > 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        Vector3 newPos = new Vector3(Mathf.Round(oldPos.x) + direction, oldPos.y);
        gameObject.transform.position = newPos;
        // gameObject.transform.position += new Vector3(direction, 0);
        // rb.velocity = new Vector2(1, 0);
    }

    protected override void Start(){
        base.Start();
        direction = 1;
    }
}
