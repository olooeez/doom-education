using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditarFases : MonoBehaviour {
    public void FaseParaEditar(string editorFase) {
        SceneManager.LoadScene(editorFase);
    }
}
