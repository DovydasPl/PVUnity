using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Controller2D : MonoBehaviour
{
    public LayerMask collisionMask;
    public GameObject playerGFX;
    SpriteRenderer sr;
    Animator anim;

    const float skinWidth = .015f;

    public int horizontalRayCount = 4;
    public int verticalRayCount = 4;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    Vector2 rightRotation;
    Vector2 leftRotation;

    BoxCollider2D boxCollider;
    RaycastOrigins raycastOrigins;
    

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        sr = playerGFX.GetComponent<SpriteRenderer>();
        anim = playerGFX.GetComponent<Animator>();
        CalculateRaySpacing();
        leftRotation = new Vector2(0f, 180f);
        rightRotation = new Vector2(0f, 0f);
    }

    public void Move(Vector3 velocity)
    {
        UpdateRaycastOrigins();
        if (velocity.x != 0)
        {
            FlipX(velocity.x);
        }
        if (velocity.x != 0)
        {
            HorizontalCollisions(ref velocity);
        }
        if(velocity.y != 0)
        {
            VerticalCollisions(ref velocity);
        }


        AnimateLePlayer(velocity);
        transform.Translate(velocity);
    }


    public void RotateToMouse(float angleDeg)
    {
        playerGFX.transform.rotation = Quaternion.Euler(0, 0, angleDeg);
    }

    void AnimateLePlayer(Vector3 velocity)
    {
        anim.SetFloat("velocityX", Mathf.Abs(velocity.x));
    }

    void FlipX(float x)
    {
        if(x > 0)
        {
            playerGFX.transform.eulerAngles = rightRotation;
        }else
        if (x < 0)
        {
            playerGFX.transform.eulerAngles = leftRotation;

        }
    }

    void VerticalCollisions(ref Vector3 velocity)
    {
        float directionY = Mathf.Sign(velocity.y);
        float rayLenght = Mathf.Abs(velocity.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLenght, collisionMask);

            Debug.DrawRay(rayOrigin, Vector3.up * directionY * rayLenght, Color.red);

            if (hit)
            {
                velocity.y = (hit.distance-skinWidth) * directionY;
                rayLenght = hit.distance;
            }
        }
    }

    void HorizontalCollisions(ref Vector3 velocity)
    {
        float directionX = Mathf.Sign(velocity.x);
        float rayLenght = Mathf.Abs(velocity.x) + skinWidth;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLenght, collisionMask);

            Debug.DrawRay(rayOrigin, Vector3.right * directionX * rayLenght, Color.red);


            if (hit)
            {
                velocity.x = (hit.distance - skinWidth) * directionX;
                rayLenght = hit.distance;
            }
        }
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        raycastOrigins.bottomLeft = new Vector2(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector2(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector2(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector2(bounds.max.x, bounds.max.y);

    }

    void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinWidth * -2);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);


    }

    struct RaycastOrigins
    {
        public Vector2 topLeft, topRight;
        public Vector2 bottomLeft, bottomRight;
    }
}
