using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : MonoBehaviour {

    public float Vol = 0.2f;
    public AudioClip Sound;

    // Use this for initialization
    protected virtual void Start () {
        gameObject.AddComponent<AudioSource>().PlayOneShot(Sound, Vol);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
