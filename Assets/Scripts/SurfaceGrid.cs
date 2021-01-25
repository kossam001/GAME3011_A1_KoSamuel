using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceGrid : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridSize;
    public int scanSize;

    private List<List<SurfaceTile>> surfaceGrid;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        surfaceGrid = new List<List<SurfaceTile>>();

        // Setup Grid
        for (int row = 0; row < gridSize; row++)
        {
            List<SurfaceTile> surfaceRow = new List<SurfaceTile>();

            for (int col = 0; col < gridSize; col++)
            {
                GameObject surfaceTile = Instantiate(tilePrefab);
                surfaceTile.transform.SetParent(transform);
                surfaceTile.GetComponent<SurfaceTile>().SetPosition(new Vector2(row, col));

                surfaceRow.Add(surfaceTile.GetComponent<SurfaceTile>());
            }

            surfaceGrid.Add(surfaceRow);
        }
    }

    public void RemoveSurroundingTiles(int row, int col)
    {
        for (int j = row - scanSize; j <= row + scanSize; j++)
        {
            for (int k = col - scanSize; k <= col + scanSize; k++)
            {
                if (j >= 0 && k >= 0 &&
                    j < gridSize && k < gridSize)
                {
                    surfaceGrid[j][k].RemoveTile();
                }
            }
        }
    }
}
