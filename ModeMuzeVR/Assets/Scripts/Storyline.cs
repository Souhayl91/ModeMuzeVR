using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class Storyline : MonoBehaviour {
    public Animator[] animators;
    private bool startStory;
    private GameObject _storySnapZone;
	// Use this for initialization
	void Start () {
        StartStory();
    }

    private void Update()
    {
    }

    private void StartStory()
    {
        GetComponent<PlayableDirector>().Play();
    }
}
