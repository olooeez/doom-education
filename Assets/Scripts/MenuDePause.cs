using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDePause : MonoBehaviour {
    public void ResumirJogo() {
        GameManager.instance.DespausarJogo();
    }

    public void SairJogo() {
        Application.Quit();
    }
}
