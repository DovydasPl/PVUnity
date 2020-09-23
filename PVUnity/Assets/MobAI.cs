using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
{
    float hp = 500;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D bullet)
    {
        if(bullet.gameObject.tag =="Bullet")
        {
            hp -= 35;
        }
    }
}
