using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
	Animator _anim;
	EnemyAttack _enemyAttack;
	private LookDirection _lookDirection = LookDirection.None;
	public LookDirection LookDir {
		get { 
			return _lookDirection;
		}
	}
    [SerializeField]
    private float _radius;
    private int _layermask;
    [SerializeField]
    private Transform _playerTarget;
	public Transform PlayerTarget {
		get { 
			return _playerTarget;
		}
	}
    [SerializeField]
    private float followSpeed;

	void Awake() {
		_anim = GetComponent <Animator> ();
		_enemyAttack = GetComponent<EnemyAttack> ();
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, _radius);
		//Gizmos.DrawWireSphere (transform.position, _enemyAttack.AttackRange);
        Gizmos.DrawWireCube(transform.position, new Vector3(_enemyAttack.AttackRange, 1, 0));
    }	

    void FollowPlayerTarget()
	{
		if (EnemyStates._states == States.Chasing){
			if (Vector2.Distance (transform.position, _playerTarget.position) <= _radius && Vector2.Distance (transform.position, _playerTarget.position) >= _enemyAttack.AttackRange) {
				ChangeLookDirection ();
				//			print ("Found target. Chasing target.");
				Vector2 heading = _playerTarget.transform.position - transform.position;
				float distance = heading.magnitude;
				Vector2 direction = heading / distance;

				transform.Translate (direction * Time.deltaTime * followSpeed);

				_anim.SetBool ("isWalking", true);
			} else {
				if (EnemyStates._states != States.Wander) {
					//			print ("Lost target. Gonna wander around.");
					GetComponent<EnemyMovement> ().CheckLookDirection ();
					EnemyStates._states = States.Wander;
				}
			}
		}
    }

	public void ChangeLookDirection() {
		
		Vector3 tScale = transform.localScale;
		if(_playerTarget.position.x > transform.position.x){
//			if(_lookDirection != LookDirection.Right){
				tScale.x = -1;
//				_lookDirection = LookDirection.Right;
//			}
		} 
		if (_playerTarget.position.x < transform.position.x) {
//			if(_lookDirection != LookDirection.Left) {
				tScale.x = 1;
//				_lookDirection = LookDirection.Left;
//			}
		}

		transform.localScale = tScale;
	}

    void Update ()
	{
		if (EnemyStates._states == States.Chasing) {
			ChangeLookDirection ();
			_lookDirection = LookDirection.None;
		}
		FollowPlayerTarget();
	}
}
