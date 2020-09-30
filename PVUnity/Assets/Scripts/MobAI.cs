﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAI : MonoBehaviour
{
    public Transform target;
     float hp = 300f;
    float noticeRadius = 5f;
     float speed = 5f;
    bool aggressive = false;
    Vector3 targetPos;
    Vector3 initialPos;
    void Start()
    {
        targetPos = new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3), -2);
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) Destroy(this.gameObject);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (transform.position == targetPos && aggressive == false)
        {
            MoveToRandomPos();
        }
        if(Vector2.Distance(target.position,transform.position) <= 3)
        {
            aggressive = true;
            targetPos = new Vector3(target.transform.position.x, target.transform.position.y,-2);
        }
        else
        {
            aggressive = false;
        }

    }
    void MoveToRandomPos()
    {
        targetPos = new Vector3(initialPos.x + Random.Range(-3, 3), initialPos.y + Random.Range(-3, 3), -2);
    }
    void OnCollisionEnter2D(Collision2D bullet)
    {
        if (bullet.gameObject.tag == "Bullet")
        {
            hp -= bullet.gameObject.GetComponent<Bullet>().damage;
        }
    }



}