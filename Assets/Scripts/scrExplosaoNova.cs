using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrExplosaoNova : MonoBehaviour
{
    public float forcaExplosao;

    void Start(){
        RaycastHit[] hits;

        hits = Physics.SphereCastAll(transform.position, 5, Vector3.up, 10);

        for(int i=0; i < hits.Length; i++){
            RaycastHit hit = hits[i];
            if(hit.rigidbody){
                hit.rigidbody.AddExplosionForce(forcaExplosao, transform.position, 10);
            }
            if(hit.transform.gameObject.tag == "Enemy01"){
                 scrVida vidaInimigo = hit.transform.gameObject.GetComponent<scrVida>();
                 vidaInimigo.DiminuirVida(150);
            }

        }
        Destroy(gameObject,10);
    }
}
