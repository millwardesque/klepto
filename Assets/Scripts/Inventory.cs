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
		//update the bag size
		float scale = Mathf.Max (Mathf.Sqrt (bagSize/100.0f), 0.1f);
		transform.localScale = new Vector3 (scale, scale, scale); 

		if (Input.GetKeyDown (KeyCode.P)) {
			if (HasOwner()) {
				DetachFromOwner();
				Debug.Log ("Bag dropped");
			}
			else if ((GameObject.FindGameObjectWithTag("MainCamera").transform.position - transform.position).magnitude < 3.0){
				AttachToOwner (GameObject.FindGameObjectWithTag("MainCamera"));	
				Debug.Log ("Bag picked up");
			}
		}
	}

	public bool HasOwner() {
		return (transform.parent != null);
	}

	public void DetachFromOwner() {
		transform.parent = null;
		GetComponent<JellyMesh>().SetKinematic(false, false);
		audio.Play();
	}

	public void AttachToOwner(GameObject obj) {
		transform.parent = obj.transform;
		GetComponent<JellyMesh>().SetKinematic(true, true);

		audio.Play();
	}

	public void AddInventoryItem(Characteristics item) {
		items.Add (item);

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
