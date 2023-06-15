using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portas : MonoBehaviour {
    public static Portas instance;
    public Animator porta;
    public Collider2D colisorDaPorta;
    public GameObject painelAbrirPorta;
    public bool portaNormal;
    public bool portaPrateada;
    public bool portaDourada;
    public bool portaFechada;
    private bool abrirPorta;

    void Awake() {
        instance = this;
    }

    void Start() {
        portaFechada = true;
        abrirPorta = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (painelAbrirPorta.activeSelf) {
                abrirPorta = true;
            }
        }
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
        if (other.gameObject.CompareTag("Player")) {
            painelAbrirPorta.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && abrirPorta) {
            painelAbrirPorta.SetActive(false);

            if (portaNormal) {
                AbrirPorta();
            }

            if (portaPrateada && GameManager.instance.temChavePrateada) {
                AbrirPorta();
            }

            if (portaDourada && GameManager.instance.temChaveDourada) {
                AbrirPorta();
            }

            abrirPorta = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && !portaFechada) {
            FecharPorta();
        }

        painelAbrirPorta.SetActive(false);
        abrirPorta = false;
    }
}
