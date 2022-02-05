using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoleMovement : CustomerMovement
{
    private int direction;
    public override void move(){
        Vector3 oldPos = gameObject.transform.position;
        if (gameObject.transform.position.y >= 0){    // Doesnt move off top of map
            direction = -1;
        }
        else if (gameObject.transform.position.y <= (StaticBoard.numRows - 1) * -1){                     // Doesn't move off bottom of map
            direction = 1;
        }

        // if (direction > 0){
        //     transform.rotation = Quaternion.Euler(0, 180, 0);
        // }
        // else{
        //     transform.rotation = Quaternion.Euler(0, 0, 0);
        // }

        Vector3 newPos = new Vector3(oldPos.x, Mathf.Round(oldPos.y) + direction );  // Add/Subtract 1 to xPos, round to nearest whole
        gameObject.transform.position = newPos;
    }

    protected override void Start(){
        base.Start();
        direction = 1;
    }
}
