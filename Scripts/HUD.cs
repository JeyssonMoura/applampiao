using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class HUD : MonoBehaviour {

	//Aux
	private VerificaCodigo AuxVerificaCodigo;

	public string[] historiaItem;
	public GameObject[] itens, meusItens;
	public GameObject boxHistoria, boxAlerta, boxMenuItens, boxSair, barraTempo, carregandoCenaHUD;
	public InputField ctMotivo, ctCodigo;
	public int itemSelecionado;
	private float tempoBox, carregando;

	void Start () {
		AuxVerificaCodigo = GameObject.FindGameObjectWithTag("VCodigo").GetComponent<VerificaCodigo>();
	}

	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape)) {
			boxSair.GetComponent<Canvas> ().enabled = true;
			boxSair.GetComponent<GraphicRaycaster> ().enabled = true;
		}
		//Tempo Box Menssagem
		if (boxHistoria != null) {
			if (tempoBox >= 1 && tempoBox <= 5) {
				tempoBox += Time.deltaTime;
				barraTempo.GetComponent<Image> ().fillAmount = tempoBox / 5;
			} else {
				tempoBox = 0;
				boxHistoria.transform.GetChild(2).GetComponent<Button> ().interactable = true;
			}
		}
	}

	public void ClickEntrar () {
		AuxVerificaCodigo.EnviarCodigo ();
	}

	public void ClickItemMenu (int idItem) {
		if (meusItens [idItem] == null) {
			meusItens [idItem] = (GameObject)Instantiate (itens [idItem], transform.position, transform.rotation);
		}
	}

	public void DesativaBotao (GameObject botao) {
		botao.GetComponent<Button> ().interactable = false;
		botao.transform.GetChild(0).GetComponent<Image> ().enabled = false;
	}

	public void ExibirMensagem () {
		tempoBox = 1;
		boxHistoria.GetComponent<Canvas> ().enabled = true;
		boxHistoria.GetComponent<GraphicRaycaster> ().enabled = true;
		boxHistoria.transform.GetChild(2).GetComponent<Button> ().interactable = false;
		boxHistoria.transform.GetChild(0).GetComponent<Text>().text = historiaItem[itemSelecionado];
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