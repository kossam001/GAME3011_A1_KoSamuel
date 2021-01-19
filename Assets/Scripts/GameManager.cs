using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject uiResourceGrid;

    public int gridSize;

    List<List<Resource>> resourceGrid;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        resourceGrid = new List<List<Resource>>();

        // Setup Grid
        for (int row = 0; row < gridSize; row++)
        {
            List<Resource> resourceRow = new List<Resource>();

            for (int col = 0; col < gridSize; col++)
            {
                GameObject resourceTile = Instantiate(tilePrefab);
                resourceTile.transform.SetParent(uiResourceGrid.transform);

                resourceRow.Add(resourceTile.GetComponent<Resource>());
            }

            resourceGrid.Add(resourceRow);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
