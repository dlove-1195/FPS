using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab_bullet;
    
    private GameObject prefab_gun;
    private WeaponHandler weapon_handler;
    private Vector3 ini_position;
    // Start is called before the first frame update
    void Start()
    {
        weapon_handler = GetComponent<WeaponHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        prefab_gun = weapon_handler.current_weapon;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(prefab_bullet);
        bullet.transform.position = prefab_gun.transform.position;
        Vector3 rotation = new Vector3(prefab_gun.transform.eulerAngles.x, prefab_gun.transform.eulerAngles.y, prefab_gun.transform.eulerAngles.z);
        bullet.transform.rotation = Quaternion.Euler(rotation);
    }
}
