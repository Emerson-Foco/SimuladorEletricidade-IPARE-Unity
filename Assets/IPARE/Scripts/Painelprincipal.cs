using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Painelprincipal : MonoBehaviour
{
    public GameObject[] imgBoxDijuntor;
    public GameObject[] imgBoxDijuntorButton;
    public GameObject[] imgBoxCaboBlue;
    public GameObject imgBoxCaboGreen;
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
    public GameObject imgCaboYellow;

    public GameObject alert;

    public AudioSource audioPainel;

    private bool verifyBoxPos;
    private bool verifyCaboPos;
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
        BoxActiveFalse(imgBoxCaboRed);
        BoxActiveFalse(imgBoxDispositivoProteção);
        BoxActiveFalse(imgBoxinterruptor);
        BoxActiveFalse(imgBoxinterruptorButton);
        BoxActiveFalse(interruptor);

        SetActiveFalse(imgBoxCaboGreen);
        SetActiveFalse(lampadaOn);
        SetActiveFalse(lampadaOff);
        SetActiveFalse(Multimetro127);
        SetActiveFalse(Multimetro0);
        SetActiveFalse(tomada);
        SetActiveFalse(painelEndGame);
        SetActiveFalse(imgCaboYellow);
    }


    public void SelectObject(int boxPos)
    {
        if (barraFerramenta.boxImage[boxPos].sprite != null)
        {
            verifyBoxPos = true;
            verifyCaboPos = true;
            getIntBox = gameController.GetSave(boxPos);
            if ((getIntBox >= 0 && getIntBox < 3 || getIntBox > 3 && getIntBox <= 6) && PowerDoor.GetComponent<Transform>().rotation.y == 0)
            {
                controller.SetMoviment(false);
                audioPainel.Play();
                verifyBoxPos = false;

            }else if(getIntBox == 3){
                 SetActiveTrue(imgCaboYellow);
            }
            else if ((getIntBox >= 0 && getIntBox < 3 || getIntBox > 3 && getIntBox <= 6) && PowerDoor.GetComponent<Transform>().rotation.y > 0)
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
                        OnlyActiveTrue(imgBoxCaboBlue, 4);
                        break;
                    case 5:
                        SetActiveTrue(imgBoxCaboGreen);
                        break;
                    case 6:
                        OnlyActiveTrue(imgBoxCaboRed, 6);
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

            if (verifyCaboPos)
            {
                gameController.SetColor(getIntBox);
            }

            SetLampadaOn();
        }
    }

    public bool GetCabo(int cabo)
    {
        if (cabo == 4)
        {
            if (imgBoxCaboBlue[1].activeSelf)
            {
                return true;
            }
            return false;
        }
        else if (cabo == 5)
        {
            if (imgBoxCaboGreen.activeSelf)
            {
                return true;
            }
            return false;
        }
        else if (cabo == 6)
        {
            if (imgBoxCaboRed[1].activeSelf)
            {
                return true;
            }
            return false;
        }
        else
        {
            return true;
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



    // Insere os cabos um por vez
    public void OnlyActiveTrue(GameObject[] game, int value)
    {
        for (int i = 0; i < game.Length; i++)
        {
            if (!game[i].activeSelf)
            {
                game[i].SetActive(true);
               if (i < game.Length - 1)
                { 
                    gameController.SetColor(value, 1);
                    verifyCaboPos = false;
                }

                break;
            }
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
        if (imgBoxDijuntor[0].activeSelf && imgBoxCaboBlue[1].activeSelf && imgBoxCaboGreen.activeSelf && imgBoxCaboRed[1].activeSelf && imgBoxDispositivoProteção[0].activeSelf && imgBoxinterruptor[0].activeSelf)
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
