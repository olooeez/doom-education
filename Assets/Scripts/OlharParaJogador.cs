using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlharParaJogador : MonoBehaviour {
    void Update() {
        transform.LookAt(ControleDoJogador.instance.transform.position, -Vector3.forward);
    }
}
