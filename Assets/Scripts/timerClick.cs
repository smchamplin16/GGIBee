using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangedEventDelegate(string text);

public class timerClick : MonoBehaviour {

    private UnityEngine.UI.Text time;
    private string oldTimeText;
    private string newTimeText;
    public AudioClip countdown;
    public AudioClip resetSound;
    private AudioSource source;
    public string startTime;
    private bool reset;

	// Use this for initialization
	void Start () {
        reset = true;
        source = GetComponent<AudioSource>();
        time = GetComponent<UnityEngine.UI.Text>();
        startTime = time.text;
        oldTimeText = time.text;
        newTimeText = time.text;
    }
	
	// Update is called once per frame
	void Update () {
        if(newTimeText != oldTimeText) {
            if(newTimeText == startTime && reset) {
                source.PlayOneShot(resetSound);
            } else {
                source.PlayOneShot(countdown);
            }
            oldTimeText = newTimeText;
        }
        newTimeText = time.text;
    }
}
