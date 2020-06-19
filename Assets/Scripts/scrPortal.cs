using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrPortal : MonoBehaviour
{
    public string CenaNome;
    public Transform pontoRetorno;

    static bool inicioJogo =true;

    void Start(){
        if(!inicioJogo){
        GameObject jogadorGbj = GameObject.FindWithTag("Player");
        Transform jogadorTr = jogadorGbj.GetComponent<Transform>();
        jogadorTr.position = pontoRetorno.position;
        jogadorTr.rotation = pontoRetorno.rotation;
        }

        inicioJogo = false;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            SceneManager.LoadScene(CenaNome);
        }
    }
}
