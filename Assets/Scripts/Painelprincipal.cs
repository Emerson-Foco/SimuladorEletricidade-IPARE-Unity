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

    public GameObject alert;

    private bool verifyBoxPos;
    public AudioSource musicEndGame;

    //private Animator powerDoorAnimator;



    public GameController gameController;
    public BarraFerramenta barraFerramenta;
    public Controller controller;

    public GameObject painelAviso;

    public GameObject painelEndGame;


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
        SetActiveFalse(painelEndGame);
    }


    public void SelectObject(int boxPos)
    {
        if (barraFerramenta.boxImage[boxPos].sprite != null)
        {
            verifyBoxPos = true;
            getIntBox = gameController.GetSave(boxPos);
            if (getIntBox >= 0 && getIntBox <= 6 && PowerDoor.GetComponent<Transform>().rotation.y == 0)
            {
                controller.SetMoviment(false);
                verifyBoxPos = false;

            }
            else if (getIntBox >= 0 && getIntBox <= 6 && PowerDoor.GetComponent<Transform>().rotation.y > 0)
            {
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
            else if (getIntBox >= 7)
            {
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
                        SetActiveVerifyTrue1(Multimetro0, tomada, alert);
                        break;
                }
            }

            if (verifyBoxPos)
            {
                barraFerramenta.SetActiveFalseBox(boxPos);
                gameController.SetSavePanel(getIntBox);
            }

            gameController.SetColor(getIntBox);
            SetLampadaOn();
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

    public void SetActiveVerifyTrue(GameObject game, GameObject necessaryObject, GameObject alert = null)
    {
        if (necessaryObject.activeSelf)
        {
            game.SetActive(true);
            necessaryObject.SetActive(false);
        }

        if (alert != null)
        {
            if (!necessaryObject.activeSelf)
            {
                alert.GetComponent<Animator>().SetTrigger("ativar");
                verifyBoxPos = false;
            }
        }
    }

    public void SetActiveVerifyTrue1(GameObject game, GameObject necessaryObject, GameObject alert = null)
    {
        if (necessaryObject.activeSelf)
        {
            game.SetActive(true);           
        }

        if (alert != null)
        {
            if (!necessaryObject.activeSelf)
            {
                alert.GetComponent<Animator>().SetTrigger("ativar");
                verifyBoxPos = false;
            }
        }
    }

    public void SetLampadaOn()
    {
        if (imgBoxDijuntor[0].activeSelf && imgBoxCaboBlue[0].activeSelf && imgBoxCaboGreen[0].activeSelf && imgBoxCaboRed[0].activeSelf && imgBoxDispositivoProteção[0].activeSelf && imgBoxinterruptor[0].activeSelf)
        {
            SetActiveVerifyTrue(Multimetro127, Multimetro0);
            if (!PlayerPrefs.HasKey("Vitory"))
        {
             PlayerPrefs.SetInt("Vitory", 1);        
        }
              VerifyEndGame(1);
        }        
    }

    public void VerifyEndGame(float sec)
    {
        if (PlayerPrefs.HasKey("Vitory"))
        {
            if (PlayerPrefs.GetInt("Vitory") == 2)
            {
                if (Multimetro127.activeSelf)
                {
                    StartCoroutine(EndGame(sec));
                }
            }
        }
    }

    private IEnumerator EndGame(float sec)
    {
        yield return new WaitForSeconds(sec);
        SetActiveTrue(painelEndGame);
        TocarMusica();
    }

    private void TocarMusica()
    {
        musicEndGame.Play();
    }

}
