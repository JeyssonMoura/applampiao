using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour {

	public string[] historiaItem;
	public GameObject[] boxHistoria;
	public GameObject boxAlerta, carregandoCenaHUD;
	public int itemSelecionado;
	private float tempoBox, carregando;

	void Start () {
		
	}

	void Update () {
		
	}

	public void Sair () {
		Application.Quit ();
	}

	public void CarregarNovaCena (string nomeCena) {
		StartCoroutine (CarregarCena (nomeCena));
	}

	public void abrirBoxAvisos (string aviso, int tipo) {
		switch (tipo) {
		//Alerta
		case 0:
			boxAlerta.transform.GetChild(0).transform.GetChild(0).GetComponent<Text> ().color = Color.yellow;
			break;
		//Error
		case 1:
			boxAlerta.transform.GetChild(0).transform.GetChild(0).GetComponent<Text> ().color = Color.red;
			break;
		//Sucesso
		case 2:
			boxAlerta.transform.GetChild(0).transform.GetChild(0).GetComponent<Text> ().color = Color.green;
			break;
		}
		boxAlerta.transform.GetChild(0).transform.GetChild(0).GetComponent<Text> ().text = aviso;
		StartCoroutine ("Avisos");
	}

	IEnumerator Avisos () {
		boxAlerta.GetComponent<Canvas> ().enabled = true;
		yield return new WaitForSeconds(2.5f);
		boxAlerta.GetComponent<Canvas> ().enabled = false;
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