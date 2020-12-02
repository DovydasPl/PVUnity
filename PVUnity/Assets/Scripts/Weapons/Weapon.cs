using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    ShootGun gun;
    Vector3 mouse;
    float rof;
    float reloadTime;
    float shotCooldown = 0;
    float reloadCooldown = 0;
    bool reloading;
    public float damage = 50f;

    // Start is called before the first frame update
    void Start()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        gun = GetComponent<ShootGun>();
        gun.DisplayAmmo();
        rof = gun.rateOfFire;
        reloadTime = gun.reloadTime;
    }

    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg);

        if (Input.GetMouseButton(0) && shotCooldown <= 0 && reloading == false)
        {
            shotCooldown += 1 / rof;
             gun.Shoot(mouse);
        }   
        
        if(Input.GetKeyDown(KeyCode.R) && reloadCooldown <= 0)
        {
            reloadCooldown += reloadTime;
            reloading = true;
            gun.Reload();
            gun.DisplayAmmo();
        }
        if (gun.ammoInMag <= 0 && reloadCooldown <= 0)
        {
            reloadCooldown += reloadTime;
            reloading = true;
            gun.Reload();
            gun.DisplayAmmo();
        }
        if (shotCooldown > 0) shotCooldown -= 1 * Time.deltaTime;
        if (reloadCooldown > 0) reloadCooldown -= 1 * Time.deltaTime;
        if (reloadCooldown <= 0) reloading = false;
    }

    public void FlipY(bool x)
    {
        if (spriteRenderer == null) return;
        spriteRenderer.flipY = x;   
    }
}
