using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
	public GameObject[] Levels;
	public GameObject player, pausePanel, gamePlayPanel, failPanel, instructionPanel, islandInstPanel, cart, mainCamera, slider, timer, score, checkPoint;
	public GameObject standardPosition, islandPosition, standardBoundry, standardRings, standardRamps, islandRings, islandRamps;
	public GameObject loading;
	public static bool instPanel;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		AudioListener.volume = 1;
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		failPanel.SetActive (false);
		for (int i = 0; i < Levels.Length; i++)
			Levels [i].SetActive (false);
		
		StartWait ();

		
	}

	void StartWait ()
	{
		if (MenuManager.StageSelection <= Levels.Length) {	
			if (instPanel) {
				AudioListener.volume = 0;
				instructionPanel.SetActive (true);
				instPanel = false;
			} else {
				instructionPanel.SetActive (false);
			}
			Levels [MenuManager.StageSelection - 1].SetActive (true);	
			player.transform.position = Levels [MenuManager.StageSelection - 1].transform.position;
			player.transform.rotation = Levels [MenuManager.StageSelection - 1].transform.rotation;
			cart.SetActive (true);
			slider.SetActive (true);
			checkPoint.SetActive (true);
			timer.SetActive (false);
			score.SetActive (false);
			standardBoundry.SetActive (false);
			standardRamps.SetActive (false);
			standardRings.SetActive (false);
			islandRamps.SetActive (false);
			islandRings.SetActive (false);
			mainCamera.transform.position = Levels [MenuManager.StageSelection - 1].transform.position;
		} else if (MenuManager.StageSelection == 20) {
			if (instPanel) {
				AudioListener.volume = 0;
				islandInstPanel.SetActive (true);
				instPanel = false;
			} else {
				islandInstPanel.SetActive (false);
			}
			cart.SetActive (false);
			slider.SetActive (false);
			checkPoint.SetActive (false);
			timer.SetActive (true);
			score.SetActive (true);
			standardBoundry.SetActive (true);
			standardRamps.SetActive (true);
			standardRings.SetActive (true);
			islandRamps.SetActive (false);
			islandRings.SetActive (false);
			player.transform.position = standardPosition.transform.position;
			player.transform.rotation = standardPosition.transform.rotation;
			mainCamera.transform.position = standardPosition.transform.position;
		} else if (MenuManager.StageSelection == 30) {
			if (instPanel) {
				AudioListener.volume = 0;
				islandInstPanel.SetActive (true);
				instPanel = false;
			} else {
				islandInstPanel.SetActive (false);
			}
			cart.SetActive (false);
			slider.SetActive (false);
			checkPoint.SetActive (false);
			timer.SetActive (true);
			score.SetActive (true);
			standardBoundry.SetActive (false);
			standardRamps.SetActive (false);
			standardRings.SetActive (false);
			islandRamps.SetActive (true);
			islandRings.SetActive (true);
			player.transform.position = islandPosition.transform.position;
			player.transform.rotation = islandPosition.transform.rotation;	
			mainCamera.transform.position = islandPosition.transform.position;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Pause ()
	{
		
		gamePlayPanel.SetActive (false);
		loading.SetActive (true);
		Invoke ("p1", 1);

//		StartCoroutine (PauseAd ());
	}

	void p1 ()
	{

		AudioListener.volume = 0;
		Invoke ("p2", 2);
	}

	void  p2 ()
	{
		
		loading.SetActive (false);
		pausePanel.SetActive (true);

		Time.timeScale = 0;
//		yield return new WaitForSeconds (1.0f);

//		Invoke ("p2", 2.0f);
	}



	public void Resume ()
	{
		AudioListener.volume = 1;
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		gamePlayPanel.SetActive (true);
	}

	public void BackToMenu ()
	{
		AudioListener.volume = 1;
		Time.timeScale = 1;
		StartCoroutine (wait (1));
	}

	public void Next ()
	{
		AudioListener.volume = 1;
		if (MenuManager.StageSelection > Levels.Length) {
			MenuManager.StageSelection = 1;
		}
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		failPanel.SetActive (false);
		gamePlayPanel.SetActive (true);

		StartCoroutine (wait (2));
	}

	IEnumerator wait (int index)
	{

		yield return new WaitForSeconds (1);
		SceneManager.LoadSceneAsync (index);
	}

	public void Restart ()
	{
		AudioListener.volume = 1;
		Time.timeScale = 1;
		pausePanel.SetActive (false);
		failPanel.SetActive (false);
		gamePlayPanel.SetActive (true);
		Application.LoadLevel (2);
	}

	public void OpenURLs (string url)
	{
		Application.OpenURL (url);
	}
}