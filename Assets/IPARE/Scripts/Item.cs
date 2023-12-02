using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    private Button imgItem;

    public GameController gameController;
    // Start is called before the first frame update

    public TextMeshProUGUI textItem;
    public float textItemFont;
    public bool setActiveBox;

    public int posIni;
    void Start()
    {
        imgItem = GetComponent<Button>();

        if (setActiveBox)
        {
            LoadImg(posIni);
        }

        if (textItem != null)
        {
            GetNameItem();
        }
    }

    public void ResetImage(int pos)
    {
        imgItem.image.sprite = null;
        gameController.ResetSave(pos);
    }

    public void LoadImg(int pos)
    {
        if (pos < gameController.GroupIconPanel.Length)
        {
            imgItem.image.sprite = gameController.GroupIconPanel[pos];
        }

    }

    public void GetNameItem()
    {
        textItem.text = gameController.GroupIconPanel[posIni].name;
        SetFont(textItemFont);
    }

    public void SetFont(float fonte)
    {
        textItem.fontSize = fonte;
    }

}
