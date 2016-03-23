using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponEquip : MonoBehaviour
{
    IWeapon equippedWeapon;
    private List<IWeapon> _weaponList = new List<IWeapon>();
    [SerializeField]
    private List<GameObject> _weapons = new List<GameObject>();
    [SerializeField]
    private GameObject _weaponSpawnPoint;
    private IWeapon currWeapon;
    private GameObject w;

    void Awake()
    {
        Club clubWeapon = new Club();
        Spear spearWeapon = new Spear();
        BearClaw bearClawWeapon = new BearClaw();

        _weaponList.Add(clubWeapon);
        _weaponList.Add(spearWeapon);
        _weaponList.Add(bearClawWeapon);
    }

	// Use this for initialization
	void Start ()
    {

    }

    public void EquipWeapon(IWeapon newWeapon)
    {
        equippedWeapon = newWeapon;
    }

    void SpawnWeapon(GameObject _w)
    {
        w = Instantiate(_w,_weaponSpawnPoint.transform.position, Quaternion.identity) as GameObject;
        w.transform.parent = _weaponSpawnPoint.transform.parent;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(_weaponList[0]);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           EquipWeapon(_weaponList[1]);
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(_weaponList[2]);
            
        }
        equippedWeapon.Attack();
	}
}
