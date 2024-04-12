using System;
using System.Collections;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public int currrentLevel;
    public Rigidbody2D brickPrefab;

    public BallMovement ballMovement;
    // Start is called before the first frame update
    private Rigidbody2D[] bricks = new Rigidbody2D[0];
    private float xBrickSize = 1f;
    private float yBrickSize = 0.3f;
    private int brickCount;
    void Start()
    {
        brickCount = 0;
        LoadLevel(currrentLevel);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator LoadNextLevel()
    {
        currrentLevel = currrentLevel + 1;
        bricks = new Rigidbody2D[0];
        ballMovement.SetupBall();
        LoadLevel(currrentLevel);
        yield return new WaitForSeconds(3);
        ballMovement.MoveBall(new Vector2(0, -1));
    }

    private void LoadLevel(int currrentLevel)
    {
        if (currrentLevel == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Array.Resize(ref bricks, bricks.Length + 1);
                    brickCount = brickCount + 1;
                    bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(i * xBrickSize, j * yBrickSize - 1, 0), Quaternion.identity);
                    Array.Resize(ref bricks, bricks.Length + 1);
                    brickCount = brickCount + 1;
                    bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(-1 * i * xBrickSize, j * yBrickSize - 1, 0), Quaternion.identity);
                }
            }
        }
        if (currrentLevel == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0 || i % 2 == 1 && j % 2 == 1)
                    {
                        Array.Resize(ref bricks, bricks.Length + 1);
                        brickCount = brickCount + 1;
                        bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(i * xBrickSize, j * yBrickSize - 1, 0), Quaternion.identity);
                        Array.Resize(ref bricks, bricks.Length + 1);
                        brickCount = brickCount + 1;
                        bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(-1 * i * xBrickSize, j * yBrickSize - 1, 0), Quaternion.identity);
                    }
                }
            }
        }
        if (currrentLevel == 3)
        {
            Array.Resize(ref bricks, bricks.Length + 1);
            brickCount = brickCount + 1;
            bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            Array.Resize(ref bricks, bricks.Length + 1);
            brickCount = brickCount + 1;
            bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(0, 1, 0), Quaternion.identity);

        }
        if (currrentLevel == 4)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Array.Resize(ref bricks, bricks.Length + 1);
                    brickCount = brickCount + 1;
                    bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(i * xBrickSize, j * yBrickSize - 1, 0), Quaternion.identity);
                    Array.Resize(ref bricks, bricks.Length + 1);
                    brickCount = brickCount + 1;
                    bricks[bricks.Length - 1] = Instantiate(brickPrefab, new Vector3(-1 * i * xBrickSize, j * yBrickSize - 1, 0), Quaternion.identity);
                }
            }
        }
        SetColors();
    }

    public void RemoveBrick(GameObject hitBrick)
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if ((bricks[i] != null) && (bricks[i].gameObject == hitBrick))
            {
                DestroyGameObject(hitBrick);
                bricks[i] = null;
                brickCount = brickCount - 1;

            }
        }
        if (brickCount == 0) { StartCoroutine(LoadNextLevel()); }
    }

    void DestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void SetColors()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            Color brickColor = Color.white;
            var brickRenderer = bricks[i].gameObject.GetComponent<Renderer>();
            switch ((bricks[i].position.y + 1) / yBrickSize)
            {
                case 0:
                case 1:
                    brickColor = Color.blue;
                    break;
                case 2:
                case 3:
                    brickColor = Color.cyan;
                    break;
                case 4:
                case 5:
                    brickColor = Color.magenta;
                    break;
                case 6:
                case 7:
                    brickColor = Color.gray;
                    break;
                case 8:
                case 9:
                    brickColor = Color.green;
                    break;
                case 10:
                case 11:
                    brickColor = Color.yellow;
                    break;
                case 12:
                case 13:
                    brickColor = Color.red;
                    break;
                case 14:
                case 15:
                    brickColor = Color.red;
                    break;
                case 16:
                    brickColor = Color.white;
                    break;

            }
            brickRenderer.material.SetColor("_Color", brickColor);
        }

    }
}
