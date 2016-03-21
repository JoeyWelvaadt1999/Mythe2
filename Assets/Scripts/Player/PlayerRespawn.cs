using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    private Transform lastPosition;
    [SerializeField]
    private Transform checkPointPosition;
    [SerializeField]
    private GameObject _player;

    private float _respawnTime = 3;
    public float RespawnTime
    {
        get
        {
            return _respawnTime;
        }

        set
        {
            value = _respawnTime;
        }
    }

    public IEnumerator WaitForRespawn(float time)
    {
        yield return new WaitForSeconds(time);
        CheckPointLoad();
    }

    void CheckPointLoad()
    {
        _player.transform.position = lastPosition.position;
    }

    void CheckPointSave()
    {
        lastPosition = checkPointPosition;
        print("checkpoint touched, position saved");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CheckPointSave();
        }
    }
}
