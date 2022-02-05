using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzlinMovement : CustomerMovement
{
    private int xDirection;
    private int yDirection;
    public override void move(){
        Vector3 oldPos = gameObject.transform.position;
        float xPos = Mathf.Round(oldPos.x);
        float yPos = Mathf.Round(oldPos.y);

        if (xPos >= StaticBoard.numCols - 1){    // Doesnt move off right of map
            xDirection = -1;
        }
        else if (xPos <= 0){                     // Doesn't move off left of map
            xDirection = 1;
        }
        if (yPos >= 0){                          // Doesnt move off top of map
            yDirection = -1;
        }
        else if (yPos <= (StaticBoard.numRows - 1) * -1){// Doesn't move off bottom  of map
            yDirection = 1;
        }

        if (xDirection > 0){
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else{
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        Vector3 newPos = new Vector3(xPos + xDirection, yPos + yDirection);  // Add/Subtract 1 to xPos and yPos
        gameObject.transform.position = newPos;
    }

    protected override void Start(){
        base.Start();
        xDirection = 1;
        yDirection = 1;
    }
}
