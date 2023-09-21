using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float speed = 8f;
    public GameObject PlayerBulletGo;
    public GameObject BulletPosition1;
    public GameObject BulletPosition2;
    public GameObject ExplosionGO;
    public BackgroundMovement backgroundMovement;

    public static int switchCount = 0;

    private bool isUpsideDown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isUpsideDown = !isUpsideDown;
            switchCount++;
            SwitchPositionAndDirection();
        }

        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(x, y).normalized;
        Move(direction);
    }

    void SwitchPositionAndDirection()
    {
        transform.rotation = Quaternion.Euler(0, 0, isUpsideDown ? 180 : 0);

        if (backgroundMovement)
        {
            backgroundMovement.ToggleScrollDirection();
        }
    }

    void Shoot()
    {
        GameObject bullet01 = Instantiate(PlayerBulletGo);
        bullet01.transform.position = BulletPosition1.transform.position;
        bullet01.GetComponent<PlayerBullet>().isShootingUp = !isUpsideDown;

        GameObject bullet02 = Instantiate(PlayerBulletGo);
        bullet02.transform.position = BulletPosition2.transform.position;
        bullet02.GetComponent<PlayerBullet>().isShootingUp = !isUpsideDown;
    }

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 0.225f; min.x = min.x + 0.225f;
        max.y = max.y - 0.225f; min.y = min.y + 0.225f;
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShipTag")
        {
            PlayExplosion();
            Destroy(gameObject);
            GameOver();
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }

    void GameOver()
    {
        Time.timeScale = 0;
    }

}
