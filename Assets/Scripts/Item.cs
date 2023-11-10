using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Button imgItem;

    public GameController gameController;
    // Start is called before the first frame update

    public bool setActiveBox;

    public int posIni;  
    void Start()
    {

        imgItem = GetComponent<Button>();

        if (setActiveBox)
        {
            LoadImg(posIni);
        }


    }

    public void ResetImage(int pos)
    {
        imgItem.image.sprite = null;
        gameController.ResetSave(pos);
    }

    public void LoadImg(int pos)
    {
        imgItem.image.sprite = gameController.GroupIconPanel[pos];
    }

}
