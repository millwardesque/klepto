using UnityEngine;
using System.Collections;

public class TestMove : MonoBehaviour {
	private CharacterMotor characterMotor;

	// Use this for initialization
	void Start () {
		characterMotor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		characterMotor.movement.maxForwardSpeed = 1.0f;
	}
}
