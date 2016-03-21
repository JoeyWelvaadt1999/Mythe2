using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{

    [HideInInspector]
    public bool isDeath;

    public void OnDeath()
    {
        isDeath = true;
        if (isDeath)
        {
            /* GetComponent<SpriteRenderer>().enabled = false;
             GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerMeleeAttack>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<Animator>().enabled = false;*/
        }
    }
}
