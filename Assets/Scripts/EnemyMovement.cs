using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Animator anim;

	public bool noHealth;

	public float totlaHealth, currentHealth, expGranded,attackDamage,attackSpeed, moveSpeed;

	private GameObject[] player;

	public int MonsterId;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectsWithTag ("Player");
		currentHealth = totlaHealth;
		//anim.SetInteger ("Condition", 0);
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void GetHit(float damage){
		if (noHealth) {
			return;
		}
		
		currentHealth -= damage;
		anim.SetInteger ("Condition", 2);


		if (currentHealth <= 0) {
			No_Health ();
			return;
		}

		StartCoroutine (RecoverFromHit ());
	}

	void No_Health(){

		if (!PlayerData.monsterKilled.ContainsKey (MonsterId)) {

			PlayerData.monsterKilled.Add (MonsterId, new PlayerData.MonsterKills ());

		}

		PlayerData.monsterKilled [MonsterId].amount++;
		noHealth = true;
		DropLoot ();
		foreach (GameObject go in player) {


			go.GetComponent<PlayerMovement>().GetXP (expGranded / player.Length);
		}
		anim.SetInteger ("Condition", 3);
		GameObject.Destroy (this.gameObject, 5);
	}

	void DropLoot(){

		print ("you got some items dropped!");
	}

	IEnumerator RecoverFromHit(){


		yield return new WaitForSeconds (0.5f);
		anim.SetInteger ("Condition", 0);
	}
}
