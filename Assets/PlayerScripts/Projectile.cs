using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public PlayerData playerData;
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float piercesLeft;
    [SerializeField] private float bouncesLeft;
    public Vector3 moveDirection;
    private Rigidbody2D rb;
    void Awake()
    {
        piercesLeft = playerSO.bulletPierce;
        bouncesLeft = playerSO.bulletBounce;
        //piercesLeft = 0;
        rb = GetComponent<Rigidbody2D>();
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
        piercesLeft--;
        if (piercesLeft < 0)
        {
            Destroy(gameObject);
        }
    }
}
