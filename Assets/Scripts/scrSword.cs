using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSword : MonoBehaviour
{
    public float dano;
    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Enemy01")){
            scrVida vidaInimigo = col.gameObject.GetComponent<scrVida>();
            vidaInimigo.DiminuirVida(dano);
        }
    }
}
