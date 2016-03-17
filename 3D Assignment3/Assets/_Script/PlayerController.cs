using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Transform FlashPoint;
    public GameObject MuzzleFlash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(this.MuzzleFlash, FlashPoint.position, Quaternion.identity);

        }
	}
}
