using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCheckpoint : MonoBehaviour
{
    public Transform pontoRetorno;
    public GameObject jogador;

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            GameObject jogadorGbj = GameObject.FindWithTag("Player");
            Transform jogadorTr = jogadorGbj.GetComponent<Transform>();
            jogadorTr.position = pontoRetorno.position;
            jogadorTr.rotation = pontoRetorno.rotation;
        }
    }
}
