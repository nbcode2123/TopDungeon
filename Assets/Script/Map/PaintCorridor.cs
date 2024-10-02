using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PaintCorridor : PaintTilemap
{

    // Start is called before the first frame update
    public void PaintCorridorPosition(HashSet<Vector2Int> corridorPosition)

    {
        foreach (var position in corridorPosition)
        {
            // PaintSingleCorridor(position);
        }
    }


}
