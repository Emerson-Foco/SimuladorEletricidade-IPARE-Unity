using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public GameObject[] interruptor;

    public GameObject tomada;
    public GameObject lampadaOn;
    public GameObject lampadaOff;
    public GameObject Multimetro127;
    public GameObject Multimetro0;
    public GameObject PowerDoor;

    //private Animator powerDoorAnimator;



    public GameController gameController;
    public BarraFerramenta barraFerramenta;
    public Controller controller;

    public GameObject painelAviso;


    private int getIntBox;


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
        BoxActiveFalse(interruptor);

        SetActiveFalse(lampadaOn);
        SetActiveFalse(lampadaOff);
        SetActiveFalse(Multimetro127);
        SetActiveFalse(Multimetro0);
        SetActiveFalse(tomada);

        //powerDoorAnimator = PowerDoor.GetComponent<Animator>();


    }

    /* public void SetBoxPanel(int box)
    {
        imgBox[gameController.GetSave(box)].SetActive(true);
        getImgBox = imgBox[gameController.GetSave(box)].GetComponent<Image>();
        getImgBox.sprite = gameController.GroupIconPanel[gameController.GetSave(box)];

    } */


    public void SelectObject(int boxPos)
    {
        if (barraFerramenta.boxImage[boxPos].sprite != null)
        {
            getIntBox = gameController.GetSave(boxPos);
            if (getIntBox >= 0 && getIntBox <= 6 && PowerDoor.GetComponent<Transform>().rotation.y == 0)
            {
                controller.SetMoviment();

            }
            else if (getIntBox >= 0 && getIntBox <= 6 && PowerDoor.GetComponent<Transform>().rotation.y > 0)
            {
                barraFerramenta.SetActiveFalseBox(boxPos);

                switch (getIntBox)
                {
                    case 0:
                        BoxActiveTrue(imgBoxinterruptor);
                        BoxActiveTrue(imgBoxinterruptorButton);
                        break;
                    case 1:
                        BoxActiveTrue(imgBoxDijuntor);
                        BoxActiveTrue(imgBoxDijuntorButton);
                        break;
                    case 2:
                        BoxActiveTrue(imgBoxDispositivoProteção);
                        break;
                    case 4:
                        BoxActiveTrue(imgBoxCaboBlue);
                        break;
                    case 5:
                        BoxActiveTrue(imgBoxCaboGreen);
                        break;
                    case 6:
                        BoxActiveTrue(imgBoxCaboRed);
                        break;

                }
            }
            else if (getIntBox >= 7 && PowerDoor.GetComponent<Transform>().rotation.y > 0)
            {
                controller.SetMoviment();
            }
            else if (getIntBox >= 7 && PowerDoor.GetComponent<Transform>().rotation.y == 0)
            {

                barraFerramenta.SetActiveFalseBox(boxPos);

                switch (getIntBox)
                {
                    case 7:
                        BoxActiveTrue(interruptor);
                        break;
                    case 8:
                       SetActiveTrue(tomada);
                        break;
                        case 9:
                       SetActiveTrue(lampadaOff);
                        break;
                    case 10:
                        SetActiveTrue(Multimetro0);
                        break;
                }
            }
        }


    }


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

    public void SetActiveFalse(GameObject game)
    {

        game.SetActive(false);

    }

    public void SetActiveTrue(GameObject game)
    {

        game.SetActive(true);

    }



}
