using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AddXP {

	public static float ExperienceForNextLevel(int currentlevel){


		if (currentlevel == 0)
			return 0;
		return (currentlevel * currentlevel + currentlevel + 3) * 4;
	}


}
