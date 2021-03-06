﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurfaceTile : MonoBehaviour
{
    public Vector2 tilePosition;

    public Vector2 RemoveTile()
    {
        // Grid layout automatically rearranges layout if object is disabled
        // Changing alpha so that raytrace is still valid
        GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 0); 
        return tilePosition;
    }

    public void ResetTile()
    {
        GetComponent<Image>().color = new Color(0.2f, 0.2f, 0.2f, 1f);
    }

    public void SetPosition(Vector2 position)
    {
        tilePosition = position;
    }
}
