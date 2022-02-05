using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGuyMovement : CustomerMovement
{
    public override void move(){
        int randX = Random.Range(0, StaticBoard.numCols);
        int randY = Random.Range(0, -StaticBoard.numRows);
        gameObject.transform.position = new Vector3(randX, randY);
    }
}
