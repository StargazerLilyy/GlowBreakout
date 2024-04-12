using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;

    private Vector2 curVelocity;

    //Get Functions
    public Vector2 getVelocity()
    {
        return rb.velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    public void SetupBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, -2);
    }

    public IEnumerator Launch()
    {
        SetupBall();
        yield return new WaitForSeconds(1);
        MoveBall(new Vector2(0, -1));

    }

    public void MoveBall(Vector2 direction, bool randVelocity = false)
    {
        direction = direction.normalized;

        float rand = UnityEngine.Random.Range(-2f, 2f);

        float ballSpeed = randVelocity ? rand + speed : speed;

        rb.velocity = direction * ballSpeed;
        UpdateVelocity();
    }

    public void WallBounce(int xChange)
    {
        if (xChange == 1)
        {
            rb.velocity = new UnityEngine.Vector2(-1 * curVelocity.x, curVelocity.y);
        }
        else
        {
            rb.velocity = new UnityEngine.Vector2(curVelocity.x, -1 * curVelocity.y);
        }
        UpdateVelocity();
    }

    private void UpdateVelocity()
    {
        curVelocity = rb.velocity;
    }
}
