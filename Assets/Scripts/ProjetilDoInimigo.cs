using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilDoInimigo : MonoBehaviour {
    public float velocidadeDoProjetil;
    public int danoParaDar;
    
    void Start() {
        
    }

    void Update() {
        MovimentarProjetilInimigo();
    }

    private void MovimentarProjetilInimigo() {
        transform.Translate(Vector3.forward * velocidadeDoProjetil * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoParaDar);
        }

        Destroy(this.gameObject);
    }
}
