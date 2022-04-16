using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponHandler : MonoBehaviour
{
    //private Animator anim;

    [SerializeField]
    private GameObject[] weapons;

    private int current_weapon_index;
    public GameObject current_weapon;

    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        current_weapon_index = 0;
        weapons[0].gameObject.SetActive(true);
        weapons[1].gameObject.SetActive(false);
        weapons[2].gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);
        }
        current_weapon = weapons[current_weapon_index];
    }
    void TurnOnSelectedWeapon(int index)
    {
        weapons[current_weapon_index].gameObject.SetActive(false);
        weapons[index].gameObject.SetActive(true);
        current_weapon_index = index;
    }
}
