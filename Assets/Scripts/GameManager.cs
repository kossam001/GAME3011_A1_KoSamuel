using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameController gameController;

    public GameObject resourceCanvas;
    public GameObject resultsPanel;
    public ModeButton scanButton;

    public TMP_Text uiScore;

    // Digging usage
    public TMP_Text scanLimitLabel;
    public TMP_Text extractLmitLabel;

    public int maxScanLimit = 6;
    public int maxExtractLimit = 3;

    public int scanLimit;
    public int extractLimit;

    // Grids
    public ResourceGrid resourceGrid;
    public SurfaceGrid surfaceGrid;

    private int score;

    public void Setup()
    {
        // Reset the usage count
        scanLimit = maxScanLimit;
        extractLimit = maxExtractLimit;

        scanLimitLabel.text = scanLimit.ToString();
        extractLmitLabel.text = extractLimit.ToString();

        // Reset Toggle button
        scanButton.Setup();
        gameController.Setup();
    }

    public void AddScore(int _score)
    {
        score += _score;
        uiScore.text = score.ToString();
    }

    public void FinishGame()
    {
        resultsPanel.SetActive(true);
        GameObject textLabel = resultsPanel.transform.GetChild(0).gameObject;
        textLabel.GetComponent<TMP_Text>().text = "You extracted " + score.ToString() + " resources";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!resourceCanvas.activeInHierarchy)
            {
                Setup();
                resourceCanvas.SetActive(true);
                resourceGrid.SetResourceTiles();

                surfaceGrid.Reset();

                score = 0;
                uiScore.text = "0";
            }
        }
    }

    public void DecreaseUsage(bool isScanMode)
    {
        if (isScanMode)
        {
            scanLimitLabel.text = (--scanLimit).ToString();
        }
        else
        {
            extractLmitLabel.text = (--extractLimit).ToString();
        }
    }
}
