using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoveItem : MonoBehaviour {

	//Aux
	private HUD AuxHUD;

	public int idItem;
	public float posZ;
	private bool statusItem = false;
	private int click = 0;

	void Start () {
		AuxHUD = GameObject.Find ("Canvas_HUD").GetComponent<HUD>();
	}

	void Update () {
		if (statusItem && AuxHUD.boxHistoria.GetComponent<Canvas> ().enabled == false) {
			AuxHUD.boxMenuItens.GetComponent<Canvas> ().enabled = true;
			AuxHUD.boxMenuItens.GetComponent<GraphicRaycaster> ().enabled = true;
		} else {
			AuxHUD.boxMenuItens.GetComponent<Canvas> ().enabled = false;
			AuxHUD.boxMenuItens.GetComponent<GraphicRaycaster> ().enabled = false;
		}
		if (Input.GetKey (KeyCode.Mouse0) && click == 0) {
			OnMouseDrag ();
		} else {
			if (Input.GetKeyUp (KeyCode.Mouse0)){
				click = 1;
			}
		}
	}

	void OnMouseDrag () {
		if (!statusItem) {
			AuxHUD.itemSelecionado = idItem;
			Vector3 MousePosicao = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, posZ);
			Vector3 PosicaoObjeto = Camera.main.ScreenToWorldPoint (MousePosicao);
			this.transform.position = PosicaoObjeto;
		}
	}

	void OnTriggerEnter2D (Collider2D ColItem) {
		if (ColItem.name == "P" + idItem) {
			transform.position = ColItem.transform.position;
			AuxHUD.ExibirMensagem ();
			statusItem = true;
		}
	}

}