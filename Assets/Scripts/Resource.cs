using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public Sprite resourceSprite;
    public float resourceAmount { get; set; }
    public Vector2 tilePosition;

    public void InitResource(float value)
    {
        resourceAmount = value;
        GetComponent<Image>().color = new Color(value, value, 0);
    }
}
