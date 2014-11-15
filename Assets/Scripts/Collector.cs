using UnityEngine;
using System.Collections;

public class Collector : MonoBehaviour {
	private Inventory inventory;

	// Use this for initialization
	void Start () {
		GameObject inventoryObject = GameObject.FindGameObjectWithTag("Inventory");
		if (!inventoryObject) {
			Debug.LogError(string.Format ("Unable to set up collector on '{0}': No GameObject with Inventory label exists.", gameObject.name));
		}
		inventory = inventoryObject.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnCollisionEnter(Collision col) {
		Characteristics item = col.collider.GetComponent<Characteristics>();
		Debug.Log ("Collided");
		if (item) {
			inventory.AddInventoryItem(item);
			item.transform.parent = inventory.gameObject.transform;
			Debug.Log ("Got it!");
			item.enabled = false;
		}
	}
}
