using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public EnemyData enemyData;
    public Vector3 moveDirection;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyData.applyRecoil = true;
    }
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
