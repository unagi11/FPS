using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : SoundSource {

    public float Speed;
    public int BulletDamage;
    public float BulletLife = 2f;

    // Use this for initialization
    protected override void Start () {
        StartCoroutine("BulletDie");
        base.Start();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(new Vector3(1f, 0, 0) * Speed * Time.deltaTime);
	}

    IEnumerator BulletDie()
    {
        yield return new WaitForSeconds(BulletLife);
        Destroy(gameObject);
    }
    
}
