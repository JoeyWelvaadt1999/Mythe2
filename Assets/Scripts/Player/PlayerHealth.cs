using UnityEngine;
using System.Collections;

public class PlayerHealth : LifePoints
{
	[SerializeField]private int _playerHealth;

	void Awake(){
		_health = _playerHealth;
	}

	public void TakeDamage(int damage, GameObject go) {
		DecreaseHealth (damage, go);
	}
}
