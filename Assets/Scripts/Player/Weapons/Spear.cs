using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        Debug.Log("attacking with spear. Stabby stab stab");
    }
}
