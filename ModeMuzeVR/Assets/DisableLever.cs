using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableLever : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        Debug.Log(GetComponentInChildren<MeshRenderer>().gameObject);
        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform item in allChildren)
        {
            item.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
