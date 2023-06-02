using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarDeFase : MonoBehaviour {
    public Animator transicaoDeFase;
    public string proximaFase;
    public float tempoParaEsperar;

    private IEnumerator CarregarNovaFase() {
        transicaoDeFase.Play("Animação Imagem Escurecendo");

        yield return new WaitForSeconds(tempoParaEsperar);

        SceneManager.LoadScene(proximaFase);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(CarregarNovaFase());
        }
    }
}