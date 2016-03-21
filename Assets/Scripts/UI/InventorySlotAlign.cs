using UnityEngine;
using System.Collections;

public class InventorySlotAlign : MonoBehaviour {
	[SerializeField]private int _index;
	private AlignUI _parent;
	private Vector2 _startPos;
	private Vector2 _startSize;
	private Vector2 _newSize;
	void Start() {
		_startPos = GetComponent<RectTransform> ().anchoredPosition;
		_parent = GetComponentInParent<AlignUI> ();
		_startSize = new Vector2 (GetComponent<RectTransform> ().rect.width, GetComponent<RectTransform> ().rect.height);

	}

	void Update() {
		Rect rect = new Rect ();
		_newSize.x = _startSize.x * _parent.Scale;
		_newSize.y = _startSize.y * _parent.Scale;
		GetComponent<RectTransform> ().sizeDelta = _newSize;
		GetComponent<RectTransform> ().anchoredPosition = CalculatePosition ();
	}

	private Vector2 CalculatePosition () {
		float dx = (_newSize.x - _startSize.x);
		float dy = (_newSize.y - _startSize.y);
		float x = _startPos.x + dx * _index - (0.5f * _index);
		float y = _startPos.y - dy;
		return new Vector2 (x, y);
	}
}
