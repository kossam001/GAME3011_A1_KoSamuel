using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModeButton : MonoBehaviour
{
    public TMP_Text buttonLabel;

    private bool isScanMode = false;

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        GetComponent<Button>().interactable = true;
        isScanMode = false;
        buttonLabel.text = "EXTRACT";
        GetComponent<Image>().color = Color.red;
    }

    public void ChangeMode()
    {
        if (isScanMode)
        {
            isScanMode = false;
            buttonLabel.text = "EXTRACT";
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            isScanMode = true;
            buttonLabel.text = "SCAN";
            GetComponent<Image>().color = Color.green;
        }
    }
}
