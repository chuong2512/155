using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarCollision : MonoBehaviour
{
	public GameObject WaterSplash, loading;
	public GameObject CompeletPanel;
	public GameObject GamePanel, scoreText;
	public GameObject bikeArrow, bikeBox, mainCamera, player;
	public Text CheckPointLeftText, earnedScoreText, currentScoresText;
	public GameObject[] dropBoxes, pickUpBoxes, pickUpArrows, dropArrows;

	public AudioSource ringCollectAudio;
	public static int index;
	public static bool ringsCounter;
	int currentScoresCounter = 0;
	bool arrowSwitch = true, rotateCamera = false;
	int CheckPointCheckLeft;

	// Use this for initialization
	void Start ()
	{	
		player = GameObject.FindGameObjectWithTag ("Player");
		if (MenuManager.StageSelection < 20) {
			bikeArrow.SetActive (true);
		} else {
			bikeArrow.SetActive (false);
		}
		ringsCounter = false;
		CompeletPanel.SetActive (false);
		WaterSplash.SetActive (false);

		if (MenuManager.StageSelection == 1) {
			index = 0;
			CheckPointCheckLeft = 2;
		} else if (MenuManager.StageSelection == 2) {
			index = 2;
			CheckPointCheckLeft = 2;
		} else if (MenuManager.StageSelection == 3) {
			index = 4;
			CheckPointCheckLeft = 3;
		} else if (MenuManager.StageSelection == 4) {
			index = 7;
			CheckPointCheckLeft = 3;
		} else if (MenuManager.StageSelection == 5) {
			index = 10;
			CheckPointCheckLeft = 3;
		} else if (MenuManager.StageSelection == 6) {
			index = 13;
			CheckPointCheckLeft = 3;
		} else if (MenuManager.StageSelection == 7) {
			index = 16;
			CheckPointCheckLeft = 3;
		} else if (MenuManager.StageSelection == 8) {
			index = 19;
			CheckPointCheckLeft = 3;
		} else if (MenuManager.StageSelection == 9) {
			index = 22;
			CheckPointCheckLeft = 4;
		} else if (MenuManager.StageSelection == 10) {
			index = 26;
			CheckPointCheckLeft = 4;
		}

		if (MenuManager.StageSelection != 0)
			CheckPointLeftText.text = "" + CheckPointCheckLeft;
	}

	// Update is called once per frame
	void Update ()
	{
		ScoresManager ();
		if (MenuManager.StageSelection < 20) {
			if (rotateCamera) {
				mainCamera.GetComponent <BikeCamera> ().enabled = false;
				mainCamera.transform.RotateAround (player.transform.position, Vector3.up, 30 * Time.deltaTime);
			}
			if (arrowSwitch) {
				bikeArrow.transform.LookAt (GameObject.FindGameObjectWithTag ("PickUpArrow").transform);
			} else {
				bikeArrow.transform.LookAt (GameObject.FindGameObjectWithTag ("DropArrow").transform);
			}
		}
	}

	public void ScoresManager ()
	{
		earnedScoreText.text = "" + currentScoresCounter;
		currentScoresText.text = "" + currentScoresCounter;
		if (Timer.GameOverChecker == 1 && MenuManager.StageSelection == 20) {
			if (currentScoresCounter > PlayerPrefs.GetInt ("HighScores")) {
				PlayerPrefs.SetInt ("HighScores", currentScoresCounter);
			}
			PlayerPrefs.SetInt ("TotalScores", PlayerPrefs.GetInt ("TotalScores") + currentScoresCounter);
		} else if (Timer.GameOverChecker == 1 && MenuManager.StageSelection == 30) {
			if (currentScoresCounter > PlayerPrefs.GetInt ("IslandHighScores")) {
				PlayerPrefs.SetInt ("IslandHighScores", currentScoresCounter);
			}
			PlayerPrefs.SetInt ("TotalScores", PlayerPrefs.GetInt ("TotalScores") + currentScoresCounter);
		}
	}

	void OnCollisionEnter (Collision coll)
	{
		switch (coll.gameObject.tag) {
		case "BoxPick":
			pickUpBoxes [index].SetActive (false);
			pickUpArrows [index].SetActive (false);
			dropBoxes [index].SetActive (true);
			dropArrows [index].SetActive (true);
			bikeBox.SetActive (true);
			arrowSwitch = false;
			ringCollectAudio.Play ();
			break;
		case "BoxPickFinal":
			pickUpBoxes [index].SetActive (false);
			pickUpArrows [index].SetActive (false);
			dropBoxes [index].SetActive (true);
			dropArrows [index].SetActive (true);
			bikeBox.SetActive (true);
			arrowSwitch = false;
			ringCollectAudio.Play ();
			break;
		}
	}

	IEnumerator OnTriggerEnter (Collider col)
	{
		switch (col.gameObject.tag) {
		case "Rings":
			ringCollectAudio.Play ();
			ringsCounter = true;
			currentScoresCounter = currentScoresCounter + 250;
			scoreText.SetActive (true);
			yield return new WaitForSeconds (2);
			scoreText.SetActive (false);
			break;
		case "Water":
			WaterSplash.SetActive (true);
			yield return new WaitForSeconds (1.0f);
			WaterSplash.SetActive (false);
			break;
		case "BoxDrop":
			dropBoxes [index].GetComponent <CapsuleCollider> ().enabled = false;
			dropArrows [index].SetActive (false);
			bikeBox.SetActive (false);
			ringCollectAudio.Play ();
			yield return new WaitForSeconds (0.3f);
			dropBoxes [index].transform.GetChild (0).gameObject.SetActive (true);
			index++;
			pickUpBoxes [index].GetComponent <BoxCollider> ().enabled = true;
			pickUpArrows [index].SetActive (true);
			arrowSwitch = true;
			CheckPointCheckLeft--;
			if (MenuManager.StageSelection != 0)
				CheckPointLeftText.text = "" + CheckPointCheckLeft;
			break;
		case "BoxDropFinal":
			dropBoxes [index].GetComponent <CapsuleCollider> ().enabled = false;
			dropArrows [index].SetActive (false);
			bikeBox.SetActive (false);
			Timer.stop = true;
			ringCollectAudio.Play ();
			yield return new WaitForSeconds (0.2f);
			dropBoxes [index].transform.GetChild (0).gameObject.SetActive (true);
			index++;
			arrowSwitch = true;
			rotateCamera = true;
			CheckPointCheckLeft--;

			if (MenuManager.StageSelection != 0)
				CheckPointLeftText.text = "" + CheckPointCheckLeft;

			if (MenuManager.StageSelection == PlayerPrefs.GetInt ("UnlockedLevels")) {
				MenuManager.StageSelection++;
				PlayerPrefs.SetInt ("UnlockedLevels", PlayerPrefs.GetInt ("UnlockedLevels") + 1);
			}
			yield return new WaitForSeconds (4);
			bikeArrow.SetActive (false);
			loading.SetActive (true);
			GamePanel.SetActive (false);
			rotateCamera = false;
			AudioListener.volume = 0;
			yield return new WaitForSeconds (2);

			yield return new WaitForSeconds (2);
			yield return new WaitForSeconds (1);
			loading.SetActive (false);
			CompeletPanel.SetActive (true);

			Time.timeScale = 0.1f;

			break;

		}
	}
}