using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicas : MonoBehaviour {
    public AudioSource musicaDaFase, musicaGameOver;
    
    void Start() {   
        TocarMusicaDaFase();
    }

    public void TocarMusicaDaFase() {
        musicaDaFase.Play();
    }

    public void TocarMusicaGameOver() {
        musicaDaFase.Stop();
        musicaGameOver.Play();
    }
}
