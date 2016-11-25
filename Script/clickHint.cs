using UnityEngine;
using System.Collections;
using hana;

public class clickHint : MonoBehaviour {

	public void OnClick() {
		
		GameManager.instance.hintPane.GetComponent<UIPanel>().enabled = true;
		int num = int.Parse(GameManager.instance.hintNum.text);
		GameManager.instance.hintNum.text = (num - 1).ToString();
	}
}
