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

}
