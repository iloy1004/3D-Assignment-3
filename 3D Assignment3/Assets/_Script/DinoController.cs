using UnityEngine;
using System.Collections;

public class DinoController : MonoBehaviour {



	public GameObject Dino;
	public Transform Player;

	private Vector3 _originPosition;

	public int MoveSpeedMax = 5;
	public int MoveSpeedMin = 3;
	public int MaxDist = 10;
	public int MinDist = 5;


	// Use this for initialization
	void Start () {  
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt (Player);

		if (Vector3.Distance (transform.position, Player.position) >= this.MinDist)
		{
			transform.position += transform.forward * Random.Range (this.MoveSpeedMin, this.MoveSpeedMax) * Time.deltaTime;

			if (Vector3.Distance (transform.position, Player.position) <= this.MaxDist) 
			{

			}
		}
	}

}
