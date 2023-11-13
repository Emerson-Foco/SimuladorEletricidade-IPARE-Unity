using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Animator animator;
    private float eixoX;
    private float eixoY;

    void Awake()
    {
        animator = GetComponent<Animator>();
        eixoX = transform.rotation.x;
        eixoY = transform.rotation.y;
    }

    public void SetMoviment(float posAtual)
    {
        Debug.Log("asd");
        if (eixoX == posAtual || eixoY == posAtual)
        {
            animator.SetBool("BtnOff", false);
            animator.SetBool("BtnOn", true);
        }
        else
        {
            animator.SetBool("BtnOff", true);
            animator.SetBool("BtnOn", false);
        }
    }
   
}
