using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrProjetilNovo : MonoBehaviour
{
    public bool destruirAoEnconstar;
    public GameObject efeitoExplosao;

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "Enemy01"){
            scrVida vida = col.gameObject.GetComponent<scrVida>();
            vida.DiminuirVida(200);  
        }
        
        if(destruirAoEnconstar){
            Instantiate(efeitoExplosao, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
