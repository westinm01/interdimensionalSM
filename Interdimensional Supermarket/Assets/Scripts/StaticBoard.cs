using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBoard : MonoBehaviour
{
    public static int numRows = 8;
    public static int numCols = 8;

    public static int[,] occupiedPositions = {{-1, -1}, {-1, -1}, {-1, -1}, {-1, -1}};
}
