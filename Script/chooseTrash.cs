using UnityEngine;
using System.Collections;
using hana;

public class chooseTrash : MonoBehaviour {
	
	public int choose;
	public static string gName;
	
	private static chooseTrash instance;
	
	public static chooseTrash Instance {
		get {
			if (instance == null)
				instance = new chooseTrash();
			return instance;
		}
	}
	
	public void OnClick(UISprite g) {
		GameManager.instance.message.text = "";
		if (GameManager.instance.clickCode == 1) {
			choose = int.Parse (g.spriteName);
			gName = g.name;

			if (gName == "p1")
				GameManager.instance.backList1 [0].GetComponent<UISprite> ().enabled = false;
			if (gName == "p2")
				GameManager.instance.backList1 [1].GetComponent<UISprite> ().enabled = false;
			if (gName == "p3")
				GameManager.instance.backList1 [2].GetComponent<UISprite> ().enabled = false;
			if (gName == "p4")
				GameManager.instance.backList1 [3].GetComponent<UISprite> ().enabled = false;
		
			increaseHint (choose);
		
			next ();
		}
	}
	
	void next() {
		Invoke("TimeDelay", 2.0f);
	}

	void TimeDelay() {
		GameManager.instance.click.gameObject.SetActive (true);
	}
	
	private void increaseHint(int a) {
		int num = int.Parse(GameManager.instance.hintNum.text);
		GameManager.instance.hintNum.text = (num + 1).ToString();
	}

}
