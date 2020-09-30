using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float damage;
    void Start()
    {
        Destroy(this.gameObject, 2f);   
    }

    void OnCollisionEnter2D(Collision2D bullet)
    {
        Destroy(this.gameObject);
    }
}
