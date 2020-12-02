using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShootGun : MonoBehaviour
{
    Vector3 shootDirection;
    public Rigidbody2D projectile;
    public float projectileSpd;
    public Transform gunPoint;
    public int maxAmmo = 210;
    public int ammoTotal = 210;
    public int magSize = 30;
    public int ammoInMag = 30;
    public float rateOfFire = 10;
    public float reloadTime = 1.2f;
    private Text ammoDisplay;
    private SendMessage sendMsg;

    void Start()
    {
        ammoDisplay = GameObject.Find("AmmoText").GetComponent<Text>();
        sendMsg = GameObject.Find("StageMessageControllerMain").GetComponent<SendMessage>();
    }

    public void Shoot(Vector3 screenToWorld)
    {
        if (ammoInMag > 0)
        {
            shootDirection = screenToWorld;
            shootDirection = shootDirection - transform.position;
            Rigidbody2D bulletInstance = Instantiate(projectile, gunPoint.position, transform.rotation) as Rigidbody2D;
            bulletInstance.GetComponent<Bullet>().damage = GetComponent<Weapon>().damage;
            bulletInstance.velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * projectileSpd;
            ammoInMag--;
            ammoTotal--;
            DisplayAmmo();
        }
    }
    public void Reload()
    {
        if(ammoTotal > 0)
        {
            SendMessage(2);
            if (ammoTotal > magSize)
            {
                ammoInMag = magSize;
            }
            else
            {
                ammoInMag = ammoTotal;
            }

        }else
        {
            SendMessage(1);
        }

    }

    public void GiveAmmo(int ammo)
    {
        ammoTotal += ammo;
        if(ammoTotal > maxAmmo)
        {
            ammoTotal = maxAmmo;
        }
    }

    void SendMessage(int index)
    {
        if (sendMsg == null) return;
        sendMsg.SendMsg(index);
    }
    public void DisplayAmmo()
    {
        if (ammoDisplay == null) return;
        ammoDisplay.text = ammoInMag + "/" + ammoTotal;
    }

    public void DisplayEmptyAmmo()
    {
        if (ammoDisplay == null) return;
        ammoDisplay.text = "0/0";
    }
    public int GetAmmoInMag()
    {
        return ammoInMag;
    }

}
