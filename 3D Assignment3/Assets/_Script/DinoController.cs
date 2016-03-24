using UnityEngine;
using System.Collections;

public class DinoController : MonoBehaviour {



	public GameObject Dino;
	public Transform Player;



	public int MoveSpeedMax = 10;
	public int MoveSpeedMin = 3;
	public int rotateSpeed = 3;

	public int LookAtDis = 100;
	public int ChaseDist = 80;
	public int AttackDist = 20;

	private Vector3 _originPosition;
	private Animator _dinoAni;
	private Transform _transform;
	private float _gravity = 20.0f;


	// Use this for initialization
	void Start () {  
		this._dinoAni = GetComponent<Animator> ();
		this._transform = GetComponent<Transform> ();


	}

	// Update is called once per frame
	void Update () {
		/*
		float distance = Vector3.Distance (Player.position, transform.position);

		if (distance < LookAtDis) {
			_lookAt ();
		}

		if (distance > LookAtDis) {
			_lookAt ();
		}

		if (distance < AttackDist) {
			_attack ();
		}

		if (distance < ChaseDist) {
			_chase ();
		}

		*/

		transform.LookAt(Player.transform);

		//Chase the player: change animation to walk
		if (Vector3.Distance (transform.position, Player.position) >= this.ChaseDist)
		{
			//Debug.Log ("Distance: " + Vector3.Distance (transform.position, Player.position));
			this._dinoAni.SetInteger ("State", 4);

			transform.position += transform.forward * Random.Range (this.MoveSpeedMin+10, this.MoveSpeedMax+10) * Time.deltaTime;
			//this._transform.Translate(Vector3.forward * Random.Range (this.MoveSpeedMin+10, this.MoveSpeedMax+10) * Time.deltaTime);

			if (Vector3.Distance (transform.position, Player.position) <= this.LookAtDis) 
			{
				//this._dinoAni.SetInteger ("State", 4);
			}
			//_chase ();
		}

		if (Vector3.Distance (transform.position, Player.position) <= this.AttackDist) 
		{
			//Debug.Log ("attack Distance: " + Vector3.Distance (transform.position, Player.position));
			this._dinoAni.SetInteger ("Attack", Random.Range(1,3));
			transform.position += transform.forward * Random.Range (this.MoveSpeedMin, this.MoveSpeedMax) * Time.deltaTime;
		}

	}


	void _lookAt()
	{
		this._dinoAni.SetInteger ("State", 0);
		this._dinoAni.SetInteger ("Attack", 0);

		Quaternion rotation = Quaternion.LookRotation (Player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 5);
	}


	void _chase()
	{
		this._dinoAni.SetInteger ("State", 4);

		Vector3 moveDirection = transform.forward;
		moveDirection *= Random.Range (MoveSpeedMin, MoveSpeedMax);

		//moveDirection.y -= this._gravity * Time.deltaTime;
		moveDirection.y =0;
		this._transform.Translate (moveDirection * Time.deltaTime);

	}

	void _attack()
	{
		this._dinoAni.SetInteger ("Attack", Random.Range(1,3));
	}

}
