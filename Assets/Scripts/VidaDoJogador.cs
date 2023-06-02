using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour {
    public int vidaMaximaJogador;
    public int vidaAtualDoJogador;
    public Text textoDaVidaDoJogador;

    void Start() {
        textoDaVidaDoJogador.text = "Vida\n" + vidaAtualDoJogador;
    }

    public void MachucarJogador(int danoParaReceber) {
        if (GameManager.instance.jogadorEstaVivo) {
            vidaAtualDoJogador -= danoParaReceber;
            EfeitosSonoros.instance.TocarDanoDoJogador();
            textoDaVidaDoJogador.text = "Vida\n" + vidaAtualDoJogador;
        }

        if (vidaAtualDoJogador <= 0) {
            GameManager.instance.GameOver();
        }
    }

    public void DarVida(int vidaParaDar) {
        vidaAtualDoJogador = vidaAtualDoJogador + vidaParaDar < vidaMaximaJogador ? vidaAtualDoJogador + vidaParaDar : vidaMaximaJogador;
        textoDaVidaDoJogador.text = "Vida\n" + vidaAtualDoJogador;
    }
}
