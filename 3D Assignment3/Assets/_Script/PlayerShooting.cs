using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public Transform FlashPoint;
    public GameObject MuzzleFlash;
	public GameObject BulletImpact;
	public GameObject Explosion;

	private Transform _transform;
	public GameController GameController;
	public GameObject Dino;
	//public AudioSource DinoDie;

	private AudioSource _dinoDieSound;
	private Animator _dinoAni;

	// Use this for initialization
	void Start () {
		this._transform = gameObject.GetComponent<Transform> ();
		//this._dinoAni = Dino.GetComponent<Animator> ();

		//this._gameController = GameObject.FindWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray landingRay = new Ray (FlashPoint.position, Vector3.forward);

		if(Input.GetButtonDown("Fire1"))
		{
			Instantiate(this.MuzzleFlash, FlashPoint.position, Quaternion.identity);

			//Instantiate (this.BulletImpact, FlashPoint.position, Quaternion.identity);

			//if (Physics.Raycast (landingRay, out hit, 1000f)) {
			if (Physics.Raycast (this._transform.position, this._transform.forward, out hit, 250f)) {

				Debug.Log (hit.collider.tag);

				if (hit.transform.gameObject.CompareTag ("Enemy")) 
					//if (hit.collider.tag == "Enemy") 
				{
					Instantiate (this.Explosion, hit.point, Quaternion.identity);

					StartCoroutine (_dinoDie (hit.transform.gameObject));
				}

				Instantiate (this.BulletImpact, hit.point, Quaternion.identity);
			}
		}
	}


	IEnumerator _dinoDie(GameObject dino)
	{
		this._dinoDieSound = dino.GetComponent<AudioSource> ();
		this._dinoDieSound.Play ();
		this._dinoAni = dino.GetComponent<Animator> ();
		this._dinoAni.SetInteger ("Idle", -1);
		
		yield return new WaitForSeconds (1.3f);

		Destroy (dino);

		Debug.Log ("Before: "+ this.GameController.ScoreValue);
		this.GameController.ScoreValue += 100;
		Debug.Log ("After: " + this.GameController.ScoreValue);
	}
}
