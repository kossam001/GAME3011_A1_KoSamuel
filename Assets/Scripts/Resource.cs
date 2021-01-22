using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource : MonoBehaviour
{
    public Sprite resourceSprite;
    public float resourceAmount { get; set; }
    public float colourGradient { get; set; }
    public Vector2 tilePosition;

    public void SetPosition(Vector2 position)
    {
        tilePosition = position;
    }

    public void SetResource(float gradientValue, float resourceValue)
    {
        resourceAmount = resourceValue;
        colourGradient = gradientValue;

        GetComponent<Image>().color = new Color(gradientValue, gradientValue, 0);
    }

    public Vector2 DecrementResource()
    {
        resourceAmount = 0;
        colourGradient = 0;

        GetComponent<Image>().color = new Color(0, 0, 0);

        return tilePosition;
    }
}
