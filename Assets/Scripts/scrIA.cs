using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scrIA : MonoBehaviour
{
    public enum EstadoIA{
        Atacando,
        Andando,
    }

    public EstadoIA estado;
    public float dano;
    public Animator controladorAnimacao;

    NavMeshAgent agentNM;
    scrVida vida;
    scrVida vidaJogador;

    scrSistemaSom sistemaDeSom;
    



    void Awake(){
        agentNM = GetComponent<NavMeshAgent>();
        vida = GetComponent<scrVida>();
        vidaJogador = GameObject.FindWithTag("Player").GetComponent<scrVida>();
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<scrSistemaSom>();
    }

    void Update(){
        if(agentNM.isStopped){
            estado = EstadoIA.Atacando;
        } else{
            estado = EstadoIA.Andando;
        }

        

        controladorAnimacao.SetFloat("velocidade", agentNM.velocity.magnitude);

        if(vida.vida <= 0){
            Destroy(gameObject);
        }
    }

    public void Atacar(){
        vidaJogador.DiminuirVida(dano);      
        sistemaDeSom.Emitir(scrSistemaSom.EfeitoSonoro.Tic);
    }
}
