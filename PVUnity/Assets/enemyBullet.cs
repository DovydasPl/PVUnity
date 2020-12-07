using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public float RangedDamage = 25;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 8f);
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<Player>().ReceiveDamage(RangedDamage);
            Destroy(this.gameObject, 0.2f);
        }
        else {
            Destroy(this.gameObject, 0.2f);
        }

    }
}
