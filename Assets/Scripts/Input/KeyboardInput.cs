using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	PlayerInventory _playerInventory;
	// Use this for initialization
	void Start () {
		_playerInventory = GetComponent<PlayerInventory> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.B)) {
			_playerInventory.PickupResources ();
		}
	}
}
