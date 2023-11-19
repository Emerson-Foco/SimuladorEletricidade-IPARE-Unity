using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject quadro;

    public Image imageButton;
    public Sprite[] spriteButton;
    public GameController gameController;

    public GameObject falsePanel;

    void Awake()
    {
        if (quadro.activeSelf)
        {
            quadro.SetActive(false);
            FalsePanel(false);
            if (spriteButton.Length > 0)
            {
                imageButton.sprite = spriteButton[0];
            }
        }
    }

    public void SetPainel()
    {

        if (quadro.activeSelf)
        {
            quadro.SetActive(false);
             FalsePanel(false);
            if (spriteButton.Length > 0)
            {
                imageButton.sprite = spriteButton[0];
            }
        }
        else
        {
            gameController.ActiveFalsePanel();
            quadro.SetActive(true);
             FalsePanel(true);
            if (spriteButton.Length > 0)
            {
                imageButton.sprite = spriteButton[1];
            }
        }
    }

    public void FalsePanel(bool pn)
    {
        if (falsePanel != null)
        {
            falsePanel.SetActive(pn);
        }

    }



}
