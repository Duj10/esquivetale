using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    public float shieldDuration = 1f;
    private bool shieldActive = false;
    private float shieldTimer = 0f;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                rb.linearVelocity = Vector2.left * moveSpeed;
            }
            else
            {
                rb.linearVelocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (shieldActive)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0)
            {
                shieldActive = false;
            }
        }
    }

    public void ActivateShield(float duration)
    {
        shieldActive = true;
        shieldTimer = duration;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Os")
        {
            if (shieldActive)
                return;
            SceneManager.LoadScene(0);
        }
    }
}