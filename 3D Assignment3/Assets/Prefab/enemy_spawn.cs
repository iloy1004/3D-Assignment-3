using UnityEngine;
using System.Collections;

public class enemy_spawn : MonoBehaviour {

	public int maxDino = 20;
	public int xMin = 100;
	public int xMax = 420;
	public int zMin = 80;
	public int zMax = 420;



	public GameObject Dino;
	private Vector3 _originPosition;

	// Use this for initialization
	void Start () {
		Spawn();   
	}

	// Update is called once per frame
	void Update () {

	}


	void Spawn()
	{
		for (int i = 0; i < maxDino; i++)
		{

			Vector3 randomPosition = new Vector3(Random.Range(xMin, xMax),0, Random.Range(zMin, zMax));

			//Create platform
			Instantiate(Dino, randomPosition, Quaternion.identity);

			this._originPosition = randomPosition;

		}
	}
}
