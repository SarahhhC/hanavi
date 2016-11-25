using UnityEngine;
using System.Collections;
using hana;

public class setHint : MonoBehaviour {

	private static setHint instance;

	public static setHint Instance {
		get {
			if (instance == null)
				instance = new setHint ();
			return instance;
		}
	}

	public int choose;
	int same_w, same_y, same_r;
	int same1, same2, same3, same4;

	public int setHintPlayer1() {
		int same_w = 0;
		int same_y = 0;
		int same_r = 0;
		int same1 = 0;
		int same2 = 0;
		int same3 = 0;
		int same4 = 0;

		for (int i = 0; i < 4; i++) {
			choose = int.Parse(GameManager.instance.player1List[i].spriteName);
			if (choose >= 0 && choose <= 6)
				same_w = same_w + 1;
			if (choose >= 7 && choose <= 13)
				same_y = same_y + 1;
			if (choose >= 14 && choose <= 20)
				same_r = same_r + 1;
		}

		for (int i = 0; i < 4; i++) {
			choose = int.Parse(GameManager.instance.player1List[i].spriteName);
			if ((choose >= 0 && choose <= 2)||(choose >= 7 && choose <= 9)||(choose >= 14 && choose <= 16))
				same1 = same1 + 1;
			if ((choose >= 3 && choose <= 4)||(choose >= 10 && choose <= 11)||(choose >= 17 && choose <= 18))
				same2 = same2 + 1;
			if (choose == 5 || choose == 12 || choose == 19)
				same3 = same3 + 1;
			if (choose == 6 || choose == 13 || choose == 20)
				same4 = same4 + 1;
		}

		System.Random rd = new System.Random();
		int index = rd.Next(2);

		if (index == 0) {
			return max1(same1,same2,same3,same4);
		}
		if (index == 1) {
			return max2(same_w,same_y,same_r);
		}
		return 0;

	}

	public int max1(int same1,int same2,int same3,int same4) {
		if (same1 >= same2 && same1 >= same3 && same1 >= same4)
			return 1;
		else if (same2 >= same3 && same2 >= same4)
			return 2;
		else if (same3 >= same4)
			return 3;
		else
			return 4;
	}

	int max2(int same1,int same2,int same3) {
		if (same1 >= same2 && same1 >= same3)
			return 5;
		else if (same2 >= same3)
			return 6;
		else
			return 7;
	}
}
