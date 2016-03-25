using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private int _scoreVal;
	private int _liveVal;

	//[SerializeField]
	//private AudioSource _gameOverSound;

	private Vector3 _playerResetPos;

	public int ScoreValue{
		get{
			return this._scoreVal;
		}

		set{
			this._scoreVal = value;
			this.ScoreLbl.text = "Scores: " + this._scoreVal;
		}
	}

	public int LiveValue{
		get{
			return this._liveVal;
		}

		set{
			this._liveVal = value;

			if (this._liveVal <= 0) {
				
			} else {
				this.LiveLbl.text = "Lives: " + this._liveVal;
			}

		}
	}
	public Text LiveLbl;
	public Text ScoreLbl;
	public Text GameOverLbl;
	public Text HighScoreLbl;
	public Button RestartBtn;

	public GameObject Dino;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		this._initialize ();

		Player.transform.position = this._playerResetPos;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void _initialize(){

		this._playerResetPos = new Vector3 (380f, 0f, 104f);

		this.ScoreValue = 0;
		this.LiveValue = 5;
		this.GameOverLbl.gameObject.SetActive (false);
		this.HighScoreLbl.gameObject.SetActive (false);
		this.RestartBtn.gameObject.SetActive (false);
	}

	void _endGame(){
		this.GameOverLbl.gameObject.SetActive (true);
		this.HighScoreLbl.gameObject.SetActive (true);
		this.RestartBtn.gameObject.SetActive (true);

		this.HighScoreLbl.text = "High Score: " + this._scoreVal;

		this.LiveLbl.gameObject.SetActive (false);
		this.ScoreLbl.gameObject.SetActive (false);

		//this._gameOverSound.Play ();
	}

	public void RestartBtnClick()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

}
