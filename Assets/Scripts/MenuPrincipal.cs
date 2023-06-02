using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    public string primeiraFase;

    void Start() {
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void IniciarJogo() {
        SceneManager.LoadScene(primeiraFase);
    }

    public void SairDoJogo() {
        Application.Quit();
    }
}
