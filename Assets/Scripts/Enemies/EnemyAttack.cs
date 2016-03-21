using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
	Animator _anim;
	[SerializeField]private int _damage;
	[SerializeField]private float _attackRange;
	public float AttackRange {
		get { 
			return _attackRange;
		}	
	}

	public int Damage {
		get { 
			return _damage;
		}
	}
	private PlayerHealth _playerHealth;
	private GameObject _player;
	private EnemyFollow _enemyFollow;
	private bool _isAttacking;

	public bool IsAttacking {
		get { 
			return _isAttacking;
		} set { 
			_isAttacking = value;
		}
	}

	void Awake () {
		_player = GameObject.FindGameObjectWithTag ("Player");
		_playerHealth = _player.GetComponent<PlayerHealth> ();
		_enemyFollow = GetComponent<EnemyFollow> ();
		_anim = GetComponent<Animator> ();
	}

	void Update () {
		Attack ();
	}

	public void Attack() {
		if (Vector2.Distance (transform.position, _enemyFollow.PlayerTarget.position) <= _attackRange) {

			_isAttacking = true;

			EnemyStates._states = States.Attacking;
			_enemyFollow.ChangeLookDirection ();

			_anim.SetBool ("isWalking", false);
			_anim.SetBool ("isAttacking", true);

		} else {
			EnemyStates._states = States.Chasing;
		}
	}
		
}
