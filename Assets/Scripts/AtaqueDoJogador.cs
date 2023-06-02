using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtaqueDoJogador : MonoBehaviour {
    public Camera cameraDoJogo;
    public GameObject efeitoDeImpacto;
    public Animator animatorDaArma;
    public Text textoDaMunicao;
    public int municaoMaxima;
    public int municaoAtual;
    public int danoParaDar;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	    textoDaMunicao.text = "Munição\n" + municaoAtual;
    }

    void Update() {
        Atirar();
    }

    private void Atirar() {
        if (Input.GetButtonDown("Fire1")) {
            if (municaoAtual > 0) {
                Ray raio = cameraDoJogo.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit localAtingido;

                if (Physics.Raycast(raio, out localAtingido)) {
                    Instantiate(efeitoDeImpacto, localAtingido.point, localAtingido.transform.rotation);

                    if (localAtingido.transform.gameObject.CompareTag("Inimigo")) {
                        localAtingido.transform.gameObject.GetComponentInParent<Inimigo>().MachucarInimigo(danoParaDar);
                        EfeitosSonoros.instance.TocarDanoDoInimigo();
                    }
                }

                municaoAtual -= 1;
                EfeitosSonoros.instance.TocarAtaqueDoJogador();
		        textoDaMunicao.text = "Munição\n" + municaoAtual;
		        animatorDaArma.SetTrigger("Arma Atirando");
            } else {
                EfeitosSonoros.instance.TocarSemMunicao();
            }
        }
    }

    public void DarMunicao(int municaoParaDar) {
        municaoAtual = municaoAtual + municaoParaDar < municaoMaxima ? municaoAtual + municaoParaDar : municaoMaxima;
	    textoDaMunicao.text = "Munição\n" + municaoAtual;
    }
}
