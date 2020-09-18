using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkParticle : MonoBehaviour
{
    float rate = 0;
    float rateMultiplyer = 0.5f;

    Player player;
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        rate = Mathf.Sqrt(player.velocity.x * player.velocity.x) + Mathf.Sqrt(player.velocity.y * player.velocity.y);
        ps.emissionRate = rate * rateMultiplyer;

    }
}
