using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    public string primeiraFase;

    void Start() {
        Time.timeScale = 1f;
    }

    public void IniciarJogo() {
        SceneManager.LoadScene(primeiraFase);
    }

    public void SairDoJogo() {
        Application.Quit();
    }
}
