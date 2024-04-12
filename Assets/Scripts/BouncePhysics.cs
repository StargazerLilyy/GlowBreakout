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

        float positionY = 1;

        float positionX = (ballPosition.x - racketPosition.x) / racketHeight * 2;

        ballMovement.MoveBall(new Vector2(positionX, positionY), true);
    }

    private void BrickBounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 brickPosition = collision.transform.position;

        float xDiff = ballPosition.x - brickPosition.x;
        float yDiff = ballPosition.y - brickPosition.y;

        if (xDiff > yDiff)
        {
            ballMovement.WallBounce(1);
        }
        else
        {
            ballMovement.WallBounce(0);
        }
    }

    private void TopWallBounce()
    {
        ballMovement.WallBounce(0);
    }

    private void SideWallBounce()
    {
        ballMovement.WallBounce(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PaddleBounce(collision);
        }
        else if (collision.gameObject.name == "BottomBorder")
        {
            Debug.Log("LIFE LOST"); //TODO
        }
        else if (collision.gameObject.name == "LeftBorder"
        || collision.gameObject.name == "RightBorder"
        )
        {
            SideWallBounce();
        }
        else if (collision.gameObject.name == "TopBorder")
        {
            TopWallBounce();
        }
        else if (collision.gameObject.name == "Brick(Clone)")
        {
            BrickBounce(collision);
            brickManager.RemoveBrick(collision.gameObject);
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
