using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private int level = 1;
	private Text levelText;
	public float experience { get; private set;}
	private Transform exprienceBar;

	[Header("Movement")]
	public bool canMove;
	public float movementSpeed, velocity;
	Rigidbody rb;
	Animator anim;

	[Header("Combat")]
	public List<Transform> enemiesInRange = new List<Transform>();
	private bool canAttack = true;
	private bool isAttacking;
	public float AttackDamage, AttackSpeed, AttackRange;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();

		exprienceBar = UIController.instance.canvas.Find ("XPFiller");
		levelText = UIController.instance.canvas.Find ("XPText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		GetInput ();
		Move ();

		
	}

	IEnumerator Attacking(){
		GetEnemiesInRange ();
		foreach (Transform enemy in enemiesInRange) {

			EnemyMovement em = enemy.GetComponent<EnemyMovement> ();
			if (em == null) {

				continue;
			}
			em.GetHit (AttackDamage);
		}
		isAttacking = true;
		yield return new WaitForSeconds (1);
		isAttacking = false;
	}
















	void Move(){

		if (velocity == 0) {
		//anim.SetInteger ("Condition", 0);
			return;
		} else {
			if (!isAttacking) {
				anim.SetInteger ("Condition", 1);
				rb.MovePosition (transform.position + Vector3.right * velocity * movementSpeed * Time.deltaTime);
			}
		}


	}

	void SetVelocity(float dir){

		if (dir < 0)
			transform.LookAt (transform.position + Vector3.left);
		else if (dir > 0)
			transform.LookAt(transform.position + Vector3.right);
		velocity = dir;
	}

	void Attack(){

		if (isAttacking)
			return;
		StartCoroutine (Attacking());
		anim.SetInteger ("Condition", 2);


	}

	void GetInput(){

		if (Input.GetMouseButtonDown (0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 300)) {

				NPCController npcController = hit.transform.GetComponent<NPCController> ();
				if (npcController != null) {

					npcController.ShowDialogue();
					npcController.dialoguesIndex++;
					npcController.OnClick ();

					return;

				}
			}

			Debug.Log ("attacking!");
			Attack ();
		}
		if (Input.GetKey (KeyCode.A)) {

			SetVelocity (-1);

		} else if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetInteger ("Condition", 0);
			SetVelocity (0);
		}

		if (Input.GetKey (KeyCode.D)) {

			SetVelocity (1);

		} else if (Input.GetKeyUp (KeyCode.D)) {
			anim.SetInteger ("Condition", 0);

			SetVelocity (0);

		}
	}

	void GetEnemiesInRange(){
		enemiesInRange.Clear ();
		foreach (Collider c in Physics.OverlapSphere((transform.position + transform.forward * 0.5f), 0.5f)){
			if (c.gameObject.CompareTag ("Enemy")) {
				enemiesInRange.Add (c.transform);
			}
	}

	}

	public void GetXP(float XP){

		experience += XP;
		float XPNeeded = AddXP.ExperienceForNextLevel (level);
		float previousXP = AddXP.ExperienceForNextLevel (level - 1);

		while(experience >= XPNeeded) {

			LevelUP ();
			XPNeeded = AddXP.ExperienceForNextLevel (level);
			previousXP = AddXP.ExperienceForNextLevel (level - 1);
		}
		exprienceBar.GetComponent<Image> ().fillAmount = (experience - previousXP) / (XPNeeded - previousXP);
	}

	void LevelUP(){

		level++;
		levelText.text = "Lv " + level.ToString ("00");
	}
}