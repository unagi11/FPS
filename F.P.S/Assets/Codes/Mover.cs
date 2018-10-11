using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public int HealthPoint = 100;
    public GameObject Bullet;
    public float ShootDelay = 0.1f;
    public AudioSource audioSource;

    // Use this for initialization
    protected virtual void Start () {
        StartCoroutine("MakeBullet");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    protected virtual IEnumerator MakeBullet()
    {
        yield return null;
    }

}
