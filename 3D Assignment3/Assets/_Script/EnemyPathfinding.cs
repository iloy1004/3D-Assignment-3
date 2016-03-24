using UnityEngine;
using System.Collections;

public class EnemyPathfinding : MonoBehaviour {

	private Transform _targetLook;
	private NavMeshAgent _nav;

	// Use this for initialization
	void Start () {
		_targetLook = GetComponent<Transform> ();
		_nav = GetComponent<NavMeshAgent> ();

		_nav.destination = this._targetLook.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
