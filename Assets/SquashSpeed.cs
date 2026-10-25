using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquashSpeed : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float squashFactorX;
    [SerializeField] private float squashFactorY;
    [SerializeField] private float squashAmount;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        squashFactorX = 1 + (Mathf.Abs(rb.velocity.x) * squashAmount);
        squashFactorY = 1 + (Mathf.Abs(rb.velocity.y) * squashAmount);

        transform.localScale = new Vector3(1 * squashFactorX / squashFactorY, 1 / squashFactorX * squashFactorY, 1);
    }
}
