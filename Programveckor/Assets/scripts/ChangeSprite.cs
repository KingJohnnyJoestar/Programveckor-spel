using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public List<Sprite> dimensionSprites;
    public void changeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = dimensionSprites[DimensionChanger.dimension];
    }
}
