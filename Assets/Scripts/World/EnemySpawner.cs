using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _enemyList = new List<GameObject>();

    [SerializeField]
    private float _overlapRadius;

    private Collider2D _playerCollider;

    private bool _enemySpawned = false;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        SpawnEnemy();
	}

    void SpawnEnemy()
    {
        _playerCollider = Physics2D.OverlapCircle(this.transform.position, _overlapRadius);

        if (_playerCollider)
        {
            GameObject randomEnemy = _enemyList[Random.Range(0, _enemyList.Count)];

            if (!_enemySpawned)
            {
                Instantiate(randomEnemy, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
                _enemySpawned = true;
            }
        }
    }
}
