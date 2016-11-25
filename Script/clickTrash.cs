using UnityEngine;
using System.Collections;
using hana;

public class clickTrash : MonoBehaviour {

	public void OnClick() {

		GameManager.instance.message.text = "click card to trash";
		GameManager.instance.clickCode = 1;

	}
}
