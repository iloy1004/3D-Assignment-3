using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameController GameController;

	//Set audio variables
	private AudioSource[] _audioSources;
	private AudioSource _deadSound;

	private Transform _transform;
	private Rigidbody _rigidBody;
	private int _currenLives;

	// Use this for initialization
	void Start () {

		this._transform = gameObject.GetComponent<Transform>();

		this._rigidBody = gameObject.GetComponent<Rigidbody>();

		// Setup AudioSources
		this._audioSources = gameObject.GetComponents<AudioSource>();
		this._deadSound = this._audioSources[0];
	}
	
	// Update is called once per frame
	void Update () {

		this._currenLives = GameController.LiveValue;

		if (this._currenLives > 5)
		{
			this._currenLives = 5;
		}

		if(this._currenLives <= 0)
		{
			GameController._endGame ();
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "DeathPlane")
		{
			Debug.Log ("Touch the death plane");
			this._deadSound.Play();       
			this._transform.position = new Vector3(380f, 0f, 104f);
			this.GameController.LiveValue -= 1;
		}


		if (col.gameObject.name == "Enemy")
		{
			Debug.Log ("Touch the dino");

			this._deadSound.Play();       
			this.GameController.LiveValue -= 1;

			Destroy(col.gameObject);

			StartCoroutine(this.Knockback(0.02f, 50f, this._transform.position, -50f));
		}
			
	}

	//When player hit the spikes, make the motion
	public IEnumerator Knockback(float knockDur, float knockPwr, Vector3 knockbackDir, float knockFacing)
	{
		float timer = 0;

		while(knockDur > timer)
		{

			timer += Time.deltaTime;
			this._rigidBody.AddForce(new Vector3(knockbackDir.x * knockFacing, Mathf.Abs(knockbackDir.y) * knockPwr, transform.position.z));
		}

		yield return 0;
	}

}
