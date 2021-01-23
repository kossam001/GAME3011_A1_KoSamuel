using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject uiResourceGrid;
    public TMP_Text uiScore;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void AddScore(int _score)
    {
        score += _score;
        uiScore.text = score.ToString();
    }
}
