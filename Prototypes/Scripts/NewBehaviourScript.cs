using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	public void SceneChange (string buttonLoad) {
        Application.LoadLevel(buttonLoad);
	
	}

	/* Update is called once per frame
	void Update () {
	
	}*/
}
