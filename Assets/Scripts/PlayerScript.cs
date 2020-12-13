﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private TrajectoryController trajectoryController;
    private SpriteRenderer spriteRenderer;
    private bool isPulling;
    private Vector3 startPosition;
    private int coins;

    public float maxMouseDelta;
    public float multiplier;
    public Text balonTimer;
    public int timer = 200;

    private bool IsNoVelocity => rb.velocity.x == 0 && rb.velocity.y == 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        trajectoryController = GetComponent<TrajectoryController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("DoCheck");
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {
            timer--;
            TimeSpan t = TimeSpan.FromSeconds(timer);
            balonTimer.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                t.Hours,
                t.Minutes,
                t.Seconds);
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPulling && IsNoVelocity)
            {
                isPulling = true;
                startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                trajectoryController.IsVisible = true;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (isPulling)
            {
                var diffPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPosition;
                var velocity = rb.velocity;
                velocity.y = -diffPosition.y * multiplier;
                velocity.x = -diffPosition.x * multiplier;
                trajectoryController.velocity = velocity;
                spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Косм2");
            }
        }
        else
        {
            if (!IsNoVelocity)
            {
                spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Косм3");
            }
            else
            {
                spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Косм");
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isPulling)
            {
                var diffPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - startPosition;
                UpdateVelocty(-diffPosition.x * multiplier, -diffPosition.y * multiplier);
                isPulling = false;
                spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Косм");
                trajectoryController.IsVisible = false;
            }
        }
    }

    private void FixedUpdate()
    {
    }

    private void UpdateVelocty(float? x = null, float? y = null)
    {
        var velocity = rb.velocity;
        if (y.HasValue)
        {
            velocity.y = y.Value;
        }
        if (x.HasValue)
        {
            velocity.x = x.Value;
        }
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject);
        }
    }
}
