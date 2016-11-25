using UnityEngine;
using System.Collections;
using hana;

public class getNewCard : MonoBehaviour {

	public void NewCard() {
		string count = GameManager.instance.count.text;
		int now = int.Parse(count);
		GameManager.instance.count.text = (now - 1).ToString();
		if (checkGameOver ()) {
			GameManager.instance.backList1 [0].GetComponent<UISprite> ().enabled = true;
			GameManager.instance.backList1 [1].GetComponent<UISprite> ().enabled = true;
			GameManager.instance.backList1 [2].GetComponent<UISprite> ().enabled = true;
			GameManager.instance.backList1 [3].GetComponent<UISprite> ().enabled = true;


			string g = getGname ();

			GameManager.instance.lastindex = GameManager.instance.lastindex + 1;
			Debug.Log ("!!!lastindex: " + g + GameManager.instance.lastindex);
			int num = GameManager.instance.lastindex;

			if (g == "p1")
				GameManager.instance.player1List [0].GetComponent<UISprite> ().spriteName = "" + GameManager.instance.randList [num];
			else if (g == "p2")
				GameManager.instance.player1List [1].GetComponent<UISprite> ().spriteName = "" + GameManager.instance.randList [num];
			else if (g == "p3")
				GameManager.instance.player1List [2].GetComponent<UISprite> ().spriteName = "" + GameManager.instance.randList [num];
			else if (g == "p4")
				GameManager.instance.player1List [3].GetComponent<UISprite> ().spriteName = "" + GameManager.instance.randList [num];

			GameManager.instance.click.gameObject.SetActive (false);
			GameManager.instance.nowGameState = CardGameState.player2;
		}
		else
			GameManager.instance.nowGameState = CardGameState.gameover;
	}

	string getGname (){
		string g = "";
		if (GameManager.instance.clickCode == 1) {
			g = chooseTrash.gName;
		}
		if (GameManager.instance.clickCode == 0) {
			g = choosePungCard.gName;
		}
		return g;
	}

	bool checkGameOver() {
		string s = GameManager.instance.count.text;
		string s2 = GameManager.instance.pungNum.text;
		if (int.Parse(s) == 0) {
			GameManager.instance.nowGameState = CardGameState.gameover;
			return false;
		}
		if (int.Parse(s2) == -1) {
			GameManager.instance.nowGameState = CardGameState.gameover;
			return false;
		}
		return true;
	}

}
