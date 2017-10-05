using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    private int _tutorialIndex;
    public GameObject[] textList;
	// Use this for initialization
	void Start () {
        _tutorialIndex = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public int GetTutorialIndex()
    {
        return _tutorialIndex;
    }

    public void SetTutorialIndex(int index)
    {
        _tutorialIndex = index;
    }

    public void IncrementTutorialIndex()
    {
        if(_tutorialIndex < 4)
        {
            Debug.Log("INSIDE TUTORIAL INDEX INCREMENT");
            textList[_tutorialIndex].transform.gameObject.SetActive(true);
            _tutorialIndex++;
        }
        

}
}
