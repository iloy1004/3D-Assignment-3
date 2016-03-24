using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public Transform FlashPoint;
    public GameObject MuzzleFlash;
	public GameObject BulletImpact;
	public GameObject Explosion;

	private Transform _transform;
	public GameController GameController;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		//this._gameController = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		RaycastHit hit;
		Ray landingRay = new Ray (FlashPoint.position, Vector3.forward);
		
		if(Input.GetButtonDown("Fire1"))
		{
			Instantiate(this.MuzzleFlash, FlashPoint.position, Quaternion.identity);

			//Instantiate (this.BulletImpact, FlashPoint.position, Quaternion.identity);

			//if (Physics.Raycast (landingRay, out hit, 1000f)) {
			if (Physics.Raycast (this._transform.position, this._transform.forward, out hit, 500f)) {
				
				Debug.Log (hit.collider.tag);

				if (hit.transform.gameObject.CompareTag ("Enemy")) 
				//if (hit.collider.tag == "Enemy") 
				{
					Instantiate (this.Explosion, hit.point, Quaternion.identity);
					Destroy (hit.transform.gameObject);
					this.GameController.ScoreValue += 100;
				}

				Instantiate (this.BulletImpact, hit.point, Quaternion.identity);
			}
		}
	}
}
