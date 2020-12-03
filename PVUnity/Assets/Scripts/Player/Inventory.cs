using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool keyCard = false;

    public List<GameObject> weapons;

    public Transform hand;

    public GameObject currentWeapon;

    private Controller2D controller2D;

    private int maxWeapons = 2;

    void Start()
    {
        controller2D = GetComponent<Controller2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1f, new Vector2(0f, 0f));

        if(hit)
        {
            if (hit.collider.CompareTag("KeyPickup"))
            {   
                keyCard = true;
                Object.Destroy(hit.collider.gameObject);
            }
            if (hit.collider.CompareTag("AmmoPickup"))
            {
                Object.Destroy(hit.collider.gameObject);
                for (int i = 0; i < weapons.Count; i++)
                {
                    weapons[i].GetComponent<ShootGun>().GiveAmmo(20);
                    currentWeapon.GetComponent<ShootGun>().DisplayAmmo();
                }
            }

            if (hit.collider.CompareTag("Pickup") && Input.GetKeyDown(KeyCode.E))
            {
                GameObject newWeapon = (GameObject)Instantiate(hit.collider.gameObject.GetComponent<Pickable>().weapon, hand, false);
                newWeapon.SetActive(false);

                if (weapons.Count < maxWeapons)
                {
                    weapons.Add(newWeapon);
                }
                else
                {
                    for(int i = 0; i < weapons.Count; i++)
                    {
                        if(weapons[i].GetInstanceID() == currentWeapon.GetInstanceID())
                        {
                            DropWeapon(i);
                            weapons.Insert(i, newWeapon);
                            currentWeapon = weapons[i];
                            break;
                        }
                    }
                }
                Object.Destroy(hit.collider.gameObject);

            }

            

        }

        if (Input.GetKeyDown(KeyCode.G) && currentWeapon != null)
        {
            DropWeapon();
        }

    }

    void DropWeapon()
    {
        int weaponId = currentWeapon.GetInstanceID();

        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].GetInstanceID() == weaponId)
            {
                weapons.RemoveAt(i);
                break;
            }
        }
        currentWeapon.GetComponent<ShootGun>().DisplayEmptyAmmo();

        Object.Destroy(currentWeapon);
        currentWeapon = null;
    }

    void DropWeapon(int index)
    {
        weapons.RemoveAt(index);
        currentWeapon.GetComponent<ShootGun>().DisplayEmptyAmmo();
        Object.Destroy(currentWeapon);
        currentWeapon = null;

    }

    void SelectWeapon(int index)
    {
        if(weapons.Count > index && weapons[index] != null)
        {
            if(currentWeapon != null)
            {
                currentWeapon.gameObject.SetActive(false);
            }

            currentWeapon = weapons[index];

            currentWeapon.SetActive(true);
            currentWeapon.GetComponent<ShootGun>().DisplayAmmo();
            controller2D.SetWeapon(currentWeapon.GetComponent<Weapon>());
        }
    }
  
}
