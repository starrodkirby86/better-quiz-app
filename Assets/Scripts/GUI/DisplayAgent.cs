using UnityEngine;
using System.Collections;

public class DisplayAgent : MonoBehaviour {
	
	/**
	 * On level was loaded...
	 */
	void OnLevelWasLoaded(int level) {
		loadCache ();
		if (hooray != null)
			Debug.Log ("We found the Core :D");
		else
			Debug.Log ("No Core.... :(");
		Debug.Log (level);
		Debug.Log ("That level was loaded. ;)");
	}

	// Cache the GameCore to improve performance
	Core hooray;

	void loadCache(){
		// Find Core
		if (hooray == null) {
			GameObject coreObject = GameObject.Find ("GameCore");
			Core hooray = coreObject.GetComponent<Core>();
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
