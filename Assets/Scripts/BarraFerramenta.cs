using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraFerramenta : MonoBehaviour
{
    public Image[] boxImage;
    public GameController gameController;
    public void SetBox(int box)
    {
        for (int i = 0; i < boxImage.Length; i++)
        {
            if (boxImage[i].sprite == null && (box < gameController.GroupIconPanel.Length))
            {
                boxImage[i].sprite = gameController.GroupIconPanel[box];
                gameController.SetSave(i, box);
                break;
            }

        }

    }

    public void SetBox1(int box)
    {
        if (boxImage[box].sprite == null && (box < gameController.GroupIconPanel.Length))
        {
            boxImage[box].sprite = gameController.GroupIconPanel[box];
            gameController.SetSave(box, box);

        }
    }
    public String GetNameItem(int box)
    {
        return gameController.GroupIconPanel[box].name;
    }

}
