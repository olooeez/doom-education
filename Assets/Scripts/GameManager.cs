using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool jogadorEstaVivo;
    public bool temChavePrateada;
    public bool temChaveDourada;

    void Awake() {
        instance = this;
    }

    void Start() {
        jogadorEstaVivo = true;
        temChavePrateada = false;
        temChaveDourada = false;
    }

    public void GameOver() {
        jogadorEstaVivo = false;
        Debug.Log("Game Over");
    }
}
