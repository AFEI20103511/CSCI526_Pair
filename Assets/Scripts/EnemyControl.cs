using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 2f;
    public GameObject ExplosionGO;
    private Vector2 direction = Vector2.down;  // Default direction is downwards

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if ((direction == Vector2.up && transform.position.y > max.y) || 
            (direction == Vector2.down && transform.position.y < min.y))
        {
            Destroy(gameObject);
        }
    }

    public void InitializeDirection(Vector2 dir)
    {
        direction = dir;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerBulletTag")
        {
            PlayExplosion();
            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
