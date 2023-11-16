using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetActive : MonoBehaviour
{
    public GameObject quadro;

    public Image imageButton;
    public Sprite[] spriteButton;

    void Awake()
    {
        if (quadro.activeSelf)
        {
            quadro.SetActive(false);
            if(spriteButton.Length > 0){
                imageButton.sprite = spriteButton[0];
            }
        }
    }

    public void SetPainel()
    {
        if (quadro.activeSelf)
        {
            quadro.SetActive(false);
             if(spriteButton.Length > 0){
                imageButton.sprite = spriteButton[0];
            }
        }
        else
        {
            quadro.SetActive(true);
             if(spriteButton.Length > 0){
                imageButton.sprite = spriteButton[1];
            }
        }
    }
    
}
