using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSalaEnemy : MonoBehaviour
{
    public GameObject aranha1, aranha2;
    public bool podeSpawnnar1 = true;
    public bool podeSpawnnar2 = true;

     void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player" && podeSpawnnar1){
                aranha1.SetActive(true);
                podeSpawnnar1 = false;
            if(podeSpawnnar1 == false && podeSpawnnar2) 
                aranha2.SetActive(true);
                podeSpawnnar2 = false;
            }
    }

    
}
