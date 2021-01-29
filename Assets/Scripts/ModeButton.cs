using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModeButton : MonoBehaviour
{
    public TMP_Text buttonLabel;
    private bool isScanMode = false;

    public int scanLimit = 6;
    public int extractLimit = 3;

    private void Start()
    {
        isScanMode = false;
        buttonLabel.text = "EXTRACTx" + extractLimit.ToString();
        GetComponent<Image>().color = Color.red;
    }

    public void ChangeMode()
    {
        if (isScanMode)
        {
            isScanMode = false;
            buttonLabel.text = "EXTRACTx" + extractLimit.ToString();
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            isScanMode = true;
            buttonLabel.text = "SCANx" + scanLimit.ToString();
            GetComponent<Image>().color = Color.green;
        }
    }

    public void DecreaseUsage()
    {
        if (isScanMode)
        {
            buttonLabel.text = "SCANx" + (--scanLimit).ToString();
        }
        else
        {
            buttonLabel.text = "EXTRACTx" + (--extractLimit).ToString();
        }
    }
}
