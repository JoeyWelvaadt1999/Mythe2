using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {
	[SerializeField]private Vector2 _bounds;
	private Vector2 _screenSize = new Vector2();
	private Vector2 _curPosition;

	void Update () {
		GetCameraSize ();
		CheckIfAtBoundrey ();
	}

	void CheckIfAtBoundrey() {
		if (Camera.main.transform.position.x - _screenSize.x / 2 > -_bounds.x &&
			Camera.main.transform.position.x + _screenSize.x / 2 < _bounds.x) {
			_curPosition.x = transform.position.y;
		} else {

			Vector2 tpos = transform.position;
			tpos.x = _curPosition.x;
			transform.position = new Vector3(tpos.x, tpos.y, -10);
		}

		if (Camera.main.transform.position.y - _screenSize.y / 2 > -_bounds.y &&
			Camera.main.transform.position.y + _screenSize.y / 2 < _bounds.y) {
			_curPosition = transform.position;
		} else {

			Vector2 tpos = transform.position;
			tpos.y = _curPosition.y;
			transform.position = new Vector3(tpos.x, tpos.y, -10);
		}
	}

	void GetCameraSize () {
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width / Screen.height;

		_screenSize = new Vector2 (width, height);
	}
}
