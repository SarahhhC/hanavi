using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
namespace hana {

	public enum CardGameState { ready, gameover, player1, player2 }

	public class GameManager : MonoBehaviour {

		public CardGameState nowGameState = CardGameState.ready;
		public static GameManager instance;

		UIPanel player11, player22;
		UIPanel back;
		public UISprite p1, p2;
		public List<UISprite> backList1 = new List<UISprite>();
		public List<UISprite> player1List = new List<UISprite>();
		public List<UISprite> player2List = new List<UISprite>();

		public UIPanel choosePane;

		public UISprite pung;
		public UILabel pungNum;
		public UISprite hint;
		public UILabel hintNum;
		public UISprite trash;
		public UISprite click;
		public UILabel count;

		public UIPanel hintPane;
		public UISprite hintNumber, hintColor;
		public UIPanel numberPane;
		public UISprite n1, n2, n3, n4;
		public UIPanel colorPane;
		public UISprite red, white, yellow;

		public UIPanel setHintPane;
		public List<UILabel> NUM = new List<UILabel>();
		public List<UILabel> COLOR = new List<UILabel>();
		public UIPanel getHintPane;
		public List<UILabel> HINT_NUM = new List<UILabel>();
		public List<UILabel> HINT_COLOR = new List<UILabel>();
		public UIPanel answer;
		public UILabel answer_w, answer_y, answer_r;

		public int[] randList;
		public int lastindex;
		public UILabel message;
		public int clickCode;
		int waitTime;

		public UILabel gameover;
		public UILabel score;

		public int[] trashProb;
		public int[] pungProb;
		public int[] number;
		public int[] numberExist;
		public int[] color;
		public int[] colorExist;

		void Awake() {
			if (instance == null)
				instance = this;
		}

		void OnEnable() {
			InitCard();
		}

		void InitCard() {
			nowGameState = CardGameState.player1;
			p1.gameObject.SetActive(true);
			waitTime = 0;
			lastindex = 7;
			pungNum.text = "3";
			hintNum.text = "6";
			count.text = "13";
			answer_w.text = "0";
			answer_y.text = "0";
			answer_r.text = "0";
			for (int i = 0; i < 4; i++) {
				NUM[i].text = "";
				COLOR[i].text = "";
				HINT_NUM[i].text = "";
				HINT_COLOR[i].text = "";
			}
			choosePane.enabled = false;
			hintPane.enabled = false;
			numberPane.enabled = false;
			colorPane.enabled = false;
			setHintPane.enabled = false;
			getHintPane.enabled = false;
			gameover.enabled = false;
			score.enabled = false;

			trashProb = new int[]{0,0,0,0};
			pungProb = new int[]{0,0,0,0};
			number = new int[]{0,0,0,0};
			numberExist = new int[]{0,0,0,0};
			color = new int[]{0,0,0,0};
			colorExist = new int[]{0,0,0,0};

			Debug.Log("initcard");

			ArrayList List = new ArrayList();
			randList = new int[21];
			for (int a = 0; a < 21; a++) {
				List.Add(a);
			}
			System.Random rd = new System.Random();
			int index = 0;

			for (int i = 0; i < 21; i++) {
				index = rd.Next(List.Count);
				randList[i] = (int)List[index];
				List.RemoveAt(index);
				Debug.Log (randList[i]);
			}

			for (int j = 0; j < 4; j++) {
				player2List[j].spriteName = "" + randList[j];
				player1List[j].spriteName = "" + randList[j + 4];
			}
		}

		void Update() {
			
			switch (nowGameState) {
			case CardGameState.player1:
				p1.gameObject.SetActive(true);
				p2.gameObject.SetActive(false);
				choosePane.enabled = true;
				getHintPane.enabled = false;
				break;
			case CardGameState.player2:
				p1.gameObject.SetActive (false);
				p2.gameObject.SetActive (true);
				choosePane.enabled = false;
				choose ();
				break;
			case CardGameState.gameover:
				gameover.enabled = true;
				score.enabled = true;
				choosePane.enabled = false;
					
				int w_score = int.Parse (answer_w.text);
				int y_score = int.Parse (answer_y.text);
				int r_score = int.Parse (answer_r.text);
				int sum = w_score + y_score + r_score;
					score.text = "score " + sum;
					break;
			}
		}

		void choose() {
			int i = setHint.Instance.setHintPlayer1 ();
			if (waitTime == 0) {
				if (getHint.Instance.calculatePung() != -1) { //pung
					pung1();
					return;
				} else if (int.Parse (hintNum.text) >= 3) { //hint
					hint1(i);
					return;
				} else { //trash
					trash1();
					return;
				}
			}
		}
		
		void pung1() {
			int i = getHint.Instance.calculatePung ();
			player2List [i].enabled = false;
			int choose = int.Parse (player2List [i].spriteName);
			if (choose >= 0 && choose <= 2)
				answer_w.text = "1";
			if (choose >= 3 && choose <= 4)
				answer_w.text = "2";
			if (choose == 5)
				answer_w.text = "3";
			if (choose == 6)
				answer_w.text = "4";
			if (choose >= 7 && choose <= 9)
				answer_y.text = "1";
			if (choose >= 10 && choose <= 11)
				answer_y.text = "2";
			if (choose == 12)
				answer_y.text = "3";
			if (choose == 13)
				answer_y.text = "4";
			if (choose >= 14 && choose <= 16)
				answer_r.text = "1";
			if (choose >= 17 && choose <= 18)
				answer_r.text = "2";
			if (choose == 19)
				answer_r.text = "3";
			if (choose == 20)
				answer_r.text = "4";

			Debug.Log ("computer pung88");
			message.text = "pung!!";

			next (i);
		}

		void trash1() {
			int i = getHint.Instance.calculateTrash ();
			player2List [i].enabled = false;
			int hint = int.Parse (hintNum.text) + 1;
			hintNum.text = hint.ToString ();

			message.text = "trash!!";
			Debug.Log ("computer trash88");

			next (i);
		}

		void next(int i) {
			getHint.Instance.getNumberHintPlayer1 (i, 0);
			getHint.Instance.getColorHintPlayer1 (i, 0);
			for (int j = 0 ; j < 4 ; j++) {
				trashProb [j] = 0;
				pungProb [j] = 0;
			}
			lastindex = lastindex + 1;
			player2List[i].spriteName = "" + randList[lastindex];
			waitTime = 1;
			Invoke("TimeDelay", 2.0f);
		}

		void TimeDelay() {
			
			int count2 = int.Parse(count.text);
			count.text = (count2 - 1).ToString();
			message.text = "";
			if (checkGameOver ()) {
				waitTime = 0;
				player2List [0].enabled = true;
				player2List [1].enabled = true;
				player2List [2].enabled = true;
				player2List [3].enabled = true;

				nowGameState = CardGameState.player1;
			}
			else
				nowGameState = CardGameState.gameover;
		}

		void hint1(int i) {
			getHintPane.enabled = true;
			if (i > 0 && i < 5) {
				for (int q = 0; q < 4; q++) {
					int number = int.Parse (player1List [q].spriteName);
					if (i == 1) {
						if (number == 0 || number == 1 || number == 2 || number == 7 ||
						    number == 8 || number == 9 || number == 14 || number == 15 ||
						    number == 16) {
							HINT_NUM [q].text = "1";
							Debug.Log ("hint is 1 in" + q);
						}
					} else if (i == 2) {
						if (number == 3 || number == 4 || number == 10 || number == 11 ||
						    number == 17 || number == 18) {
							HINT_NUM [q].text = "2";
							Debug.Log ("hint is 2 in"+ q);
						}
					} else if (i == 3) {
						if (number == 5 || number == 12 || number == 19) {
							HINT_NUM [q].text = "3";
							Debug.Log ("hint is 3 in"+ q);
						}
					} else if (i == 4) {
						if (number == 6 || number == 13 || number == 20) {
							HINT_NUM [q].text = "4";
							Debug.Log ("hint is 4 in"+ q);
						}
					} else
						Debug.Log ("nothing00");
				}
			} else if (i >= 5) {
				for (int q = 0; q < 4; q++) {
					int number = int.Parse (player1List [q].spriteName);
					if (i == 5) {
						if (number >= 0 && number <= 6) {
							HINT_COLOR [q].text = "WHITE";
							Debug.Log ("hint is white in"+ q);
						}
					}
					else if (i == 6) {
						if (number >= 7 && number <= 13) {
							HINT_COLOR [q].text = "Yellow";
							Debug.Log ("hint is yellow in"+ q);
						}
					}
					else if (i == 7) {
						if (number >= 14 && number <= 20) {
							HINT_COLOR [q].text = "RED";
							Debug.Log ("hint is red in"+ q);
						}
					}
					else
						Debug.Log ("nothing11");
				}
			}
			int num = int.Parse (hintNum.text);
			hintNum.text = (num - 1).ToString ();
			message.text = "hint!!";

			hintDelay ();
		}

		void hintDelay() {
			waitTime = 1;
			Invoke("TimeDelay_hint", 2.0f);
		}
		
		void TimeDelay_hint() {
			
			for (int q = 0; q < 4; q++) { 
				HINT_NUM[q].text = "";
				HINT_COLOR[q].text = "";
			}
			waitTime = 0;
			message.text = "";
			Debug.Log ("lastindex: " + GameManager.instance.lastindex);
			nowGameState = CardGameState.player1;
		}

		bool checkGameOver() {
			string s = GameManager.instance.count.text;
			string s2 = GameManager.instance.pungNum.text;
			if (int.Parse(s) == 0) {
				return false;
			}
			if (int.Parse(s2) == -1) {
				return false;
			}
			return true;
		}

	}
}