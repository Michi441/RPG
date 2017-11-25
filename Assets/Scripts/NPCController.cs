using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour {

	public string[] dialogues;
	public int dialoguesIndex = 0;

	private Quest.Task task;
	private Quest quest;

	[SerializeField] int[] quests;

	// Use this for initialization
	void Start () {

		//SetQuestExample ();
		//ShowQuestInfo ();

		//print (JsonUtility.ToJson (quest));
//		print(JsonUtility.ToJson (quest));
//		print (JsonUtility.ToJson (quest.QuestName));
		//UIController.instance.ShowQuestInfo (QuestManager.instance.questDictionary [0]);




	}

	void Update(){


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


		foreach (int i in quests) {



					QuestManager.instance.ShowQuestInfo(QuestManager.instance.questDictionary[quests[i]]);
					break;
				
		}
	}

	public void OnClick(){

		ShowQuestInfo ();
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
