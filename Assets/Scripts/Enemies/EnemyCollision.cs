using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour
{
    private EnemyHealth _enemyHealth;

    void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
			print("Enemy health: " + _enemyHealth.Health);
			_enemyHealth.TakeDamage (collider.gameObject.GetComponent<PlayerMeleeAttack> ().Damage(), transform.gameObject);
        }
    }
}
