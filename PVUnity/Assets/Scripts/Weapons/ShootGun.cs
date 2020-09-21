using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    Vector3 shootDirection;
    public Rigidbody2D projectile;
    public float projectileSpd;

    void Update()
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouse = Camera.main.ScreenToWorldPoint(mouseScreen);
       
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg );

        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;

        if (Input.GetMouseButton(0))
        {
            Rigidbody2D bulletInstance = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(shootDirection.x , shootDirection.y).normalized *projectileSpd; 
        }
    }
}
