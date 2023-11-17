using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite[] GroupIconPanel;
    public GameObject[] painelSec;

    private String getName;
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
