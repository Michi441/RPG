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

		// Create a new Quest Item by using the JSON File as source.
		Quest newQuest = JsonUtility.FromJson<Quest> (Resources.Load<TextAsset> ("JSONQuestFile").text);
		// Add the quest to the Dictionary File. New quest has an id for the index and newQuest is the name.
		questDictionary.Add (newQuest.id, newQuest);
		print(JsonUtility.ToJson(newQuest));


	}

	public void ShowQuestInfo (Quest quest)
	{
		// Get the UI Controller script and the associated gameObject with questinfo and set it active.
		UIController.instance.questInfo.gameObject.SetActive (true);

		UIController.instance.questInfoAcceptButton.onClick.AddListener (() => {
			PlayerData.AddQuest (quest.id);
			UIController.instance.questInfo.gameObject.SetActive (false);
			//ShowActiveQuests();
		});





		UIController.instance.questInfoContent.Find ("Name").GetComponent<Text> ().text = quest.QuestName;
		UIController.instance.questInfoContent.Find ("Description").GetComponent<Text> ().text = quest.QuestDescription;
		//TASK
		string taskString = "Task:\n";
		if (quest.task.kills != null) {
			foreach (Quest.QuestKill qk in quest.task.kills) {

				int currentKills = 0;
				taskString += "Slay " + qk.amount + " " + MonsterDatabase.Monsters [qk.id] + ".\n";


				Debug.Log ("has tasks!");


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
