using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class VerificaCodigo : MonoBehaviour {

	//Aux
	private HUD AuxHUD;

	private int codigo;

	//Dados
	public GameObject[] dadosScritp;

	void Start () {
		dadosScritp = GameObject.FindGameObjectsWithTag("VCodigo");
		if(dadosScritp.Length > 1){
			Destroy(dadosScritp[1]);
		}
	}

	void Update () {
		AuxHUD = GameObject.Find ("Canvas_HUD").GetComponent<HUD>();
		DontDestroyOnLoad (this);
	}

	public void setCodigo (int _codigo) {
		codigo = _codigo;
	}

	public int getCodigo () {
		return codigo;
	}

	public void EnviarCodigo () {
		if (Application.internetReachability != NetworkReachability.NotReachable) {
			if (AuxHUD.ctCodigo.text != "") {
				setCodigo (int.Parse(AuxHUD.ctCodigo.text.ToString()));
				AuxHUD.CarregarNovaCena ("Jogo");//Apenas para testes
				/*WWWForm form = new WWWForm ();
				form.AddField ("codigo", getCodigo());
				WWW EnviarDados = new WWW ("url do site", form);
				StartCoroutine (ValidaCodigo (EnviarDados));*/
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
			AuxHUD.CarregarNovaCena ("Jogo");
			AuxHUD.abrirBoxAvisos ("Código válido!", 2);
		} else {
			AuxHUD.abrirBoxAvisos (status, 1);
		}
	}

}