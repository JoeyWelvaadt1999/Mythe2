using UnityEngine;
using System.Collections;

public class WeaponCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.SendMessage("TakeDamage",30);
        }
    }
}
