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

	[SerializeField]
	public class Reward {

		public float exp;
		public float money;
		public QuestItem[] items;
	}
	[SerializeField]
	public class Task {

		public int[] talkTo;
		public QuestItem[] items;
		public QuestKill[] kills;
	}
	[SerializeField]
	public class QuestItem{

		public int id;
		public int amount;
	}
	[SerializeField]
	public class QuestKill{

		public int id;
		public int amount;
		public int playerCurrent;
	}
}
