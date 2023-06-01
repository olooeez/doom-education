using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemColetavel : MonoBehaviour {
    public bool itemDeMunicao;
    public bool itemDeVida;
    public bool itemChavePrateada;
    public bool itemChaveDourada;

    public int municaoParaDar;
    public int vidaParaDar;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (itemDeMunicao) {
                other.gameObject.GetComponent<AtaqueDoJogador>().DarMunicao(municaoParaDar);
            }

            if (itemDeVida) {
                other.gameObject.GetComponent<VidaDoJogador>().DarVida(vidaParaDar);
            }

            if (itemChavePrateada) {
                GameManager.instance.temChavePrateada = true;
            }

            if (itemChaveDourada) {
                GameManager.instance.temChaveDourada = true;
            }

            Destroy(this.gameObject);
        }
    }
}
