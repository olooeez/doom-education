using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {
    public float velocidadeDoInimigo;
    public int pontoAtual;
    public bool inimigoEstaVivo;
    public bool inimigoPodeAndar;
    public float tempoEntreOsPontos;
    public float tempoAtual;
    public float distanciaParaAtacar;
    public float tempoEntreOsAtaques;
    public bool inimigoJaAtacou;
    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public Transform [] pontosParaCaminhar;
    public Transform localDoDisparo;
    public GameObject projetilDoInimigo;
    public Animator animador;

    void Start() {
        inimigoEstaVivo = true;
        inimigoPodeAndar = true;
        inimigoJaAtacou = false;
        transform.position = pontosParaCaminhar[0].position;
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    void Update() {
        if (GameManager.instance.jogadorEstaVivo) {
            MovimentarInimigo();
            VerificarDistancia();
        }
    }

    private void MovimentarInimigo() {
        if (inimigoEstaVivo && inimigoPodeAndar) {
            transform.position = Vector2.MoveTowards(transform.position, pontosParaCaminhar[pontoAtual].position, velocidadeDoInimigo * Time.deltaTime);
            
            if (transform.position.y != pontosParaCaminhar[pontoAtual].position.y) {
                animador.SetTrigger("Andando");
            }

            if (transform.position.y == pontosParaCaminhar[pontoAtual].position.y) {
                animador.SetTrigger("Parar");
                EsperarAntesDeCaminhar();
            }

            if (pontoAtual == pontosParaCaminhar.Length) {
                pontoAtual = 0;
            }
        }
    }

    private void EsperarAntesDeCaminhar() {
        tempoAtual -= Time.deltaTime;

        if (tempoAtual <= 0) {
            inimigoPodeAndar = true;
            pontoAtual++;
            tempoAtual = tempoEntreOsPontos;
        }
    }

    private void VerificarDistancia() {
        if (Vector3.Distance(transform.position, ControleDoJogador.instance.transform.position) < distanciaParaAtacar) {
            AtacarJogador();
        } else {
            inimigoPodeAndar = true;
        }
    }

    private void AtacarJogador() {
        if (!inimigoJaAtacou) {
            inimigoPodeAndar = false;
            animador.SetTrigger("Atacando");
            Instantiate(projetilDoInimigo, localDoDisparo.position, localDoDisparo.rotation);
            inimigoJaAtacou = true;
            Invoke(nameof(ResetarAtaqueDoInimigo), tempoEntreOsAtaques);
        }
    }

    private void ResetarAtaqueDoInimigo() {
        inimigoJaAtacou = false;
    }

    public void MachucarInimigo(int danoParaReceber) {
        if (inimigoEstaVivo) {
            vidaAtualDoInimigo -= danoParaReceber;
            animador.SetTrigger("Dano");

            if (vidaAtualDoInimigo <= 0) {
                inimigoEstaVivo = false;
                inimigoPodeAndar = false;

                animador.SetTrigger("Derrotado");
            }
        }
    }

    public void DerrotarInimigo() {
        Destroy(this.gameObject);
    }
}
