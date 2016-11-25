using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using hana;

public class Hint_Color : MonoBehaviour {
	public getHint g;

	public void informColor(UISprite u) {
		GameManager.instance.colorPane.GetComponent<UIPanel>().enabled = false;
		GameManager.instance.setHintPane.GetComponent<UIPanel> ().enabled = true;
		g = new getHint ();
		if (u.name == "w")
			findColor(1);
		if (u.name == "y") 
			findColor(2);
		if (u.name == "r") 
			findColor(3);
		next ();
	}
	
	void next() {
		Invoke("TimeDelay", 2.0f);
	}
	
	void TimeDelay() {
		for (int i = 0; i < 4; i++) {
			GameManager.instance.COLOR[i].text = "";
		}
		GameManager.instance.nowGameState = CardGameState.player2;
	}

	private void findColor(int n) {
		for (int i = 0; i < 4; i++) {
			int number = int.Parse(GameManager.instance.player2List[i].spriteName);
			if (n == 1) {
				if (number >= 0 && number <= 6) {
					GameManager.instance.COLOR[i].text = "WHITE";
					g.getColorHintPlayer1(i,n);
				}
			}
			if (n == 2) {
				if (number >= 7 && number <= 13) {
					GameManager.instance.COLOR[i].text = "Yellow";
					g.getColorHintPlayer1(i,n);
				}
			}
			if (n == 3) {
				if (number >= 14 && number <= 20) {
					GameManager.instance.COLOR[i].text = "RED";
					g.getColorHintPlayer1(i,n);
				}
			}
		}
	}
}
