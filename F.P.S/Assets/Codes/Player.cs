using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Mover {

    public int Level = 1;
    public const float normalSpeed = 7, slowSpeed = 3;
    private float PlayerSpeed = normalSpeed;
    private float h, v;

    public Joystick Joystick;
    public Button ShootButton;

    public GameObject HitedExplosion;
    public GameObject DeadExplosion;

    // Use this for initialization
    protected override void Start () {
        Joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        ShootButton = GameObject.FindGameObjectWithTag("ShootButton").GetComponent<Button>();
        base.Start();
    }

    // Update is called once per frame
    void Update () {
        Move();//똥 코드
	}

    private void Move()
    {
        h = PlayerSpeed * Time.deltaTime * Joystick.Horizontal;
        v = PlayerSpeed * Time.deltaTime * Joystick.Vertical;
        transform.Translate(h, v, 0);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;

        //http://phaphaya.tistory.com/59?category=656548 참조함

        //      transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") , Input.GetAxisRaw("Vertical"), 0) * PlayerSpeed * Time.deltaTime);
        //      ㄴ키보드 모드
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(name + " hited " + collision.name);
        InGameLog.LogFunc(name + " hited " + collision.name);
        if (collision.CompareTag("EnemyBullet"))
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
            if (ShootButton.GetComponent<ShootButtonHandler>()._pressed /*|| Input.GetButton("Jump")*/)// - 키보드 모드
            {
                if (Level == 1)
                {
                    Instantiate(Bullet, transform.GetChild(0).position, Quaternion.identity);
                }
                else if (Level == 2)
                {
                    Instantiate(Bullet, transform.GetChild(0).position, Quaternion.identity);
                    Instantiate(Bullet, transform.GetChild(1).position, Quaternion.AngleAxis(10, new Vector3(0, 0, 1)));
                    Instantiate(Bullet, transform.GetChild(2).position, Quaternion.AngleAxis(10, new Vector3(0, 0, -1)));
                }
                yield return new WaitForSeconds(ShootDelay);
            }
            yield return null;
        }
    }

}
