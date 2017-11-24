using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData {

	public static List<int> activeQuest = new List<int>();
	public static List<int> finishedQuest = new List<int>();


	public static void AddQuest(int id){


		if (activeQuest.Contains (id)) {

			return;
		}

		activeQuest.Add (id);
	}
}
