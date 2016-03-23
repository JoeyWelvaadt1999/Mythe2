using UnityEngine;
using System.Collections;

public class Club : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        Debug.Log("Attacking with the club. smash smash smash");
    }
}
