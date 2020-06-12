using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrThirdPWalk : MonoBehaviour
{
    public float velocidadeMov = 15;
    public float deslocamentoAltura;
    public float intensidadePulo;
    public LayerMask camadaChao;
    public Animator anim;
    Transform tr;
    Rigidbody rb;
    Transform trCam;
    public bool estaEmPulo, estaEmMovimento, estaNoChao, magiaUsada;

    public CapsuleCollider colisorEspada;
    public GameObject projetilMagia;
    public Transform pontoTiro;
    public float forcaLancamentoMagia;

    scrSistemaSom sistemaSom;

    public static Vector3 pontoChao;

    void Awake(){
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        trCam = GameObject.FindWithTag("Tripe").GetComponent<Transform>();
        sistemaSom = GameObject.FindWithTag("MainCamera").GetComponent<scrSistemaSom>();
        colisorEspada.enabled = false;
    }

    void FixedUpdate(){
        
        //receber dados de entrada jogador
        bool apertouPulo = Input.GetButtonDown("Jump");


        bool apertouAtaque = Input.GetButtonDown("Fire1");
        bool apertouMagia = Input.GetButtonDown("Fire2");
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");


        Vector3 mov = new Vector3(movH, 0, movV);
        if(mov.magnitude >1f)
            mov.Normalize();

        //detecta estados
        RaycastHit chaoHit;
        estaNoChao = Physics.Raycast(
                tr.position,
                Vector3.down,
                out chaoHit,
                deslocamentoAltura,
                camadaChao
            );
        estaEmPulo =  apertouPulo || !estaNoChao;
        estaEmMovimento = mov.magnitude > 0.1f;

        //ataque
        if(apertouAtaque && !estaEmPulo && !colisorEspada.enabled){
            anim.SetTrigger("atacou");
            colisorEspada.enabled = true;
            Invoke("DesativarEspada", 0.1f);
            
        }

        //magia
        if(apertouMagia && !estaEmPulo && !colisorEspada.enabled && !magiaUsada){
            anim.SetTrigger("magia");
            magiaUsada = true;
            Invoke("DesativaMagia", 0.2f);

            GameObject magiaGbj = Instantiate<GameObject>(projetilMagia, pontoTiro.position, pontoTiro.rotation);
            Rigidbody magiaRb = magiaGbj.GetComponent<Rigidbody>();
            magiaRb.AddForce(magiaGbj.transform.forward * forcaLancamentoMagia, ForceMode.Impulse);
        }

        //pulo
        rb.useGravity = estaEmPulo;
        rb.constraints = (RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ); 

        if(!estaEmPulo)
            rb.constraints = rb.constraints | RigidbodyConstraints.FreezePositionY;
        
        if(apertouPulo && estaNoChao){
            rb.AddForce(Vector3.up * intensidadePulo, ForceMode.Impulse);
        }
        //rotacionar o jogador
        if(estaEmMovimento)
           tr.LookAt(tr.position + trCam.TransformDirection(mov) *5);

        //mover o jogador
        if(estaEmMovimento)
            tr.Translate(0, 0, mov.magnitude* velocidadeMov * Time.deltaTime);
        
        //alimentando parametros anim
        anim.SetFloat("velocidade", mov.magnitude);
        anim.SetBool("estaNoChao", estaNoChao);

        //acompanhar chao
        if(!estaEmPulo){
            RaycastHit hit;
            bool rcBateuChao = Physics.Raycast(
                tr.position,
                Vector3.down,
                out hit,
                Mathf.Infinity,
                camadaChao
            );
            if(rcBateuChao){
                Vector3 pos = tr.position;
                pos.y = hit.point.y + deslocamentoAltura;
                tr.position = pos;

                pontoChao = hit.point;
            }
            //zerar inercia
            rb.velocity = Vector3.zero;
        }
    }

    void DesativarEspada(){
        colisorEspada.enabled = false;
    }

    void DesativaMagia(){
        magiaUsada = false;
    }
}
