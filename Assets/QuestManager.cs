using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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




	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
