using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using hana;

public class getHint : MonoBehaviour {

	private static getHint instance;
	int[] number = GameManager.instance.number;
	int[] numberExist = GameManager.instance.numberExist;
	int[] color = GameManager.instance.color;
	int[] colorExist = GameManager.instance.colorExist;
	int[] trashProb = GameManager.instance.trashProb;
	int[] pungProb = GameManager.instance.pungProb;

	public static getHint Instance {
		get {
			if (instance == null)
				instance = new getHint ();
			return instance;
		}
	}

	public void getNumberHintPlayer1(int i, int num) {
		number[i] = num;
		numberExist[i] = 1;
	}

	public void getColorHintPlayer1(int i, int col) {
		//white 1 yelllow 2 red 3
		color[i] = col;
		colorExist[i] = 1;
	}

	public int calculateTrash() {
		for (int i = 0; i < 4; i++) {
			trashProb[i] = numberExist[i] + colorExist[i];
		}
		for (int i = 0; i < 4; i++) {
			if (trashProb[i] == 0)
				return i;
		}
		for (int i = 0; i < 4; i++) {
			if (trashProb[i] == 1)
				return i;
		}
		for (int i = 0; i < 4; i++) {
			if (trashProb[i] == 2)
				return i;
		}
		return 0;
	}

	public int calculatePung() {
		
		calPungProb ();

		if (pungProb[0] == 100)
			return 0;
		else if (pungProb[1] == 100)
			return 1;
		else if (pungProb[2] == 100)
			return 2;
		else if (pungProb[3] == 100)
			return 3;
		else
			return -1;
	}

	void calPungProb() {
		int w = int.Parse(GameManager.instance.answer_w.text);
		int y = int.Parse(GameManager.instance.answer_y.text);
		int r = int.Parse(GameManager.instance.answer_r.text);

		Debug.Log ("calpungprob" + number[0]+number[1]+number[2]+number[3]);
		for (int i = 0; i < 4; i++) {
			if ((w == 0 && y == 0 && r == 0) && (number [i] == 1))
				pungProb [i] = 100;
			
			if (w == 1 && y == 0 && r == 0 && number [i] == 1 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 0 && number [i] == 1 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 0 && number [i] == 1 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 0 && number [i] == 1 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 0 && y == 0 && r == 1 && number [i] == 1 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 0 && r == 1 && number [i] == 1 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 0 && number [i] == 2 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 0 && number [i] == 2 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 0 && y == 0 && r == 1 && number [i] == 2 && color [i] == 3)
				pungProb [i] = 100;

			if (w == 1 && y == 1 && r == 0 && number [i] == 1 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 1 && number [i] == 1 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 1 && number [i] == 1 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 1 && y == 1 && r == 0 && number [i] == 2 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 1 && y == 1 && r == 0 && number [i] == 2 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 1 && number [i] == 2 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 1 && number [i] == 2 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 1 && number [i] == 2 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 1 && number [i] == 2 && color [i] == 3)
				pungProb [i] = 100;

			if (w == 1 && y == 1 && r == 1 && number [i] == 2)
				pungProb [i] = 100;

			if (w == 2 && y == 0 && r == 0 && number [i] == 1 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 2 && y == 0 && r == 0 && number [i] == 1 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 0 && y == 2 && r == 0 && number [i] == 1 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 2 && r == 0 && number [i] == 1 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 0 && y == 0 && r == 2 && number [i] == 1 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 0 && r == 2 && number [i] == 1 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 2 && y == 0 && r == 0 && number [i] == 3 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 2 && r == 0 && number [i] == 3 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 0 && y == 0 && r == 2 && number [i] == 3 && color [i] == 3)
				pungProb [i] = 100;

			if (w == 1 && y == 2 && r == 0 && number [i] == 1 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 1 && y == 2 && r == 0 && number [i] == 2 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 1 && y == 2 && r == 0 && number [i] == 3 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 2 && number [i] == 1 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 2 && number [i] == 2 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 1 && y == 0 && r == 2 && number [i] == 3 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 2 && y == 1 && r == 0 && number [i] == 1 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 2 && y == 1 && r == 0 && number [i] == 2 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 2 && y == 1 && r == 0 && number [i] == 3 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 2 && y == 0 && r == 1 && number [i] == 1 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 2 && y == 0 && r == 1 && number [i] == 2 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 2 && y == 0 && r == 1 && number [i] == 3 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 2 && number [i] == 1 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 2 && number [i] == 2 && color [i] == 2)
				pungProb [i] = 100;
			if (w == 0 && y == 1 && r == 2 && number [i] == 3 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 0 && y == 2 && r == 1 && number [i] == 1 && color [i] == 1)
				pungProb [i] = 100;
			if (w == 0 && y == 2 && r == 1 && number [i] == 2 && color [i] == 3)
				pungProb [i] = 100;
			if (w == 0 && y == 2 && r == 1 && number [i] == 3 && color [i] == 2)
				pungProb [i] = 100;

			if ((w == 1 && y == 1 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 1) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 1) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 1 && r == 2) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 1) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 1) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 1 && r == 2) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 2 && y == 2 && r == 0) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 0 && r == 2) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 2 && r == 0) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 0 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 0 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 2 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 2 && r == 2) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 0 && r == 2) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;

			if ((w == 2 && y == 2 && r == 1) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 2) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 2 && r == 1) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 2 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 2) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 2) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;

			if ((w == 2 && y == 2 && r == 2) && (number [i] == 3))
				pungProb [i] = 100;

			if ((w == 3 && y == 0 && r == 0) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 0 && y == 3 && r == 0) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 0 && r == 3) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 0 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 3 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 0 && r == 3) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 0 && r == 0) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 3 && r == 0) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 0 && y == 0 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 1 && y == 1 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 1) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 1) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 1 && r == 3) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 1) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 1) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 1 && r == 3) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 2 && y == 2 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 2) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 2) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 2 && r == 3) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 2) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 2 && r == 3) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 1 && y == 3 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 0) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 0) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 0 && r == 3) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 0 && r == 3) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 0 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 0) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 0) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 0 && r == 1) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 0 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 0 && r == 1) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 1 && r == 3) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 1 && r == 3) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 0 && y == 1 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 3 && r == 1) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 3 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 3 && r == 1) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;

			if ((w == 1 && y == 3 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 2) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 2) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 3) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 3) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 2) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 2) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 1) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 1) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 3) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 3) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 1) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 1) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;

			if ((w == 3 && y == 3 && r == 1) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 3) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 3) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 3 && r == 1) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 3 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 3) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 3) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;

			if ((w == 3 && y == 3 && r == 2) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 3) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 3) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 3 && r == 2) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 3 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 3) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 3) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;

			if ((w == 3 && y == 3 && r == 3) && (number [i] == 4))
				pungProb [i] = 100;

			if ((w == 4 && y == 0 && r == 0) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 0 && y == 4 && r == 0) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 0 && r == 4) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 0 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 4 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 0 && r == 4) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;

			if ((w == 1 && y == 1 && r == 4) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 1) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 4 && r == 1) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 1 && r == 4) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 4 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 1 && y == 4 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 4 && r == 0) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 0 && r == 4) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 0 && r == 4) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 0) && (number [i] == 1 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 0) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 0 && r == 1) && (number [i] == 1 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 0 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 0 && y == 1 && r == 4) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 1 && r == 4) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 0 && y == 4 && r == 1) && (number [i] == 1 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 0 && y == 4 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 1 && y == 4 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 4 && r == 2) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 4) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 2 && r == 4) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 2) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 2 && r == 1) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 2 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 4) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 1 && r == 4) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 4 && r == 1) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 4 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 1 && y == 4 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 1 && y == 4 && r == 3) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 4) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 1 && y == 3 && r == 4) && (number [i] == 2 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 4 && y == 1 && r == 3) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 3 && r == 1) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 3 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 4) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 1 && r == 4) && (number [i] == 2 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 4 && r == 1) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 4 && r == 1) && (number [i] == 2 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 2 && y == 4 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 4 && r == 3) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 4) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 3 && r == 4) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 2 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 4 && y == 2 && r == 3) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 3 && r == 2) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 3 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 4) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 2 && r == 4) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 4 && r == 2) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 4 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 2 && y == 2 && r == 4) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 2 && y == 4 && r == 2) && (number [i] == 3 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 2 && y == 2 && r == 4) && (number [i] == 3 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 2 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 2 && y == 4 && r == 2) && (number [i] == 3 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 3 && y == 3 && r == 4) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 3 && r == 3) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 3 && y == 4 && r == 3) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 3 && y == 3 && r == 4) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
			if ((w == 4 && y == 3 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 4 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;

			if ((w == 4 && y == 4 && r == 3) && (number [i] == 4 && color [i] == 3))
				pungProb [i] = 100;
			if ((w == 3 && y == 4 && r == 4) && (number [i] == 4 && color [i] == 1))
				pungProb [i] = 100;
			if ((w == 4 && y == 3 && r == 4) && (number [i] == 4 && color [i] == 2))
				pungProb [i] = 100;
		}
		
	}
}