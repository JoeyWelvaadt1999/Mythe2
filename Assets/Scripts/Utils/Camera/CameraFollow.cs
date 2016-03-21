using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	[SerializeField]private GameObject _target;
	private int _offset = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		transform.position = Vector3.Slerp (transform.position, new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z), 0.05f);
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		float offsetX = _target.transform.position.x + x * _offset;
		float offsetY = _target.transform.position.y + y * _offset;

		transform.position = Vector3.Slerp(transform.position ,new Vector3 (offsetX, offsetY, transform.position.z), 0.025f);
	}
}
