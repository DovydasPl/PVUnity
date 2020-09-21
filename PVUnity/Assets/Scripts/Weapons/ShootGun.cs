using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    Vector3 shootDirection;
    public Rigidbody2D projectile;
    public float projectileSpd;
    public Transform gunPoint;

    public void Shoot(Vector3 screenToWorld)
    {
        shootDirection = screenToWorld;
        shootDirection = shootDirection - transform.position;
        Rigidbody2D bulletInstance = Instantiate(projectile, gunPoint.position, transform.rotation) as Rigidbody2D;
        bulletInstance.velocity = new Vector2(shootDirection.x, shootDirection.y).normalized * projectileSpd;
    }
}
