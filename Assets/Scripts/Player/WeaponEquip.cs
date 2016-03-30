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
    private GameObject w;

    void Awake()
    {
        Club clubWeapon = new Club();
        Spear spearWeapon = new Spear();
        BearClaw bearClawWeapon = new BearClaw();

        _weaponList.Add(clubWeapon);
        _weaponList.Add(spearWeapon);
        _weaponList.Add(bearClawWeapon);

        for (int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].SetActive(false);
        }
    }
    
    public void EquipWeapon(IWeapon newWeapon)
    {
        equippedWeapon = newWeapon;
    }

    void SpawnWeapon(GameObject _w)
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            _w.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(_weaponList[0]);
            _weapons[1].SetActive(false);
            _weapons[2].SetActive(false);
            _weapons[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           EquipWeapon(_weaponList[1]);
            _weapons[0].SetActive(false);
            _weapons[2].SetActive(false);
            _weapons[1].SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EquipWeapon(_weaponList[2]);
            _weapons[0].SetActive(false);
            _weapons[1].SetActive(false);
            _weapons[2].SetActive(true);
        }

        for (int i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].transform.localScale = new Vector3(1, 1, 0);
        }
	}
}
