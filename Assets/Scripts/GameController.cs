using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject quadro;
    public Sprite[] GroupIcon;
    public Image icon;

    public Sprite[] GroupIconPanel;

    private String getName;

    void Start()
    {

        SetPainel();
    }

    public void SetPainel()
    {
        if (quadro.activeSelf)
        {
            quadro.SetActive(false);       
        }
        else
        {
            quadro.SetActive(true);       
        }
    }

    public int GetSave(int pos)
    {
        getName = "pos" + pos;
        return PlayerPrefs.GetInt(getName);
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



}
