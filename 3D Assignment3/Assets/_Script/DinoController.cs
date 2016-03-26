using UnityEngine;
using System.Collections;

public class DinoController : MonoBehaviour {



	//public GameObject Dino;
	public GameObject Player;
	public GameController GameController;


	public int MoveSpeedMax = 10;
	public int MoveSpeedMin = 3;
	public int rotateSpeed = 3;

	public int ChaseDist = 500;
	public int AttackDist = 100;

	private Vector3 _targetPosition;
	private Animator _dinoAni;
	private Transform _transform;
	private float _distance;

	// Use this for initialization
	void Start () {  
		this._dinoAni = GetComponent<Animator> ();
		this._transform = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {

		this._transform.LookAt (Player.transform);

		//_transform.LookAt(Player);

		this._distance = Vector3.Distance (this._transform.position, Player.transform.position);
		//Debug.Log ("Distance: " + this._distance);

		if (this._distance >= this.ChaseDist) {
			this._lookAt ();
		}

		if (this._distance <= this.ChaseDist) {
			this._chase ();
		}

		if (this._distance <= this.AttackDist) {
			this._attack ();
		}

		if (this._distance <= 5) {
			GameController.LiveValue -= 1;
			Destroy (this.gameObject);

			if (GameController.LiveValue <= 0) {
				GameController._endGame ();
			}
		}

	}

	void _lookAt()
	{
		//change the animation of dino as running
		this._dinoAni.SetInteger ("State", 0);
	}

	void _chase()
	{
		//change the animation of dino as running
		this._dinoAni.SetInteger ("State", 4);

		float step = Random.Range (this.MoveSpeedMin + 10, this.MoveSpeedMax + 10) * Time.deltaTime;
		this._transform.position = Vector3.MoveTowards(this._transform.position, Player.transform.position, step);
	}

	void _attack()
	{
		//change the animation of dino as attacking
		this._dinoAni.SetInteger ("Attack", Random.Range(1,3));

		float step = Random.Range (this.MoveSpeedMin + 10, this.MoveSpeedMax + 10) * Time.deltaTime;
		this._transform.position = Vector3.MoveTowards(this._transform.position, Player.transform.position, step);
	}

}
