using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokoonMovement : CustomerMovement
{
    private int direction;
    public override void move(){
        Vector3 oldPos = gameObject.transform.position;
        float xPos = Mathf.Round(oldPos.x);
        if (gameObject.transform.position.x >= StaticBoard.numCols - 1){    // Doesnt move off right of map
            direction = -1;
        }
        else if (gameObject.transform.position.x <= 0){                     // Doesn't move off left of map
            direction = 1;
        }

        if (direction > 0){
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        Vector3 newPos = new Vector3(xPos + direction, oldPos.y);  // Add/Subtract 1 to xPos, round to nearest whole
        gameObject.transform.position = newPos;
        UpdateBoardPos();
    }

    protected override void Start(){
        base.Start();
        direction = 1;
    }
}
