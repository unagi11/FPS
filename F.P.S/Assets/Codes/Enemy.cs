using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover {

    public GameObject HitedExplosion;
    public GameObject DeadExplosion;

    protected override void Start()
    {
        base.Start();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " hited " + collision.name);
        InGameLog.LogFunc(name + " hited " + collision.name);

        if (collision.CompareTag("PlayerBullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (HealthPoint <= 0)
            {
                Instantiate(DeadExplosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }

            Instantiate(HitedExplosion, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            HealthPoint -= bullet.BulletDamage;
        }
    }

    protected override IEnumerator MakeBullet()
    {
        while (true)
        {
            Instantiate(Bullet, transform.position, Quaternion.AngleAxis(180, new Vector3(0, 0, 1)));
            Instantiate(Bullet, transform.position, Quaternion.AngleAxis(170, new Vector3(0, 0, 1)));
            Instantiate(Bullet, transform.position, Quaternion.AngleAxis(170, new Vector3(0, 0, -1)));
            Instantiate(Bullet, transform.position, Quaternion.AngleAxis(160, new Vector3(0, 0, 1)));
            Instantiate(Bullet, transform.position, Quaternion.AngleAxis(160, new Vector3(0, 0, -1)));

            yield return new WaitForSeconds(ShootDelay);
        }
    }
}
