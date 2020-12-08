using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public float damage = 5f;
    private Transform target;
  public  float hp = 3000f;
  public  float noticeRadius = 15f;
   public float speed = 3f;
    bool aggressive = false;
    public GameObject keycard;
    Vector3 targetPos;
    Vector3 initialPos;

    
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        targetPos = new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3), -2);
        initialPos = transform.position;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Vector3 deadPos = new Vector3(this.transform.position.x, this.transform.position.y, -2);
            if (keycard != null) Instantiate(keycard, deadPos, Quaternion.identity);
            Destroy(this.gameObject);
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (transform.position == targetPos && aggressive == false)
        {
            MoveToRandomPos();
        }
        if (Vector2.Distance(target.position, transform.position) <= noticeRadius)
        {
            aggressive = true;
            targetPos = new Vector3(target.transform.position.x, target.transform.position.y, -2);
            if (Vector2.Distance(target.position, transform.position) <= 4f)
            {
                DamagePlayer();
            }
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
    void DamagePlayer()
    {
        target.GetComponent<Player>().ReceiveDamage(damage * Time.deltaTime);
    }
    public void ReceiveDamage(float damage)
    {
        hp -= damage;
    }
}
