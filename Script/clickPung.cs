using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using hana;

public class clickPung : MonoBehaviour {

	public void OnClick() {

		GameManager.instance.message.text = "click card to pung";
		GameManager.instance.clickCode = 0;
	}

}
