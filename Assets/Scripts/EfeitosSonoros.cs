using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitosSonoros : MonoBehaviour {
    public AudioSource somDoAtaqueDoInimigo, somDoAtaqueDoJogador, somDaChave, somDanoDoInimigo, somDanoDoJogador, somInimigoDerrotado, somDaMunicao, somSemMunicao, somDaVida;
    public static EfeitosSonoros instance;

    void Awake() {
        instance = this;
    }

    public void TocarAtaqueDoInimigo() {
        somDoAtaqueDoInimigo.Play();
    }

    public void TocarAtaqueDoJogador() {
        somDoAtaqueDoJogador.Play();
    }

    public void TocarChave() {
        somDaChave.Play();
    }

    public void TocarDanoDoInimigo() {
        somDanoDoInimigo.Play();
    }

    public void TocarDanoDoJogador() {
        somDanoDoJogador.Play();
    }

    public void TocarInimigoDerrotado() {
        somInimigoDerrotado.Play();
    }

    public void TocarMunicao() {
        somDaMunicao.Play();
    }

    public void TocarSemMunicao() {
        somSemMunicao.Play();
    }

    public void TocarVida() {
        somDaVida.Play();
    }
}
