using System.Collections.Generic;
using UnityEngine;

namespace Script.Map
{
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
}
