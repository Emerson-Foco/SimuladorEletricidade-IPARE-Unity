using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject quadro;

    void Awake()
    {
        if (quadro.activeSelf)
        {
            quadro.SetActive(false);
        }
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
    
}
