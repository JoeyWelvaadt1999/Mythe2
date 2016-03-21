using UnityEngine;
using System.Collections;

public enum LookDirection
{
	Right,
	Left,
	None
}

public class EnemyMovement : MonoBehaviour {
	Animator _anim;
	private Vector3 _walkToPos;
	private Vector3 _currentPos;
	private LookDirection _lookDirection = LookDirection.None;
	private EnemyFollow _enemyFollow;
	private Transform _playerTarget;

    void Awake()
    {
		EnemyStates._states = States.Wander;
        _anim = GetComponent<Animator>();
		_enemyFollow = GetComponent<EnemyFollow> ();
		_playerTarget = _enemyFollow.PlayerTarget;
    }

	void Update() {
		Wander ();
	}

	void Wander() {
		if (EnemyStates._states == States.Wander) {
			CheckLookDirection ();
			if (_currentPos == Vector3.zero || _currentPos == _walkToPos) {
				_anim.SetBool ("isWalking", true);
				_walkToPos = new Vector3 (Random.Range (-36f, 36f), Random.Range (-9f, 9f), 0);
			}

			_currentPos = transform.position;
			
			transform.position = Vector3.MoveTowards (_currentPos, _walkToPos, 0.05f);
		}

	}

	public void CheckLookDirection() {
		Vector3 newEnemyScale = transform.localScale;
		if (_walkToPos.x > transform.position.x) {
			if (_lookDirection != LookDirection.Right) {
				newEnemyScale.x = -1;
				_lookDirection = LookDirection.Right;
			}
		} else {
			if (_lookDirection != LookDirection.Left) {
				newEnemyScale.x = 1;
				_lookDirection = LookDirection.Left;
			}
		}

		transform.localScale = newEnemyScale;
		_lookDirection = LookDirection.None;
	}
}
