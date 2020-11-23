using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player;
	public Piece[] pieces;
	public TextMesh infoText;

	public bool isGameOver = false;
	private float resetTimer = 3f;

	// Use this for initialization
	void Start () {
		player.onSelectedPiece = () => {
			OnPlayerSelected();
		};

		foreach (Piece piece in pieces) {
			piece.CleanSelection ();
		}

		PickRandomPiece ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isGameOver == true) {
			player.locked = true;

			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			}
		} else {
			infoText.text = "Beat the computer!";
		}
	}

	void OnPlayerSelected () {
		CheckBoard ();

		if (isGameOver == false) {
			PickRandomPiece ();
			CheckBoard ();
		}
	}

	void PickRandomPiece () {
		int availablePieces = 0;
		foreach (Piece piece in pieces) {
			if (piece.defined == false) {
				availablePieces++;
			}
		}

		if (availablePieces > 0) {
			Piece randomPiece = pieces[Random.Range(0, pieces.Length)];
			while (randomPiece.defined == true) {
				randomPiece = pieces[Random.Range(0, pieces.Length)];
			}

			randomPiece.ComputerSelect ();
		}
	}

	void CheckBoard() {
		// Horizontal check
		for (int y = 0; y < 3; y++) {
			Piece pieceCheck = null;
			int matches = 0;

			for (int x = 0; x < 3; x++) {
				Piece currentPiece = pieces[y * 3 + x];

				if (pieceCheck == null) {
					if (currentPiece.value != 0) {
						pieceCheck = currentPiece;
						matches++;
					}
				} else if (currentPiece.value == pieceCheck.value) {
					matches++;
				}
			}

			if (matches == 3) {
				if (pieceCheck.value == 1) {
					infoText.text = "You win!";
				} else {
					infoText.text = "You lose!";
				}
				isGameOver = true;
				return;
			}
		}

		// Vertical check
		for (int y = 0; y < 3; y++) {
			Piece pieceCheck = null;
			int matches = 0;

			for (int x = 0; x < 3; x++) {
				Piece currentPiece = pieces[x * 3 + y];

				if (pieceCheck == null) {
					if (currentPiece.value != 0) {
						pieceCheck = currentPiece;
						matches++;
					}
				} else if (currentPiece.value == pieceCheck.value) {
					matches++;
				}
			}

			if (matches == 3) {
				if (pieceCheck.value == 1) {
					infoText.text = "You win!";
				} else {
					infoText.text = "You lose!";
				}
				isGameOver = true;
				return;
			}
		}
	}
}
