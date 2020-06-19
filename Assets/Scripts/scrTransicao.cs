using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrTransicao : MonoBehaviour
{
    public Image imgTransicao;
    public bool acabou;
    Color transparente = new Color(0,0,0,0);
    public float vel;

    void Start(){
        IniciarTransicao(Color.black, transparente);
    }

    public void IniciarTransicao(Color inicio, Color fim){
        acabou = false;
        StartCoroutine(FazerTransicao(inicio, fim));
    }

    IEnumerator FazerTransicao(Color inicio, Color fim){
        float alpha = imgTransicao.color.a;
        float t = 0;

        while(true){
            t = t + Time.unscaledDeltaTime * vel;
            imgTransicao.color = Color.Lerp(inicio, fim,t);
            if(t >= 1){
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        acabou = true;
    }
}
