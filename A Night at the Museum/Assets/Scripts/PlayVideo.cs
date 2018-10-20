using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour {

	private int noOfDisplay = 6;

	public VideoPlayer[] videoplayers;

	public GameObject[] playButtons;

	public Material playMaterial;

	public Material pauseMaterial;

	public Canvas sliderCanvas;

	public Slider slider;

	private float enterTime;
	private bool pointerFlag = false;
	private int buttonIndex;

	private Vector3 pausePos = new Vector3 (0f, -0.5f, 0f);
	private Vector3 playPos = new Vector3 (0f, 0.5f, 0f);

	// Use this for initialization
	void Start () {
		slider.maxValue = 1.5f;

		for (int i = 0; i < noOfDisplay; i++) {
			GameObject display = videoplayers [i].transform.parent.GetChild(1).gameObject;
			display.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (pointerFlag) {
			//Sets the progress slider value
			float sliderValue = Time.time - enterTime;
			slider.value = sliderValue;

			if ((Time.time - enterTime) > slider.maxValue) {
				PlayButtonClicked (buttonIndex);
				pointerFlag = false;
			}
		}
	}

	public void pointerEnter(int index) {
		pointerFlag = true;
		enterTime = Time.time;
		sliderCanvas.gameObject.SetActive (true);
		buttonIndex = index;
	}

	public void pointerExit() {
		pointerFlag = false;
		sliderCanvas.gameObject.SetActive (false);
	}

	//Play video on click of Play button
	public void PlayButtonClicked( int index) {
		GameObject display = videoplayers [index].transform.parent.GetChild(1).gameObject;
		display.SetActive (true);

		TogglePause (index);
	}

	//Reset each video player when user moves
	public void ResetAll() {
		for (int i = 0; i < noOfDisplay; i++) {
			GameObject display = videoplayers [i].transform.parent.GetChild(1).gameObject;
			display.SetActive (false);
			Renderer render =  playButtons[i].GetComponentsInChildren<Renderer>()[0];
			render.material = playMaterial;

			videoplayers [i].Stop ();
		}
	}

	public void TogglePause(int index) {
		if (videoplayers [index].isPlaying) {
			videoplayers [index].Pause ();
			Renderer render =  playButtons[index].GetComponentsInChildren<Renderer>()[0];
			render.material = playMaterial;

			playButtons [index].transform.position += playPos;
		} else {
			videoplayers [index].Play ();
			Renderer render =  playButtons[index].GetComponentsInChildren<Renderer>()[0];
			render.material = pauseMaterial;
		
			playButtons [index].transform.position += pausePos;
		}
	}

}
