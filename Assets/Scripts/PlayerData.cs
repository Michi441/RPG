using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerData {

	public static List<int> activeQuests = new List<int>();
	public static List<int> finishedQuest = new List<int>();

	//public static Dictionary<int, MonsterKills> monstersKilled = new Dictionary<int, MonsterKills>();


	public static void AddQuest(int id){


		if (activeQuests.Contains (id)) {

			return;
		}

		// Otherwise, add new active Quest
		activeQuests.Add(id);
}


}
