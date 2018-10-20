using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour {

	private int noOfDisplay = 6;

	public VideoPlayer[] videoplayers;

	public GameObject[] playButtons;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < noOfDisplay; i++) {
			GameObject display = videoplayers [i].transform.parent.GetChild(1).gameObject;
			display.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Play video on click of Play button
	public void PlayButtonClicked( int index) {
		Debug.Log ("Clicked " + index);	
		playButtons [index].SetActive (false);

		GameObject display = videoplayers [index].transform.parent.GetChild(1).gameObject;
		display.SetActive (true);
		videoplayers [index].Play ();
	}

	//Reset each video player when user moves
	public void ResetAll() {
		for (int i = 0; i < noOfDisplay; i++) {
			GameObject display = videoplayers [i].transform.parent.GetChild(1).gameObject;
			display.SetActive (false);
			playButtons [i].SetActive (true);

			videoplayers [i].Stop ();
		}
	}

	public void TogglePause(int index) {
		if (videoplayers [index].isPlaying) {
			videoplayers [index].Pause ();
		} else {
			videoplayers [index].Play ();
		}
	}
}
