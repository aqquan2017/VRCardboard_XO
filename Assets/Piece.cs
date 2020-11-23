using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	public GameObject pieceX;
	public GameObject pieceO;

	public bool defined;
	public int value = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CleanSelection () {
		defined = false;
		value = 0;
		pieceX.SetActive (false);
		pieceO.SetActive (false);
	}

	public void PlayerSelect () {
		defined = true;
		value = 1;
		pieceX.SetActive (true);
	}

	public void ComputerSelect () {
		defined = true;
		value = 2;
		pieceO.SetActive (true);
	}
}
