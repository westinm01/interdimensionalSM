using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBoard : MonoBehaviour
{
    public static int numRows = 8;
    public static int numCols = 8;

    public static int[,] occupiedPositions = {{-1, -1}, {-1, -1}, {-1, -1}, {-1, -1}}; // index 0: Pokoon
                                                                                        // index 1: Octole
                                                                                        // index 2: Fuzlin
                                                                                        // index 3: EyeGuy
    public static int numEnemies;
    public static int highScore;
    public static int[] AlanPos = {-1, -1};
}
