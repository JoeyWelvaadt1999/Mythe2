using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    Animator _anim;

	CameraZoom _cameraZoom; //Declare variable to camera zoom component
	private float _speed = 3f;
    private bool _facingRight;
	private string _animSideString = "isRunningSideways";
	private string _animUpString = "isRunningUp";

    void Awake() {
        _anim = GetComponent<Animator>();
    }

	void Start() {
		_cameraZoom = Camera.main.GetComponent<CameraZoom> (); //Initialize varible to camerazoom component
	}

	void playerInput(float x, float y)
    {
		if (x < -0.1f || x > 0.1f) {
			_anim.SetFloat ("Speed", x);	
			_anim.SetBool ("Idle", false);
		} else if (y < -0.1f || y > 0.1f) {
			_anim.SetFloat ("Speed", y);
			_anim.SetBool ("Idle", false);
		} else {
			_anim.SetFloat ("Speed", 0);
			_anim.SetBool ("Idle", true);
		}

		Flip (x, y);
    }

	void Update () {
        Move();
	}

	void Move() {

		if (Input.GetKey (KeyCode.LeftShift))
			_speed = 3 * 2;
		else if (Input.GetKeyUp (KeyCode.LeftShift))
			_speed = 3;

		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");

		transform.Translate (x * _speed * Time.deltaTime, y * _speed * Time.deltaTime, 0) ;

		playerInput(x,y);

//		_cameraZoom.SetSize(_speed); //Public function to increase or decrease the camera orthographic size by speed 
	}

	protected void Flip(float x, float y)
    {
		if (_facingRight) {
			if (x > 0.1f) {
				Vector2 theScale = transform.localScale;
				theScale.x = 1;
				transform.localScale = theScale;
				_facingRight = false;
			} else if (x < -0.1f) {
				Vector2 theScale = transform.localScale;
				theScale.x = -1;
				transform.localScale = theScale;
				_facingRight = false;
			}  
		}


		if (x < 0.1f && x > -0.1f) {
			_facingRight = true;
		}
        
    }
}
