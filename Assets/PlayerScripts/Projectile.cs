using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private bool canHurtPlayer;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float moveSpeed;
    public Vector3 moveDirection;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!canHurtPlayer)
        {
            Vector3 mousePos = Input.mousePosition;
            moveDirection = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
            moveDirection.z = 0;
            moveDirection = moveDirection.normalized;
            playerData.recoilDirection = -moveDirection;
            playerData.applyRecoil = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(moveSpeed * Time.deltaTime * moveDirection.normalized, ForceMode2D.Impulse);
        if (transform.position.y > 7)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 12)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
