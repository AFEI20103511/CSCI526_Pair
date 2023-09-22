using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
<<<<<<< HEAD

    float speed;
    public GameObject ExplosionGO;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        if(transform.position.y < min.y) {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "PlayerShipTag" || col.tag == "PlayerBulletTag"){
            PlayExplosion();
            Destroy (gameObject);
        }
    }

    void PlayExplosion() {
        GameObject explosion = (GameObject)Instantiate (ExplosionGO);

=======
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
>>>>>>> new-feature
        explosion.transform.position = transform.position;
    }
}
