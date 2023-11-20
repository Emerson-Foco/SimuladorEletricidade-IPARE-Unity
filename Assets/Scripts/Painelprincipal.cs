using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Painelprincipal : MonoBehaviour
{
    public GameObject[] imgBoxDijuntor;
    public GameObject[] imgBoxDijuntorButton;
    public GameObject[] imgBoxCaboBlue;
    public GameObject[] imgBoxCaboGreen;
    public GameObject[] imgBoxCaboRed;
    public GameObject[] imgBoxDispositivoProteção;
    public GameObject[] imgBoxinterruptor;
    public GameObject[] imgBoxinterruptorButton;



    public GameController gameController;

    private Image getImgBox;
    

    void Awake()
    {
       BoxActiveFalse(imgBoxDijuntor);
       BoxActiveFalse(imgBoxDijuntorButton);
       BoxActiveFalse(imgBoxCaboBlue);
       BoxActiveFalse(imgBoxCaboGreen);
       BoxActiveFalse(imgBoxCaboRed);
       BoxActiveFalse(imgBoxDispositivoProteção);
       BoxActiveFalse(imgBoxinterruptor);
       BoxActiveFalse(imgBoxinterruptorButton);
    }

    /* public void SetBoxPanel(int box)
    {
        imgBox[gameController.GetSave(box)].SetActive(true);
        getImgBox = imgBox[gameController.GetSave(box)].GetComponent<Image>();
        getImgBox.sprite = gameController.GroupIconPanel[gameController.GetSave(box)];

    } */


    public void BoxActiveFalse(GameObject[] game)
    {
         for (int i = 0; i < game.Length; i++)
        {
            game[i].SetActive(false);           
        }
    }

    public void BoxActiveTrue(GameObject[] game)
    {
         for (int i = 0; i < game.Length; i++)
        {
            game[i].SetActive(true);           
        }
    }


   
}
