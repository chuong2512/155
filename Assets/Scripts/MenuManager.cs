using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;

public class MenuManager : MonoBehaviour
{
	public static int StageSelection = 0;
	public GameObject VideoNot, loadingPanel;
	public GameObject[] lockImages;
	public Text totalScoresText;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;


		VideoNot.SetActive (false);

		if (!PlayerPrefs.HasKey ("HighScores")) {
			PlayerPrefs.SetInt ("HighScores", 0);
		}
		if (!PlayerPrefs.HasKey ("IslandHighScores")) {
			PlayerPrefs.SetInt ("IslandHighScores", 0);
		}
		if (!PlayerPrefs.HasKey ("TotalScores")) {
			PlayerPrefs.SetInt ("TotalScores", 0);
		}

		if (!PlayerPrefs.HasKey ("UnlockedLevels"))
			PlayerPrefs.SetInt ("UnlockedLevels", 1);

		for (int i = 0; i < PlayerPrefs.GetInt ("UnlockedLevels") - 1; i++) {
			lockImages [i].SetActive (false);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		totalScoresText.text = "" + PlayerPrefs.GetInt ("TotalScores");
	}

	public void SelectLevels (int index)
	{
		StageSelection = index;
		GameManager.instPanel = true;
		StartCoroutine (LevelSelectionAds ());
	}

	IEnumerator LevelSelectionAds ()
	{
		Handheld.StartActivityIndicator ();
		yield return new WaitForSeconds (1);
		Application.LoadLevel (2);
	}

	public void FreePoints ()
	{
 {
			VideoNot.SetActive (true);
		}
	}

	public void BackBtnAds ()
	{
		StartCoroutine (waitForBackAds ());
	}

	IEnumerator waitForBackAds ()
	{
		yield return new WaitForSeconds (1);
		yield return new WaitForSeconds (1);
		loadingPanel.SetActive (false);
	}

	public void OpenURLs (string URL)
	{
		Application.OpenURL (URL);
	}
}