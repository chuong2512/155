using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Advertisements;

public class Timer : MonoBehaviour
{
	public Slider slider;
	public GameObject GameOverPanal, fuelendPanel, loading;
	public GameObject GamePad;
	public AudioSource timeEndAudio;
	public Text Timetxt, totalScoreText, highestScoreText, currentScoresText;
	public static int GameOverChecker = 0;
	public static bool stop;
	int TimeCounter = 0;
	int LoopCounter;

	// Use this for initialization
	void Start ()
	{
		stop = false;
		GameOverPanal.SetActive (false);
		GamePad.SetActive (true);
		StartCoroutine (TimeFunction ());
		
	}

	IEnumerator TimeFunction ()
	{
		if (MenuManager.StageSelection == 1)
			TimeCounter = 125;
		if (MenuManager.StageSelection == 2)
			TimeCounter = 125;
		if (MenuManager.StageSelection == 3)
			TimeCounter = 220;
		if (MenuManager.StageSelection == 4)
			TimeCounter = 210;
		if (MenuManager.StageSelection == 5)
			TimeCounter = 180;
		if (MenuManager.StageSelection == 6)
			TimeCounter = 210;
		if (MenuManager.StageSelection == 7)
			TimeCounter = 210;
		if (MenuManager.StageSelection == 8)
			TimeCounter = 200;
		if (MenuManager.StageSelection == 9)
			TimeCounter = 200;
		if (MenuManager.StageSelection == 10)
			TimeCounter = 220;
		if (MenuManager.StageSelection == 20)
			TimeCounter = 75;
		if (MenuManager.StageSelection == 30)
			TimeCounter = 90;

		yield return new WaitForSeconds (0.01f);
		slider.maxValue = TimeCounter;
		if (!stop && MenuManager.StageSelection != 0)
			for (; TimeCounter >= 0; TimeCounter--) {	
				slider.value = TimeCounter;
				Timetxt.text = "" + TimeCounter;
				if (TimeCounter < 10)
					timeEndAudio.Play ();
				yield return new WaitForSeconds (1);
				if (TimeCounter == 0) {
					GameOverChecker = 1;
				}
			}
	}

	// Update is called once per frame
	void Update ()
	{
		if (CarCollision.ringsCounter) {
			TimeCounter = TimeCounter + 10;
			CarCollision.ringsCounter = false;
		}
		if (MenuManager.StageSelection != 0)
		if (GameOverChecker == 1) {
			StartCoroutine (LevelFailed ());
			GameOverChecker = 0;
		}
	}

	IEnumerator LevelFailed ()
	{		
		if (MenuManager.StageSelection < 20) {
			loading.SetActive (true);
			AudioListener.volume = 0;
			GamePad.SetActive (false);
			yield return new WaitForSeconds (2);

			yield return new WaitForSeconds (2);
			loading.SetActive (false);
			fuelendPanel.SetActive (true);
			Time.timeScale = 0.1f;

		} else {
			loading.SetActive (true);
			AudioListener.volume = 0;
			if (MenuManager.StageSelection == 20) {
				highestScoreText.text = "Highest Scores : " + PlayerPrefs.GetInt ("HighScores");
				totalScoreText.text = "Total Scores : " + PlayerPrefs.GetInt ("TotalScores");
			} else if (MenuManager.StageSelection == 30) {
				highestScoreText.text = "Highest Scores : " + PlayerPrefs.GetInt ("IslandHighScores");
				totalScoreText.text = "Total Scores : " + PlayerPrefs.GetInt ("TotalScores");
			}
			GamePad.SetActive (false);
			yield return new WaitForSeconds (2);

			yield return new WaitForSeconds (2);
			yield return new WaitForSeconds (1);
			loading.SetActive (false);
			GameOverPanal.SetActive (true);
			Time.timeScale = 0.1f;

		}
	}
	//		GamePad.SetActive (false);
	//		yield return new WaitForSeconds (1);
	//		GameOverPanal.SetActive (true);
	//		Time.timeScale = 0.1f;
	//		AudioListener.volume = 0;
	//		if (HZInterstitialAd.isAvailable ()) {
	//			HZInterstitialAd.show ();
	//		} else if (HZVideoAd.isAvailable ()) {
	//
	//			HZVideoAd.show ();
	//		} else if (Advertisement.IsReady ()) {
	//			Advertisement.Show ();
	//		} else {
	//			AppLovin.ShowInterstitial ();
	//			AppLovin.PreloadInterstitial ();
	//		}
	//		Admob.Instance ().showBannerRelative (new AdSize (300, 250), admob.AdPosition.BOTTOM_LEFT, 0, "Banner");
	//		loading.SetActive (false);
	//	}
}
