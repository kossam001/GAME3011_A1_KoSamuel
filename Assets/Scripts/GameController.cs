﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public GameManager gameManager;
    public ResourceGrid resourceGrid;
    public SurfaceGrid surfaceGrid;

    private bool isOnScanMode = false;

    // Graphic Raycaster code from https://docs.unity3d.com/2017.3/Documentation/ScriptReference/UI.GraphicRaycaster.Raycast.html
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the left Mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Code from https://forum.unity.com/threads/graphicraycaster-raycast-on-nested-canvases.603436/
            PointerEventData m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.GetComponent<Resource>() && !isOnScanMode)
                {
                    Resource resource = result.gameObject.GetComponent<Resource>();
                    gameManager.AddScore((int)resource.resourceAmount);
                    Vector2 resourcePosition = resource.DecrementResource();

                    resourceGrid.DecrementSurroundingResourceTiles((int)resourcePosition.x, (int)resourcePosition.y);
                }

                SurfaceTile surface = result.gameObject.GetComponent<SurfaceTile>();
                if (surface != null && !isOnScanMode)
                {
                    surface.RemoveTile();

                    // There is a bug when it is possible to click two tiles simultaneously, using a break to fix it
                }
                else if (surface != null)
                {
                    surfaceGrid.RemoveSurroundingTiles((int)surface.tilePosition.x, (int)surface.tilePosition.y);

                    // There is a bug when it is possible to click two tiles simultaneously, using a break to fix it
                }
            }
        }
    }

    public void ChangeMode()
    {
        isOnScanMode = !isOnScanMode;
    }
}
