using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

	public Action onSelectedPiece;
	public bool locked = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrPointerInputModule.Pointer.TriggerDown || Input.GetKeyDown("space")) {
			RaycastHit hit;

			if (Physics.Raycast(transform.position, transform.forward, out hit)) {
				if (hit.transform.GetComponent<Piece> () != null) {
					Piece piece = hit.transform.GetComponent<Piece>();

					if (locked == false && piece.defined == false) {
						piece.PlayerSelect ();
						onSelectedPiece ();
					}
				}
			}
		}
	}
}
