using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scrMovInimigo : MonoBehaviour
{
    public float distanciaMinima = 2.2f;
    NavMeshAgent agentNM;

    void Awake(){
        agentNM = GetComponent<NavMeshAgent>();
    }

    void Update(){
        Vector3 posicaoJogador = scrThirdPWalk.pontoChao;
        Vector3 posicaoPraOlhar = new Vector3(posicaoJogador.x, transform.position.y, posicaoJogador.z);
        transform.LookAt(posicaoPraOlhar);
        agentNM.SetDestination(posicaoJogador);

        float distanciaEntreJogadorEInimigo = Vector3.Distance(transform.position, posicaoJogador);
        if(distanciaEntreJogadorEInimigo <= distanciaMinima){
            agentNM.isStopped = true;
        } else{
            agentNM.isStopped = false;
        }
    }

    

}
