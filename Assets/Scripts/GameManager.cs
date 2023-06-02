using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameObject painelDePausa;
    public bool jogadorEstaVivo;
    public bool temChavePrateada;
    public bool temChaveDourada;
    public bool jogoPausado;

    void Awake() {
        instance = this;
    }

    void Start() {
        Time.timeScale = 1f;
        jogoPausado = false;
        jogadorEstaVivo = true;
        temChavePrateada = false;
        temChaveDourada = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (jogoPausado) {
                DespausarJogo();
            } else {
                PausarJogo();
            }
        }
    }

    public void PausarJogo() {
        Time.timeScale = 0f;
        painelDePausa.SetActive(true);
        jogoPausado = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DespausarJogo() {
        Time.timeScale = 1f;
        painelDePausa.SetActive(false);
        jogoPausado = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GameOver() {
        jogadorEstaVivo = false;
        FindObjectOfType<Musicas>().TocarMusicaGameOver();
    }
}
