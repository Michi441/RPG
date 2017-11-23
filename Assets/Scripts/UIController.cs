using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController instance;
	public Transform canvas;

	// Use this for initialization
	void Awake () {

		if (!instance) {
			instance = this;
			canvas = GameObject.Find ("Canvas").transform;
		}
	}



	public void ShowQuestInfo(Quest quest){


		Transform info = GameObject.Find ("QuestInfo").transform;
		info.Find ("QuestName").GetComponent<Text> ().text = quest.QuestName;
		info.Find ("QuestDescription").GetComponent<Text> ().text = quest.QuestDescription;

		// Task

		string TaskString = "Task:\n";
		if (quest.task.kills != null) {


			foreach (Quest.QuestKill qk in quest.task.kills) {

				TaskString += "Slay " + qk.amount + " " + MonsterDatabase.Monsters [qk.id] + ".\n";
			}
		} else {

			Debug.Log (quest.task.kills);
		}

		if (quest.task.items != null) {


			foreach (Quest.QuestItem qi in quest.task.items) {


				TaskString += "Bring " + qi.amount + " " + ItemDatabase.items [qi.id] + ".\n";
			}
		}

		if (quest.task.talkTo != null) {

			foreach (int id in quest.task.talkTo) {


				TaskString += "talk to " + NPCDataBase.npcs [id] + ".\n";

			}
		}

		info.Find ("Task").GetComponent<Text> ().text = TaskString;

		string rewardString = "Reward: \n";
		if (quest.reward.items != null) {


			foreach (Quest.QuestItem qi in quest.reward.items) {


				rewardString += qi.amount + " " + ItemDatabase.items[qi.id] + ".\n";

			}
		}

		if (quest.reward.exp != null) {

			rewardString += quest.reward.exp + "Experience ";

		}

		if (quest.reward.money > 0) {

			rewardString += quest.reward.money + "money";

		}

		info.Find ("Reward").GetComponent<Text> ().text = rewardString;
	}



	
	// Update is called once per frame
	void Update () {
		
	}
}
