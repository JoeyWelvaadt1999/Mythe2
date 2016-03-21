using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerDeath _playerDeath;
    private PlayerRespawn _playerRespawn;

    void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerDeath = GetComponent<PlayerDeath>();
        _playerRespawn = FindObjectOfType<PlayerRespawn>();
    }

	void OnTriggerEnter2D(Collider2D coll) {
		EnemyAttack ea = coll.GetComponentInParent<EnemyAttack> ();
		if (coll.transform.tag == Tags.enemy) {
			if (EnemyStates._states == States.Attacking) {
				_playerHealth.TakeDamage (coll.GetComponentInParent<EnemyAttack> ().Damage, transform.gameObject);
			}
		}
	}
}
