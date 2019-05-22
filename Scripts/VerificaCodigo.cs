using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class VerificaCodigo : MonoBehaviour {

	//Aux
	private HUD AuxHUD;

	public InputField codigo;

	void Start () {
		AuxHUD = GameObject.Find ("Canvas_HUD").GetComponent<HUD>();
	}

	public void EnviarCodigo () {
		if (Application.internetReachability != NetworkReachability.NotReachable) {
			if (codigo.text != "") {
				AuxHUD.CarregarNovaCena ("Jogo");
				AuxHUD.abrirBoxAvisos ("Código válido!", 2);
				/*WWWForm form = new WWWForm ();
				form.AddField ("codigo", codigo.text);
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
			
		} else {
			
		}
	}

}