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
    public Text ammoDisplay;
    public SendMessage sendMsg;

    public void Shoot(Vector3 screenToWorld)
    {
        if (ammoInMag > 0)
        {
            shootDirection = screenToWorld;
            shootDirection = shootDirection - transform.position;
            Rigidbody2D bulletInstance = Instantiate(projectile, gunPoint.position, transform.rotation) as Rigidbody2D;
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
           if(ammoTotal > magSize)
            {
                ammoInMag = magSize;
            }
            else
            {
                ammoInMag = ammoTotal;
            }

        }else
        {
            sendMsg.SendMsg(1);
        }

    }
    public void DisplayAmmo()
    {
        ammoDisplay.text = ammoInMag + "/" + ammoTotal;
    }

}
