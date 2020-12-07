using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public float damageToMonsters = 300f;
    public float damageToPlayers = 40f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Player>().ReceiveDamage(damageToPlayers * Time.deltaTime);
        }
        if (col.gameObject.tag == "Monster")
        {
            col.GetComponent<MobAI>().ReceiveDamage(damageToMonsters * Time.deltaTime);
        }
        if (col.gameObject.tag == "Boss")
        {
            col.GetComponent<bossAI>().ReceiveDamage(damageToMonsters * Time.deltaTime);
        }
    }

}
