using UnityEngine;
using System.Collections;
using hana;

public class choosePungCard : MonoBehaviour {

	public int choose;
	public static string gName;

	private static choosePungCard instance;

	public static choosePungCard Instance {
		get {
			if (instance == null)
				instance = new choosePungCard();
			return instance;
		}
	}

	public void OnClick(UISprite g) {
		GameManager.instance.message.text = "";
		if (GameManager.instance.clickCode == 0) {
			choose = int.Parse (g.spriteName);
			gName = g.name;

			if (g.name == "p1")
				GameManager.instance.backList1 [0].GetComponent<UISprite> ().enabled = false;
			if (g.name == "p2")
				GameManager.instance.backList1 [1].GetComponent<UISprite> ().enabled = false;
			if (g.name == "p3")
				GameManager.instance.backList1 [2].GetComponent<UISprite> ().enabled = false;
			if (g.name == "p4")
				GameManager.instance.backList1 [3].GetComponent<UISprite> ().enabled = false;

			int w = int.Parse (GameManager.instance.answer_w.text);
			int y = int.Parse (GameManager.instance.answer_y.text);
			int r = int.Parse (GameManager.instance.answer_r.text);

			if (choose >= 0 && choose <= 6) { //white
				if ((w == 0) && (choose == 0 || choose == 1 || choose == 2))
					GameManager.instance.answer_w.text = (w + 1).ToString ();
				else if ((w == 1) && (choose == 3 || choose == 4))
					GameManager.instance.answer_w.text = (w + 1).ToString ();
				else if ((w == 2) && (choose == 5))
					GameManager.instance.answer_w.text = (w + 1).ToString ();
				else if ((w == 3) && (choose == 6))
					GameManager.instance.answer_w.text = (w + 1).ToString ();
				else
					decreasePung (choose);
			} else if (choose >= 7 && choose <= 13) { //yellow
				if ((y == 0) && (choose == 7 || choose == 8 || choose == 9))
					GameManager.instance.answer_y.text = (y + 1).ToString ();
				else if ((y == 1) && (choose == 10 || choose == 11))
					GameManager.instance.answer_y.text = (y + 1).ToString ();
				else if ((y == 2) && (choose == 12))
					GameManager.instance.answer_y.text = (y + 1).ToString ();
				else if ((y == 3) && (choose == 13))
					GameManager.instance.answer_y.text = (y + 1).ToString ();
				else
					decreasePung (choose);
			} else if (choose >= 14 && choose <= 20) { //red
				if ((r == 0) && (choose == 14 || choose == 15 || choose == 16))
					GameManager.instance.answer_r.text = (r + 1).ToString ();
				else if ((r == 1) && (choose == 17 || choose == 18))
					GameManager.instance.answer_r.text = (r + 1).ToString ();
				else if ((r == 2) && (choose == 19))
					GameManager.instance.answer_r.text = (r + 1).ToString ();
				else if ((r == 3) && (choose == 20))
					GameManager.instance.answer_r.text = (r + 1).ToString ();
				else
					decreasePung (choose);
			} 
				
			next ();
		}
	}

	void next() {
		Invoke("TimeDelay", 2.0f);
	}
	
	void TimeDelay() {
		GameManager.instance.click.gameObject.SetActive (true);
	}

	private void decreasePung(int a) {
		int num = int.Parse(GameManager.instance.pungNum.text);
		GameManager.instance.pungNum.text = (num - 1).ToString();
		Debug.Log("else" + a);
	}

}
