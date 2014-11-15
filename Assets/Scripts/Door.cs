using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool isOpen = false;
	public bool opensOutward = true;
	public float timeToClose = 1.0f; //amount of time it takes to completely open or close the door

	private float openT = 0.0f;
	private bool isOpening = false;
	private bool isClosing = false;
	private float angleChange = 90.0f;

	// Use this for initialization
	void Start () {
		openT = isOpen ? 1.0f : 0.0f;
		angleChange = opensOutward ? -90.0f : 90.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.O)) Open ();
		if (Input.GetKeyDown (KeyCode.C)) Close ();
		if (isOpening || isClosing) ProcessOpenOrClose (); //avoid doing anything when not active
	}

	void ProcessOpenOrClose () {
		float previousT = openT;
		if (isOpening) {
			openT += Time.deltaTime/timeToClose;
			if (openT > 1.0f) {openT = 1.0f; isOpen = true; isOpening = false;}
		}

		if (isClosing) {
			openT -= Time.deltaTime/timeToClose; 
			if (openT < 0.0f) {openT = 0.0f; isOpen = false; isClosing = false;}
		}

		float changeInT = openT-previousT;

		transform.Rotate (0.0f, changeInT * angleChange, 0.0f);
	}

	public void Open () {
		isOpening = true; isClosing = false;
	}

	public void Close () {
		isClosing = true; isOpening  = false;
	}
}
