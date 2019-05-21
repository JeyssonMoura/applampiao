using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class VerificaCodigo : MonoBehaviour {

	//Aux
	private HUD AuxHUD;

	public InputField codigo;
	public GameObject carregandoCenaHUD;
	private float carregando;

	void Start () {
		AuxHUD = GameObject.Find ("Canvas_HUD").GetComponent<HUD>();
	}

	public void EnviarCodigo () {
		if (Application.internetReachability != NetworkReachability.NotReachable) {
			if (codigo.text != "") {
				StartCoroutine (CarregarCena ("Jogo"));
				AuxHUD.abrirBoxAvisos ("Código válido!", 2);
				/*WWWForm form = new WWWForm ();
				form.AddField ("codigo", codigo.text);
				WWW EnviarDado = new WWW ("url do site", form);
				StartCoroutine (ValidaCodigo (EnviarDado));*/
			} else {
				AuxHUD.abrirBoxAvisos ("Preencha todos os campos!", 1);
			}
		} else {
			AuxHUD.abrirBoxAvisos ("Não está conectado a internet!", 1);
		}
	}

	IEnumerator ValidaCodigo (WWW CodigoV) {
		yield return CodigoV;
		string status = CodigoV.text;
		if (status == "") {
			
		} else {
			
		}
	}

	IEnumerator CarregarCena (string nomeCena){
		carregandoCenaHUD.GetComponent<Canvas> ().enabled = true;
		AsyncOperation cenaCarregar;
		cenaCarregar = SceneManager.LoadSceneAsync (nomeCena);
		while (!cenaCarregar.isDone) {
			carregando = (int)(cenaCarregar.progress * 100.0f);
			carregandoCenaHUD.transform.GetChild(0).GetComponent<Text>().text = "CARREGANDO... \n" + carregando + "%";
			yield return null;
		}
	}


}