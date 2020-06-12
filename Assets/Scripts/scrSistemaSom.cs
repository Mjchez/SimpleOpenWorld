using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSistemaSom : MonoBehaviour
{
    public enum EfeitoSonoro{
        Tic=0,
        Golpe,
        Aagh,
        Toc,
        Passos,
    }

    public GameObject caixaSomPrefab;
    public AudioClip[] sons;

    public void Emitir(EfeitoSonoro efeito){
        GameObject novaCaixa = Instantiate<GameObject>(caixaSomPrefab, transform.position, Quaternion.identity);
        scrCaixaSom novaCaixa_Conp = novaCaixa.GetComponent<scrCaixaSom>();

        int som_numero = (int)efeito;

        AudioClip somEfeitoSonoro = sons[som_numero];

        novaCaixa_Conp.clipeSom = somEfeitoSonoro;
    }

}
