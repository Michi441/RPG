using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

	public int id;
	public string QuestName;
	public string QuestDescription;
	public int reci;
	public int reqLevel;
	public Reward reward;
	public Task task;

	[System.Serializable]
	public class Reward {

		public float exp;
		public float money;
		public QuestItem[] items;
	}
	[System.Serializable]
	public class Task {

		public int[] talkTo;
		public QuestItem[] items;
		public QuestKill[] kills;
	}
	[System.Serializable]
	public class QuestItem{

		public int id;
		public int amount;
	}
	[System.Serializable]
	public class QuestKill{

		public int id;
		public int amount;
		public int playerCurrent;
	}
}
