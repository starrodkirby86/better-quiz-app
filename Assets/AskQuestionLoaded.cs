using UnityEngine;
using System.Collections;

public class AskQuestionLoaded : MonoBehaviour {

	/**
	 * On level was loaded...
	 */
	void OnLevelWasLoaded(int level) {
		GameObject coreObject = GameObject.Find ("GameCore");
		Core hooray = coreObject.GetComponent<Core>();
		hooray.makeGUILevelTrue ();
		Debug.Log (level);
		Debug.Log ("That level was loaded. ;)");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
