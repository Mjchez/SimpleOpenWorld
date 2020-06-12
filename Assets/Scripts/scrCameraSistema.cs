using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCameraSistema : MonoBehaviour
{
    public float velocidadeRotacao = 60;
    Transform trJogador;
    Transform tr;
    
    void Awake(){
        tr = GetComponent<Transform>();

        GameObject jogadorGbj = GameObject.FindWithTag("Player");
        trJogador = jogadorGbj.GetComponent<Transform>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Cursor.lockState == CursorLockMode.Locked){
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    void FixedUpdate()
    {
        tr.position = trJogador.position;

        float movX = Input.GetAxis("Mouse X");
        tr.Rotate(0,movX * velocidadeRotacao * Time.deltaTime,0);
    }

    
}
