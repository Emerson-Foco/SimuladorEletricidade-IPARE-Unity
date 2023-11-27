using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    //private Animator animator;
    private Animator animator;
    private float eixoX;
    private float eixoY;
    private float eixoZ;
    private bool posAtual;
    public Painelprincipal painelprincipal;

    void Awake()
    {
        animator = GetComponent<Animator>();
        posAtual = true;
        eixoX = transform.position.x;
        eixoY = transform.position.y;
        eixoZ = transform.position.z;
    }
    public void SetMoviment(bool verify)
    {
        if (posAtual)
        {
            animator.SetBool("BtnOff", false);
            animator.SetBool("BtnOn", true);
            posAtual = false;
            gameObject.transform.position = new Vector3(eixoX, eixoY, eixoZ);
            if (verify)
            {
                if (PlayerPrefs.HasKey("Vitory"))
                {
                    if (PlayerPrefs.GetInt("Vitory") == 1 && painelprincipal.imgCaboYellow.activeSelf)
                    {
                        painelprincipal.SetActiveVerifyTrue(painelprincipal.lampadaOn, painelprincipal.lampadaOff);
                        PlayerPrefs.SetInt("Vitory", 2);
                        painelprincipal.VerifyEndGame(1);
                    }
                }
            }
        }
        else
        {
            animator.SetBool("BtnOff", true);
            animator.SetBool("BtnOn", false);
            posAtual = true;
            gameObject.transform.position = new Vector3(eixoX, eixoY, eixoZ);
            if (verify)
            {
                painelprincipal.SetActiveFalse(painelprincipal.lampadaOn);
                if (PlayerPrefs.HasKey("Vitory"))
                {
                    if (PlayerPrefs.GetInt("Vitory") == 1)
                    {
                        PlayerPrefs.SetInt("Vitory", 1);
                    }
                }
            }
        }
    }



}


