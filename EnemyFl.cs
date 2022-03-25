using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFl : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public Vector2 mov;
    public float speed=5f;
    public bool isFlipped = false;
    private void Start()
    {
        if (player == null) return;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void LookAtPlayer()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
    private void Update()
    {
        if (player == null) return;
        LookAtPlayer();
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        direction.Normalize();
        mov = direction;
    }
    private void FixedUpdate()
    {
        MovePlayer(mov);
    }
    void MovePlayer(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }
}
