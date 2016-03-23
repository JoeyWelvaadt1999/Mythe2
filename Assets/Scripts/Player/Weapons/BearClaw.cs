using UnityEngine;
using System.Collections;

public class BearClaw : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        Debug.Log("attacking with the bear claw. Scratch scratch scratch!");
    }
}
