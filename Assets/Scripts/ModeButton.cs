using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModeButton : MonoBehaviour
{
    public TMP_Text buttonLabel;
    public TMP_Text scanLimitLabel;
    public TMP_Text extractLmitLabel;

    private bool isScanMode = false;

    public int scanLimit = 6;
    public int extractLimit = 3;

    private void Start()
    {
        isScanMode = false;
        buttonLabel.text = "EXTRACT";
        GetComponent<Image>().color = Color.red;

        scanLimitLabel.text = scanLimit.ToString();
        extractLmitLabel.text = extractLimit.ToString();
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

    public void DecreaseUsage()
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
