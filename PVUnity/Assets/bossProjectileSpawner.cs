using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossProjectileSpawner : MonoBehaviour
{
    Vector3 shootDirection;
    public Rigidbody2D projectile;
    Vector3 screenToWorld;
    private Transform target;
    public float projectileSpeed = 15f;

   public float maxDelay = 1f;
   public float currentDelay = 0f;


    public AudioSource splash;
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 30)
        {
            if (currentDelay >= maxDelay)
            {
                currentDelay = 0;
                shootDirection = target.position - transform.position;
                Rigidbody2D bulletInstance = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody2D;
                Vector2 direction = (Vector2)transform.position - (Vector2)target.position; //get the direction to the target
                bulletInstance.GetComponent<Rigidbody2D>().velocity = direction.normalized * -10; //shoot the bullet
                splash.Play();
            }
        }
        currentDelay += 1 * Time.deltaTime;
    }
}
