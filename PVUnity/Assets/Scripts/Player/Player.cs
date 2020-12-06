using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public Text hpText;
    public float moveSpeed = 10f;
    public float health = 100f;
    public bool isAlive = true;
    float angleRad;
    float angleDeg;


    public ParticleSystem bloodParticles;
    float delay = 0.5f;
    float timePassed = 0f;

    bool gettingDamaged = false;
    Vector3 lookAt;
    [HideInInspector]
    public Vector3 velocity;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
    }

    void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity.x = input.x * moveSpeed;
        velocity.y = input.y * moveSpeed;
        controller.Move(velocity * Time.deltaTime); 
        controller.FlipToMouse(Input.mousePosition.x);
    }

    void Update()
    {
        if (!isAlive)
        {
            Application.LoadLevel(0);
        }
        if(timePassed <= delay )
        {
            timePassed += 1 * Time.deltaTime;
        }
        else
        {
            gettingDamaged = false;
            
        }

        if (gettingDamaged == true)
        {
            bloodParticles.emissionRate = 30;
            
        }else
        {
            bloodParticles.emissionRate = 0f;
        }

    }
    public void ReceiveDamage(float damage)
    {
        health -= damage;
        hpText.text = "HP:" +Mathf.Round(health).ToString();
        gettingDamaged = true;
        timePassed = 0;
        if (health <= 0)
        {
            health = 0;
            isAlive = false;
        }

    }
    


}
