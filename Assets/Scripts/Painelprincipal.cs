using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Painelprincipal : MonoBehaviour
{
    public GameObject[] imgBox;
    public GameController gameController;

    private Image getImgBox;
    

    void Awake()
    {
        BoxActiveFalse();
    }

    public void SetBoxPanel(int box)
    {
        imgBox[gameController.GetSave(box)].SetActive(true);
        getImgBox = imgBox[gameController.GetSave(box)].GetComponent<Image>();
        getImgBox.sprite = gameController.GroupIconPanel[gameController.GetSave(box)];

    }

    public void BoxActiveFalse()
    {
        for (int i = 0; i < imgBox.Length; i++)
        {
            imgBox[i].SetActive(false);
        }
    }
}
