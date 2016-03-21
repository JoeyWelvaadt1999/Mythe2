using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	[SerializeField]private Shader _shader;
	private Camera _cam;
	private float _startSize;
	float multiplier;
	void Start() {
		_cam = Camera.main;
		Camera.main.RenderWithShader (_shader, "Shader");
		_startSize = _cam.orthographicSize;
	}

	public void SetSize(float max) {
		
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) ||
			Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow))
			multiplier = 0.1f;
		else
			multiplier = -0.1f;

		_cam.orthographicSize = Mathf.Clamp (_cam.orthographicSize, _startSize, _startSize + max/2);


		_cam.orthographicSize += multiplier;

	}
}
