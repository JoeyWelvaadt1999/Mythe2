using UnityEngine;
using System.Collections;

public class EnemyHealth : LifePoints
{
	[SerializeField]private int _enemyHealth;
	void Awake () {
		_health = _enemyHealth;
	}

	public void TakeDamage(int damage, GameObject go) {
		DecreaseHealth (damage, go);
	}
}
