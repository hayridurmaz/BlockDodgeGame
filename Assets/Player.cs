using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 15f;
    public float mapWidth = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float k = 0;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log(touch.position.x);
                if (touch.position.x > (Screen.width / 2))
                {
                    k = 5f;//moves player right
                }

                if (touch.position.x < (Screen.width / 2))
                {
                    k= -5f; //moves player left
                }
            }
        }

        //Debug.Log(Input.GetAxis("Horizontal"));

        //Input.GetAxis("Horizontal")
        float x =k* Time.fixedDeltaTime * speed;
        Vector2 newPosition = rb.position + Vector2.right * x;
        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);
        rb.MovePosition(newPosition);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<GameManager>().endGame();
    }
}
