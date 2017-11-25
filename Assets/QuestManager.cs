using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

	public static QuestManager instance;
	public Dictionary<int, Quest> questDictionary = new Dictionary<int, Quest>();
	// Use this for initialization
	void Awake () {

		if (instance == null) {

			instance = this;
			LoadQuest ();
		}
	}

	public void LoadQuest(){


		Quest newQuest = JsonUtility.FromJson<Quest> (Resources.Load<TextAsset> ("JSONQuestFile").text);
		questDictionary.Add (newQuest.id, newQuest);


	}

	public void ShowQuestInfo(Quest quest){

		UIController.instance.questInfo.gameObject.SetActive (true);

		UIController.instance.questInfoAcceptButton.onClick.AddListener(() => {
			PlayerData.AddQuest(quest.id);
			UIController.instance.questInfo.gameObject.SetActive(false);
			ShowActiveQuests();
		});



		UIController.instance.questInfoContent.Find("Name").GetComponent<Text>().text = quest.QuestName;
		UIController.instance.questInfoContent.Find("Description").GetComponent<Text>().text = quest.QuestDescription;
		//TASK
		string taskString = "Task:\n";
		if(quest.task.kills != null){
			foreach(Quest.QuestKill qk in quest.task.kills){
				//Current kills is zero when we haven't taken the quest.
				int currentKills = 0;
				if(PlayerData.monstersKilled.ContainsKey(qk.id))
					//if we are showing the info during the progress of the quest (we took it already) show the progress.
					currentKills = PlayerData.monstersKilled[qk.id].amount - PlayerData.activeQuests[quest.id].kills[qk.id].initialAmount;
				taskString += "Slay " + (currentKills) + "/" + qk.amount + " " + MonsterDatabase.monsters[qk.id] + ".\n";
			}
		}
		if(quest.task.items != null){
			foreach(Quest.QuestItem qi in quest.task.items){
				taskString += "Bring " + qi.amount + " " + ItemDatabase.items[qi.id] + ".\n";
			}
		}
		if(quest.task.talkTo != null){
			foreach(int id in quest.task.talkTo){
				taskString += "Talk To " + NPCDataBase.npcs[id] + ".\n";
			}
		}
		UIController.instance.questInfoContent.Find("Task").GetComponent<Text>().text = taskString;
		//REWARD
		string rewardString = "Reward:\n";
		if(quest.reward.items != null){
			foreach(Quest.QuestItem qi in quest.reward.items){
				rewardString +=  qi.amount + " " + ItemDatabase.items[qi.id] + ".\n";
			}
		}
		if(quest.reward.exp > 0)rewardString += quest.reward.exp + " Experience.\n";
		if(quest.reward.money > 0)rewardString += quest.reward.money + " Money.\n";
		UIController.instance.questInfoContent.Find("Reward").GetComponent<Text>().text = rewardString;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
