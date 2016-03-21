using UnityEngine;
using System.Collections;

public class GenerateTrees : MonoBehaviour {
	[SerializeField]private Vector2 _bounds;
	[SerializeField]private GameObject _tree;

	void Start() {
		StartCoroutine (SpawnTrees ());
	}

	IEnumerator SpawnTrees () {
		for (int i = 0; i < 50; i++) {
			Instantiate (_tree, new Vector3 (Random.Range (-_bounds.x, _bounds.x), Random.Range (-_bounds.y, _bounds.y), 0), Quaternion.identity);
			yield return new WaitForEndOfFrame ();
		}
	}
}
