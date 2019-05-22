using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dados : MonoBehaviour {

	//Aux
	private HUD AuxHUD;

	public InputField ctMotivo;
	private int respostaSN;
	private string motivo;

	void Start () {
		
	}

	void Update () {
		
	}

	public void setRespostaSN (int _respostaSN) {
		respostaSN = _respostaSN;
	}

	public int getRespostaSN () {
		return respostaSN;
	}

	public void setMotivo (string _motivo) {
		motivo = _motivo;
	}

	public string getMotivo () {
		return motivo;
	}

	public void EnviarDados () {
		if (Application.internetReachability != NetworkReachability.NotReachable) {
			if (ctMotivo.text != "") {
				setMotivo (ctMotivo.text);
				AuxHUD.abrirBoxAvisos ("Resposta Enviada com sucesso!", 2);
				/*WWWForm form = new WWWForm ();
				form.AddField ("resposta", getRespostaSN().ToString());
				form.AddField ("motivo", getMotivo());
				WWW EnviarDados = new WWW ("url do site", form);
				StartCoroutine (DadosE (EnviarDados));*/
			} else {
				AuxHUD.abrirBoxAvisos ("Preencha todos os campos!", 1);
			}
		} else {
			AuxHUD.abrirBoxAvisos ("Não está conectado a internet!", 1);
		}
	}

	IEnumerator DadosE (WWW DadosR) {
		yield return DadosR;
		string status = DadosR.text;
		if (status == "") {

		} else {

		}
	}

}