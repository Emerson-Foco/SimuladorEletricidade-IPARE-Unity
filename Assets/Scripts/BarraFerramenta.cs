using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarraFerramenta : MonoBehaviour
{
    public Image[] boxImage;
    public GameController gameController;
    private Color currentColor;

    public GameObject[] itemX;
    public TextMeshProUGUI[] text;

    public GameObject[] textPro;
    private bool bl;
    private int verifySaveInt;

    void Awake()
    {
        SetActiveFalseBoxTotal();
    }
    public void SetBox(int box)
    {
        if (VerifyBox(box))
        {
            Debug.Log("o item ja esta na barra de ferramentas");
        }
        else
        {
            for (int i = 0; i < boxImage.Length; i++)
            {
                if (boxImage[i].sprite == null && (box < gameController.GroupIconPanel.Length))
                {
                    boxImage[i].sprite = gameController.GroupIconPanel[box];
                    gameController.SetSave(i, box);
                    currentColor = boxImage[i].color;
                    currentColor.a = 1.0f;
                    boxImage[i].color = currentColor;
                    SetActiveTrueBox(itemX[i], textPro[i]);
                    text[i].text = gameController.GroupIconPanel[box].name;
                    break;
                }
            }
        }


    }

    public bool VerifyBox(int box)
    {
        bl = false;
        for (int i = 0; i < boxImage.Length; i++)
        {
            if (gameController.VerifySave(i))
            {
                verifySaveInt = gameController.GetSave(i);
                if (verifySaveInt == box)
                {
                    return true;
                }
            }
        }

        return bl;
    }


    public void SetActiveFalseBoxTotal()
    {
        for (int i = 0; i < itemX.Length; i++)
        {
            itemX[i].SetActive(false);
            textPro[i].SetActive(false);
        }
    }

    public void SetActiveFalseBox(int value)
    {
        itemX[value].SetActive(false);
        textPro[value].SetActive(false);
        currentColor = boxImage[value].color;
        currentColor.a = 0f;
        boxImage[value].color = currentColor;
        boxImage[value].sprite = null;
        gameController.ResetSave(value);
    }

    public void SetActiveTrueBox(GameObject itmX, GameObject text)
    {
        itmX.SetActive(true);
        text.SetActive(true);
    }

}

