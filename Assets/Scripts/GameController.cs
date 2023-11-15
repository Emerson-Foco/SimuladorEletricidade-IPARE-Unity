using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Sprite[] GroupIcon;
    public Sprite[] GroupIconPanel;

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
}
