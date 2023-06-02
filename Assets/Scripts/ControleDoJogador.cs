using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour {
    public static ControleDoJogador instance;
    public Rigidbody2D body;
    public Animator animatorDoPainelDaArma;
    public float velocidadeDoJogador;
    public float sensibilidadeDoMouse;
    private Vector2 comandosDoTeclado;
    private Vector2 movimentoDoMouse;

    void Awake() {
       instance = this; 
    }

    void Update() {
        if (!GameManager.instance.jogoPausado && GameManager.instance.jogadorEstaVivo) {
            MovimentarJogador();
            GirarCamera();
        }
    }

    private void MovimentarJogador() {
        comandosDoTeclado = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movimentoHorizontal = transform.up * -comandosDoTeclado.x;
        Vector3 movimentoVertical = transform.right * comandosDoTeclado.y;
        body.velocity = (movimentoHorizontal + movimentoVertical) * velocidadeDoJogador;
        body.velocity.Normalize();

        if (body.velocity.magnitude == 0) {
            animatorDoPainelDaArma.Play("Animação Jogador Parado");
        } else {
            animatorDoPainelDaArma.Play("Animação Jogador Andando");
        }
    }

    private void GirarCamera() {
        movimentoDoMouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * sensibilidadeDoMouse);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - movimentoDoMouse.x);
    }
}
