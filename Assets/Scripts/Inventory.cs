using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	private List<Characteristics> items = new List<Characteristics>();
	public bool ShowInventory = false;

	private float bagValue = 0.0f;
	public float BagValue {
		get { return bagValue; }
	}

	private float bagSize = 0.0f;
	public float BagSize {
		get { return bagSize; }
	}

	private float bagWeight = 0.0f;
	public float BagWeight {
		get { return bagWeight; }
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddInventoryItem(Characteristics item) {
		items.Add (item);

		rigidbody.mass += item.Weight;

		bagWeight += item.Weight;
		bagValue += item.Value;
		bagSize += item.Size;
	}

	void OnGUI() {
		if (ShowInventory) {
			int yPos = 10;
			int height = 20;
			int yMargin = 10;
			foreach (Characteristics item in items) {
				string itemDescription = string.Format("{0}: V{1} W{2} S{3}", item.name, item.Value, item.Weight, item.Size);
				GUI.Label(new Rect(10, yPos, 150, height), itemDescription);
				yPos += height + yMargin;
			}
		}
	}
}
