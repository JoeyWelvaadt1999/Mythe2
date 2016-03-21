using UnityEngine;
using System.Collections;

public class LifePoints : MonoBehaviour
{
	private PlayerRespawn _playerRespawn;
	protected int _health;
	public int Health {
		get { 
			return _health;
		}
	}

	void Start () {
		_playerRespawn = FindObjectOfType<PlayerRespawn> ();
	}

	protected void DecreaseHealth (int damage, GameObject go) {
		_health -= damage;
		if (_health <= 0) {
			Destroy (go.gameObject);
			if(go.gameObject.tag == Tags.player)
				StartCoroutine(_playerRespawn.WaitForRespawn(_playerRespawn.RespawnTime));
		}
	}
}
