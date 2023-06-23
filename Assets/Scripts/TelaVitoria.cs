using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaVitoria : MonoBehaviour {
    void Start() {
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void MenuPrincipal() {
        SceneManager.LoadScene("Menu");
    }

    public void SairDoJogo() {
        Application.Quit();
    }
}
