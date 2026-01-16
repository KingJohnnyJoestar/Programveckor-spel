using System.Collections.Generic;
using UnityEngine;

public class ColorDimensionChange : DimensionChange
{
    public List<Color32> dimensionColors;
    public override void dimensionChange()
    {
        GetComponent<SpriteRenderer>().color = dimensionColors[DimensionChanger.dimension];
    }
}
