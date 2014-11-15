using UnityEngine;
using System.Collections;

public class Characteristics : MonoBehaviour {

	public float weight = 1.0f;
	public float size = 1.0f;
	public float value = 1.0f;
	public float breakability = 0.0f;

	public float Weight {
		get {
			return weight;
		}

		set {
			weight = value;
		}
	}

	public float Size {
		get {
			return size;
		}

		set {
			size = value;
		}
	}

	public float Value {
		get {
			return value;
		}

		set {
			this.value = value;
		}
	}

	public float Breakabilaty {
		get {
			return breakability;
		}

		set {
			breakability = value;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
