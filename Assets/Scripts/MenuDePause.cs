using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePause : MonoBehaviour {
    public string nomeDoMenu;

    public void ResumirJogo() {
        GameManager.instance.DespausarJogo();
    }

    public void VoltarAoMenu() {
        SceneManager.LoadScene(nomeDoMenu);
    }
}
