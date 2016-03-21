using UnityEngine;
using System.Collections;

public class PlayerMeleeAttack : MonoBehaviour
{
	Animator _anim;
    [SerializeField]
    private Collider2D _attackTrigger;
    bool _attacking = false;
	[SerializeField]private int _damage;
	// Use this for initialization
	void Start ()
    {
        _attackTrigger.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space) && !_attacking) {
			_attacking = true;
			_attackTrigger.enabled = true;
			StartCoroutine (Attacking());
//			_anim.SetBool("Attacking", true);
		}	
	}

	public int Damage() {
		if (_attacking) {
			_attacking = false;
			return _damage;
		} else {
			return 0;
		}
	}

	IEnumerator Attacking() {
//		while (_anim.GetCurrentAnimatorStateInfo (0).IsName("Attacking")) {
			yield return new WaitForSeconds (2f);
//		} 

		_attacking = false;
	}
}
