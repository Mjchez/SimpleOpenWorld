using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEventosAnim : MonoBehaviour
{
    public scrIA ia;
    public scrSistemaSom.EfeitoSonoro efeitoSonoro;

    scrSistemaSom sistemaDeSom;

    void Awake(){
        sistemaDeSom = GameObject.FindWithTag("MainCamera").GetComponent<scrSistemaSom>();
    }

   public void AnimEvt_InimigoAtaque(){
       ia.Atacar();
   }

   public void AnimEvt_EfeitoSonoro_Passo(){
       sistemaDeSom.Emitir(scrSistemaSom.EfeitoSonoro.Passos);
   }

   public void AnimEvt_EfeitoSonor_Golpe(){
       sistemaDeSom.Emitir(scrSistemaSom.EfeitoSonoro.Golpe);
   }

}
