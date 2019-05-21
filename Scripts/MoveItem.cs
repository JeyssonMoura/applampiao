using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : MonoBehaviour {

	public int idItem;
	public float posZ;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnMouseDrag () {
		Vector3 MousePosicao = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, posZ);
		Vector3 PosicaoObjeto = Camera.main.ScreenToWorldPoint (MousePosicao);
		this.transform.position = PosicaoObjeto;
	}
}
