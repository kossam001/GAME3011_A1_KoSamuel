using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public GameManager gameManager;
    public ResourceGrid resourceGrid;
    public SurfaceGrid surfaceGrid;
    public ModeButton scanButton;

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

            // Track raycast hit count so multiple tiles are not hit
            int resourceHitCount = 0;
            int surfaceHitCount = 0;

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                // Extract Mode
                if (result.gameObject.GetComponent<Resource>() && !isOnScanMode && resourceHitCount <= 0 && scanButton.extractLimit > 0)
                {
                    Resource resource = result.gameObject.GetComponent<Resource>();
                    gameManager.AddScore((int)resource.resourceAmount);
                    Vector2 resourcePosition = resource.DecrementResource();

                    resourceGrid.DecrementSurroundingResourceTiles((int)resourcePosition.x, (int)resourcePosition.y);

                    resourceHitCount++;
                    scanButton.DecreaseUsage();

                    if (scanButton.extractLimit <= 0)
                    {
                        gameManager.FinishGame();
                    }
                }

                // Scan Mode
                SurfaceTile surface = result.gameObject.GetComponent<SurfaceTile>();
                if (surfaceHitCount <= 0 && surface != null && scanButton.extractLimit > 0)
                {
                    if (!isOnScanMode)
                    {
                        surface.RemoveTile();
                    }
                    else if (scanButton.scanLimit > 0)
                    {
                        surfaceGrid.RemoveSurroundingTiles((int)surface.tilePosition.x, (int)surface.tilePosition.y);

                        scanButton.DecreaseUsage();

                        if (scanButton.scanLimit <= 0)
                        {
                            scanButton.ChangeMode();
                            scanButton.gameObject.GetComponent<Button>().interactable = false;
                            isOnScanMode = false;
                            break; // Without break, will consume an extract
                        }
                    }

                    surfaceHitCount++;
                }
            }
        }
    }

    public void ChangeMode()
    {
        if (scanButton.scanLimit <= 0) return;

        isOnScanMode = !isOnScanMode;
    }
}
