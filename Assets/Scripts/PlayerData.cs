using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerData {

	public static Dictionary<int, ActiveQuest> activeQuests = new Dictionary<int, ActiveQuest>();
	public static List<int> finishedQuest = new List<int>();

	public static Dictionary<int, MonsterKills> mostersKilled = new Dictionary<int, MonsterKills>();


	public static void AddQuest(int id){


		if (activeQuests.ContainsKey (id)) {

			return;
		}

		// Otherwise, add new active Quest

		Quest quest = QuestManager.instance.questDictionary [id];
		ActiveQuest newActiveQuest = new ActiveQuest ();
		newActiveQuest.id = id;
		newActiveQuest.dateTaken = DateTime.Now.ToLongDateString ();

		if (quest.task.kills.Length > 0) {


			newActiveQuest.kills = new Quest.QuestKill[quest.task.kills.Length];

			foreach (Quest.QuestKill questkill in quest.task.kills) {

				newActiveQuest.kills [questkill.id] = new Quest.QuestKill ();

				if (!monstersKilled.ContainsKey (questkill.id))
					monsterKilled.Add (questkill.id, new PlayerData.MonsterKills ());


				newActiveQuest.kills[questKill.id].initialAmount = monstersKilled[questKill.id].amount;


			}
		}
		activeQuests.Add (id, newActiveQuest);
	}


	public class MonsterKills{


		public int id;
		public int amount;
	}


	public class ActiveQuest{

		public int id;
		public string dateTaken;
		public Quest.QuestKill[] kills;
	}
}
