using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePhysics : MonoBehaviour
{
    public GameObject hitSFX;
    public BallMovement ballMovement;
    public BrickManager brickManager;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void PaddleBounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.x;
        float xDir = (ballPosition.x - racketPosition.x) > 0 ? 1 : -1;
        float xVel = Math.Abs(ballPosition.x - racketPosition.x) > 0.25f ? (Math.Abs(ballPosition.x - racketPosition.x) - 0.25f) / racketHeight : 0f;
        float xAngleMulti = 6f;

        float positionY = 1;
        float positionX = xDir * xVel * xAngleMulti;

        ballMovement.MoveBall(new Vector2(positionX, positionY), true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PaddleBounce(collision);
        }
        else if (collision.gameObject.name == "BottomBorder")
        {
            if (!brickManager.LifeLost())
            {
                ballMovement.SetupBall();
                StartCoroutine(ballMovement.Launch());
            }
            else
            {
                ballMovement.SetupBall();
                brickManager.SetGameOver(true);
            }
        }
        else if (collision.gameObject.name == "LeftBorder"
        || collision.gameObject.name == "RightBorder"
        )
        {
        }
        else if (collision.gameObject.name == "TopBorder")
        {
        }
        else if (collision.gameObject.name == "Brick(Clone)")
        {
            brickManager.RemoveBrick(collision.gameObject);
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
