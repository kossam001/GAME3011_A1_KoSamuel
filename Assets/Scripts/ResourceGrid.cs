using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGrid : MonoBehaviour
{
    public GameObject tilePrefab;

    public int gridSize;
    public int numDeposits;
    public int depositSize;
    public int maxResourceAmount;

    private List<List<Resource>> resourceGrid;

    // Start is called before the first frame update
    void Awake()
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
                resourceTile.transform.SetParent(transform);

                resourceRow.Add(resourceTile.GetComponent<Resource>());
            }

            resourceGrid.Add(resourceRow);
        }
    }

    public void SetResourceTiles()
    {
        // Reset Grid
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                resourceGrid[row][col].SetPosition(new Vector2(row, col));
                resourceGrid[row][col].SetResource(0, 0);
            }
        }

        for (int i = 0; i < numDeposits; i++)
        {
            int row = Random.Range(0, gridSize - 1);
            int col = Random.Range(0, gridSize - 1);

            SetSurroundingResourceTiles(row, col);
        }
    }

    public void SetSurroundingResourceTiles(int row, int col)
    {
        float gradientRatio = 1.0f;
        float resourceRatio = 1.0f;

        for (int layer = 0; layer < depositSize; layer++)
        {
            for (int j = row - layer; j <= row + layer; j++)
            {
                for (int k = col - layer; k <= col + layer; k++)
                {
                    if (j >= 0 && k >= 0 &&
                        j < gridSize && k < gridSize &&
                        gradientRatio > resourceGrid[j][k].colourGradient)
                    {
                        resourceGrid[j][k].SetPosition(new Vector2(j, k));
                        resourceGrid[j][k].SetResource(gradientRatio, maxResourceAmount * resourceRatio);
                    }
                }
            }

            resourceRatio *= 0.5f;
            gradientRatio *= 0.5f;
        }
    }

    public void DecrementSurroundingResourceTiles(int row, int col)
    {
        float gradientRatio = 0.5f;
        float resourceRatio = 0.5f;

        for (int j = row - depositSize; j <= row + depositSize; j++)
        {
            for (int k = col - depositSize; k <= col + depositSize; k++)
            {
                if (j >= 0 && k >= 0 &&
                    j < gridSize && k < gridSize)
                {
                    resourceGrid[j][k].SetResource(gradientRatio * resourceGrid[j][k].colourGradient, resourceRatio * resourceGrid[j][k].resourceAmount);
                }
            }
        }
    }
}
