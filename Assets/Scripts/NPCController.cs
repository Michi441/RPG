using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {

	public string[] dialogues;
	public int dialoguesIndex = 0;

	private Quest quest;

	// Use this for initialization
	void Start () {

		SetQuestExample ();
		ShowQuestInfo ();
	}

	void SetQuestExample(){


		quest = new Quest ();
		quest.QuestName = "Mummies everywhere!";
		quest.QuestDescription = "Get em all!";
		quest.reward = new Quest.Reward ();
		quest.reward.exp = 400;
		quest.reward.items = new Quest.QuestItem[1];
		quest.reward.items [0] = new Quest.QuestItem ();
		quest.reward.items [0].id = 2;
		quest.reward.items [0].amount = 5;
		quest.task = new Quest.Task ();
		quest.task.kills = new Quest.QuestKill[2];
		quest.task.kills [0] = new Quest.QuestKill ();
		quest.task.kills [0].id = 0;
		quest.task.kills [0].amount = 10;
		quest.task.kills [1] = new Quest.QuestKill ();
		quest.task.kills [1].id = 55;
		quest.task.kills [1].amount = 5;

	}

	public void ShowQuestInfo(){


		Transform info = GameObject.Find ("QuestInfo").transform;
		info.Find ("QuestName").GetComponent<Text> ().text = quest.QuestName;
		info.Find ("QuestDescription").GetComponent<Text> ().text = quest.QuestDescription;

		// Task

		string TaskString = "";
		if (quest.task.kills != null) {


			foreach (Quest.QuestKill qk in quest.task.kills) {

				TaskString += "Slay " + qk.amount + " " + MonsterDatabase.Monsters [qk.id] + ".\n";
			}
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

	


	public void ShowDialogue(){

		if (dialoguesIndex > (dialogues.Length - 1)) {
			
			DialogueBo.instance.CloseDialogueBox ();

			dialoguesIndex = (dialogues.Length - 1);
			dialoguesIndex = -1;
		} else {
			
			//print (name + ": " + dialogues [dialoguesIndex]);
			DialogueBo.instance.PrintDialogueBox (name + ": " + dialogues [dialoguesIndex]);

		}
	}

	IEnumerator Wait(){

		yield return new WaitForSeconds (5f);

	}
}
