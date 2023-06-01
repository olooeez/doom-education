using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour {
    public Animator porta;
    public Collider2D colisorDaPorta;
    public bool portaNormal;
    public bool portaPrateada;
    public bool portaDourada;
    public bool portaFechada;

    void Start() {
        portaFechada = true;
    }

    void Update() {

    }

    private void AbrirPorta() {
        porta.SetTrigger("Porta abrindo");
        portaFechada = false;
        colisorDaPorta.enabled = false;
    }

    private void FecharPorta() {
        porta.SetTrigger("Porta fechando");
        portaFechada = true;
        colisorDaPorta.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && portaFechada) {
            if (portaNormal) {
                AbrirPorta();
            }

            if (portaPrateada && GameManager.instance.temChavePrateada) {
                AbrirPorta();
            }

            if (portaDourada && GameManager.instance.temChaveDourada) {
                AbrirPorta();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && !portaFechada) {
            FecharPorta();
        }
    }
}
