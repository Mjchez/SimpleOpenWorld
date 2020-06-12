using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrVida : MonoBehaviour
{
    public float vida;
    public scrSistemaSom.EfeitoSonoro efeitoSonoroDano;

    scrSistemaSom sistemaSom;

    void Awake(){
        sistemaSom = GameObject.FindWithTag("MainCamera").GetComponent<scrSistemaSom>();
    }

    public void DiminuirVida(float dano){
        vida = vida - dano;
        sistemaSom.Emitir(efeitoSonoroDano);
    }
}
