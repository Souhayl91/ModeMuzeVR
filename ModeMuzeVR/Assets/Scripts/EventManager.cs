using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class EventManager : MonoBehaviour {

    public PlayableDirector tutorialTimeline;
    public delegate void OnTimePassed();
    public static event OnTimePassed onPauseTimeline;
    private bool _isPaused;

    // Use this for initialization
    void Start () {
        _isPaused = false;
        onPauseTimeline += PauseTimeline;
	}
	
	// Update is called once per frame
	void Update () {
		if(tutorialTimeline.time >= 12 && _isPaused == false )
        {
            if(onPauseTimeline != null)
            {
                onPauseTimeline();
            }
        }
	}

    void PauseTimeline()
    {
        _isPaused = true;
        tutorialTimeline.playableGraph.GetRootPlayable(0).SetSpeed(0);

        //GameObject lever = GameObject.Find("Lever");
        //Destroy(lever.GetComponent<VRTK.VRTK_Lever>());
        //Destroy(lever.GetComponent<ConstantForce>());
        //Destroy(lever.GetComponent<ConfigurableJoint>());
        //Destroy(lever.GetComponent<Rigidbody>());
    }

    void ResumeTimeline()
    {
        tutorialTimeline.Resume();
    }
}
