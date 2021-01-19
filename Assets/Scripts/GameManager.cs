using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject uiResourceGrid;

    public int gridSize;
    public int numDeposits;
    public int depositSize;

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
            float resourceRatio = 1.0f;
            int row = Random.Range(0, gridSize - 1);
            int col = Random.Range(0, gridSize - 1);

            for (int layer = 0; layer < depositSize; layer++)
            {
                for (int j = row - layer; j <= row + layer; j++)
                {
                    for (int k = col - layer; k <= col + layer; k++)
                    {
                        if (j >= 0 && k >= 0 &&
                            j < gridSize && k < gridSize &&
                            resourceRatio > resourceGrid[j][k].resourceAmount)
                        {
                            resourceGrid[j][k].InitResource(resourceRatio);
                        }
                    }
                }

                resourceRatio *= 0.5f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
