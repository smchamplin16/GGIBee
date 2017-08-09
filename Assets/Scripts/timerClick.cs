using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangedEventDelegate(string text);

public class timerClick : MonoBehaviour {

    private UnityEngine.UI.Text time;
    private string oldTimeText;
    private string newTimeText;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        time = GetComponent<UnityEngine.UI.Text>();
        oldTimeText = time.text;
        newTimeText = time.text;
    }
	
	// Update is called once per frame
	void Update () {
        if(newTimeText != oldTimeText) {
            source.Play();
            oldTimeText = newTimeText;
        }
        newTimeText = time.text;
    }
}
