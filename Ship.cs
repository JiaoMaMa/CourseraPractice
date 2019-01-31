using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ship object
public class Ship : MonoBehaviour
{
    //thrust support
    private Rigidbody2D rigidBody;
    private Vector2 thrustDirection = new Vector2(1, 0);
    const float thrustForce = 3.0f;

    //screen wrapping support
    float colliderRadius;
    bool isWrappingX = false;
    bool isWrappingY = false;

    //rotate support
    const float rotateDegreesPerSecond = 60f;

    // Start is called before the first frame update
    void Start()
    {
        //hold value for efficiency
        rigidBody = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;
        colliderRadius *= transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
            float rotationAngle = transform.eulerAngles.z;
            float rotationRadian = rotationAngle * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(rotationRadian);
            thrustDirection.y = Mathf.Sin(rotationRadian);
        }

    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Thrust") != 0)
        {
            rigidBody.AddForce(thrustDirection * thrustForce, ForceMode2D.Force);
        }
    }

    void OnBecameVisible()
    {
        isWrappingX = false;
        isWrappingY = false;
    }

    void OnBecameInvisible()
    {
        Wrap();    
    }

    void Wrap()
    {
        if (isWrappingX&&isWrappingY)
        {
            return;
        }

        Vector2 position = transform.position;
        if (!isWrappingX && (position.x - colliderRadius >= ScreenUtils.ScreenRight||
                                    position.x + colliderRadius <= ScreenUtils.ScreenLeft))
        {
            position.x *= -1;
            isWrappingX = true;
        }

        if (!isWrappingY && (position.y - colliderRadius >= ScreenUtils.ScreenTop||
                                    position.y + colliderRadius <= ScreenUtils.ScreenBottom))
        {
            position.y *= -1;
            isWrappingY = true;
        }

        transform.position = position;
    }

}
