using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite[] GroupIconPanel;
    public GameObject[] GroupIconPanelGameObject;
    public GameObject[] painelSec;
    public GameObject painelEndGame;  

    public GameObject painelAviso;

    private Animator painelAvisoAnimator;

    private Color currentColor;


    void Awake()
    {
        painelAvisoAnimator = painelAviso.GetComponent<Animator>();
        painelEndGame.SetActive(false);
        PlayerPrefs.DeleteAll();        
    }

    private String getName;
    public int GetSave(int pos)
    {
        getName = "pos" + pos;
        return PlayerPrefs.GetInt(getName);
    }

    public void SetColor(int pos,float alpha = 0.20f){
    
    currentColor = GroupIconPanelGameObject[pos].GetComponent<Image>().color;
    currentColor.a = alpha;
    currentColor.a = Mathf.Clamp01(currentColor.a);
    GroupIconPanelGameObject[pos].GetComponent<Image>().color = currentColor;
}



    public bool VerifySave(int pos)
    {
        getName = "pos" + pos;
        return PlayerPrefs.HasKey(getName);
    }

    public void SetSave(int pos, int obj)
    {
        getName = "pos" + pos;
        PlayerPrefs.SetInt(getName, obj);
    }

    public void ResetSave(int pos)
    {
        getName = "pos" + pos;
        PlayerPrefs.DeleteKey(getName);
    }

    public void SetAnimatorPainelAviso()
    {
        painelAvisoAnimator.SetTrigger("ativar");
    }
    public void ActiveFalsePanel()
    {
        for (int i = 0; i < painelSec.Length; i++)
        {
            if (painelSec[i].activeSelf)
            {
                painelSec[i].SetActive(false);
            }
        }
    }
}
