using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 direcrin;
    private Vector2 lastDirecrin;


    void Start()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }
    void Update()
    {
        float direcionX = Input.GetAxisRaw("Horizontal");
        float direcionY = Input.GetAxisRaw("Vertical");

        direcrin = new Vector2(direcionX, direcionY).normalized;

        UpdateLastDirection();
    }
    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + direcrin * Player.Instance.GetSpeedValue() * Time.fixedDeltaTime);
    }

    public Vector2 GetDirection() {
        return lastDirecrin;
    }
    private void UpdateLastDirection() {
        if (direcrin.x != 0f)
            lastDirecrin.x = direcrin.x;
        if (direcrin.y != 0f)
            lastDirecrin.y = direcrin.y;
    }
}