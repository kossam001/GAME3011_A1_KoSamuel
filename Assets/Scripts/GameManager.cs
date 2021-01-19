using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject uiResourceGrid;

    public int gridSize;
    public int numDeposits;

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

        SetResourceTiles();
    }

    private void SetResourceTiles()
    {
        for (int i = 0; i < numDeposits; i++)
        {
            int row = Random.Range(0, gridSize - 1);
            int col = Random.Range(0, gridSize - 1);

            resourceGrid[row][col].InitResource(1);

            for (int j = row - 1; j <= row + 1; j++)
            {
                for (int k = col - 1; k <= col + 1; k++)
                {
                    float resourceValue = 0.5f;

                    if (j >= 0 && k >= 0 && resourceValue > resourceGrid[j][k].resourceAmount)
                    {
                        resourceGrid[j][k].InitResource(resourceValue);
                    }
                }
            }

            for (int j = row - 2; j <= row + 2; j++)
            {
                for (int k = col - 2; k <= col + 2; k++)
                {
                    float resourceValue = 0.25f;

                    if (j >= 0 && k >= 0 && resourceValue > resourceGrid[j][k].resourceAmount)
                    {
                        resourceGrid[j][k].InitResource(resourceValue);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
