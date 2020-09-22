using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    ShootGun gun;
    Vector3 mouse;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gun = GetComponent<ShootGun>();
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg);

        if (Input.GetMouseButton(0))
        {
             gun.Shoot(mouse);
        }   
    }

    public void FlipY(bool x)
    {
        spriteRenderer.flipY = x;   
    }
}
