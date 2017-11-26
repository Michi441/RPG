using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerData {

	public static Dictionary<int, ActiveQuest> activeQuests = new Dictionary<int, ActiveQuest>();
	public static List<int> finishedQuest = new List<int>();

	public static Dictionary<int, MonsterKills> monsterKilled = new Dictionary<int, MonsterKills> ();



	//public static Dictionary<int, MonsterKills> monstersKilled = new Dictionary<int, MonsterKills>();


	public static void AddQuest(int id){


		if (activeQuests.ContainsKey (id)) { 

			return;
		}

		Quest quest = QuestManager.instance.questDictionary [id];
		ActiveQuest newActiveQuest = new ActiveQuest ();
		newActiveQuest.id = id;
		newActiveQuest.dateTaken = DateTime.Now.ToLongDateString ();


		if (quest.task.kills.Length > 0) {

			newActiveQuest.kills = new Quest.QuestKill[quest.task.kills.Length];

			foreach (Quest.QuestKill questKill in quest.task.kills) {


				newActiveQuest.kills [questKill.id] = new Quest.QuestKill ();

				if (!monsterKilled.ContainsKey (questKill.id)) {


					monsterKilled.Add (questKill.id, new PlayerData.MonsterKills ());
				}
				newActiveQuest.kills [questKill.id].playerCurrent = monsterKilled [questKill.id].amount;
			}
		}
		// Otherwise, add new active Quest
		activeQuests.Add(id, newActiveQuest);
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
