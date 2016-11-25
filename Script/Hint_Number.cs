using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using hana;

public class Hint_Number : MonoBehaviour {

	public void informNumber(UISprite u) {
		GameManager.instance.numberPane.GetComponent<UIPanel>().enabled = false;
		GameManager.instance.setHintPane.GetComponent<UIPanel> ().enabled = true;

		if (u.name == "n1")
			findNumber(1);
		if (u.name == "n2") 
			findNumber(2);
		if (u.name == "n3") 
			findNumber(3);
		if (u.name == "n4") 
			findNumber(4);
		next ();
	}

	void next() {
		Invoke("TimeDelay", 2.0f);
	}
	
	void TimeDelay() {
		for (int i = 0; i < 4; i++) {
			GameManager.instance.NUM[i].text = "";
		}
		GameManager.instance.nowGameState = CardGameState.player2;
	}
	
	void findNumber(int n) {
		
		for (int i = 0; i < 4; i++) {
			int number = int.Parse(GameManager.instance.player2List[i].spriteName);
			if (n == 1) {
				if (number == 0||number ==1||number ==2||number ==7||number ==8||number ==9||number ==14||number ==15||number ==16) {
					GameManager.instance.NUM[i].text = "1";
					getHint.Instance.getNumberHintPlayer1(i,n);
				}
			}
			if (n == 2) {
				if (number == 3||number ==4||number ==10||number ==11||number ==17||number ==18) {
					GameManager.instance.NUM[i].text = "2";
					getHint.Instance.getNumberHintPlayer1(i,n);
				}
			}
			if (n == 3) {
				if (number == 5||number ==12||number ==19) {
					GameManager.instance.NUM[i].text = "3";
					getHint.Instance.getNumberHintPlayer1(i,n);
				}
			}
			if (n == 4) {
				if (number == 6||number ==13||number ==20) {
					GameManager.instance.NUM[i].text = "4";
					getHint.Instance.getNumberHintPlayer1(i,n);
				}
			}
		}
	}
}
