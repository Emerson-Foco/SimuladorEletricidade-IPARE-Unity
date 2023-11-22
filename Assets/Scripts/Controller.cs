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

    void Awake()
    {
        animator = GetComponent<Animator>();
        posAtual = true;
        eixoX = transform.position.x;
        eixoY = transform.position.y;
        eixoZ = transform.position.z;
    }
    public void SetMoviment()
    {
        if (posAtual)
        {
            animator.SetBool("BtnOff", false);
            animator.SetBool("BtnOn", true);
            posAtual = false;
            gameObject.transform.position = new Vector3(eixoX, eixoY, eixoZ);
        }
        else
        {
            animator.SetBool("BtnOff", true);
            animator.SetBool("BtnOn", false);
            posAtual = true;
            gameObject.transform.position = new Vector3(eixoX, eixoY, eixoZ);
        }
    }

}


