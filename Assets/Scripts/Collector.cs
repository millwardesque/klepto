﻿using UnityEngine;
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
		inventory.AttachToOwner(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void OnCollisionEnter(Collision col) {
		Characteristics item = col.collider.GetComponent<Characteristics>();
		if (item) {
			Debug.Log ("item picked up: " + item.name);
			inventory.AddInventoryItem(item);
			item.transform.parent = inventory.gameObject.transform;
			item.transform.position = new Vector3(0, 0, 0);
			
			if (col.collider.renderer) {
				col.collider.renderer.enabled = false;
				Debug.Log ("hidden via col.collider");
			}

			if (item.renderer) {
				item.renderer.enabled = false;
				Debug.Log ("hidden via item");
			}
			item.enabled = false;
			item.collider.enabled = false;
		}
	}
}
