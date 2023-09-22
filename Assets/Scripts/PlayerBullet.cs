using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
<<<<<<< HEAD

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 12f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        // destroy bullet when it's out
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        if(transform.position.y > max.y) {
            Destroy(gameObject);
        }

        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "EnemyShipTag") {
            Destroy (gameObject);
=======
    public float speed = 12f;
    public bool isShootingUp = true;

    void Update()
    {
        Vector2 position = transform.position;
        float yMovement = isShootingUp ? speed : -speed;
        position = new Vector2(position.x, position.y + yMovement * Time.deltaTime);
        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if ((isShootingUp && transform.position.y > max.y) || (!isShootingUp && transform.position.y < min.y))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag")
        {
            Destroy(gameObject);
>>>>>>> new-feature
        }
    }
}
