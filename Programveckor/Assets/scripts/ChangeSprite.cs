using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : DimensionChange
{
    public List<Sprite> dimensionSprites;
    public override void dimensionChange()
    {
        GetComponent<SpriteRenderer>().sprite = dimensionSprites[DimensionChanger.dimension];
    }
}
