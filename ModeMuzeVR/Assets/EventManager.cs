using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {
    public List<GameObject> activeObjects;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddActiveObject(GameObject activeObject)
    {
        Debug.Log(activeObject);
        activeObjects.Add(activeObject);
        GameObject tutorial = GameObject.Find("Tutorial");
        if(activeObject == tutorial)
        {
            if (tutorial.GetComponent<Tutorial>().GetTutorialIndex() == 1)
            {
                tutorial.GetComponent<Tutorial>().IncrementTutorialIndex();
            }
            if (tutorial.GetComponent<Tutorial>().GetTutorialIndex() == 2)
            {
                tutorial.GetComponent<Tutorial>().IncrementTutorialIndex();
            }
        }
    }
}
