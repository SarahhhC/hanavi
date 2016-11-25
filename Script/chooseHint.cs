using UnityEngine;
using System.Collections;
using hana;

public class chooseHint : MonoBehaviour {

	public void OnClick(UISprite g) {
		int remainHint = int.Parse (GameManager.instance.hintNum.text);
		if (remainHint > -1) {
			if (g.name == "hintNum")
				getNumberHint ();
			if (g.name == "hintColor")
				getColorHint ();
			GameManager.instance.hintPane.GetComponent<UIPanel> ().enabled = false;
		}
	}

	void getNumberHint() {
		GameManager.instance.numberPane.GetComponent<UIPanel>().enabled = true;
		GameManager.instance.colorPane.GetComponent<UIPanel>().enabled = false;
	}

	void getColorHint() {
		GameManager.instance.colorPane.GetComponent<UIPanel>().enabled = true;
		//GameManager.instance.numberPane.GetComponent<UIPanel>().enabled = false;
	}
}
