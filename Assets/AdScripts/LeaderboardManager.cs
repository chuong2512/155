using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class LeaderboardManager : MonoBehaviour
{


	//Google Play Game Services Stuff
	public string leaderboard;
	public string achievement1;
	public string achievement2;
	public string achievement3;
	public string achievement4;
	public string achievement5;
	public string achievement6;
	public string achievement7;
	public string achievement8;
	public string achievement9;
	public string achievement10;
	public string achievement11;
	public string achievement12;
	public string achievement13;
	public string achievement14;
	public string achievement15;

	public static bool once;

	void Awake ()
	{

	}
	// Use this for initialization
	void Start ()
	{
		//PlayGamesPlatform.Activate ();
		if (!once) {
			once = true;
			Social.localUser.Authenticate ((bool success) => {
				if (success) {
					Debug.Log ("Login Success");
				} else {
					Debug.Log ("Login Failed");
				}
			});
		}
	}
	
	//Google Play Game Services Setup

	public void postScore (int score)
	{
		if (Social.localUser.authenticated) {
			Social.ReportScore (score, leaderboard, (bool success) => {
				if (success)
					Debug.Log ("Score post Success");
				else
					Debug.Log ("Score post Failed");
			});
		}
	}

	public void showLeaderboard ()
	{
		Debug.Log ("learderboard");
		//PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderboard);

	}

	public void showAchievement ()
	{
		Debug.Log ("Achievements");
		Social.ShowAchievementsUI ();
	}

	public void Update ()
	{
		revealAcheivements ();
	}

	public void revealAcheivements ()
	{
//		if (General.achievement1) {
//			Social.ReportProgress(achievement1,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("1st achievement Success");
//					else
//						Debug.Log ("1st achievement Failed");
//				});
//		}
//		if (General.achievement2) {
//			Social.ReportProgress(achievement2,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("2nd achievement Success");
//					else
//						Debug.Log ("2nd achievement Failed");
//				});
//		}
//		if (General.achievement3) {
//			Social.ReportProgress(achievement3,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("3rd achievement Success");
//					else
//						Debug.Log ("3rd achievement Failed");
//				});
//		}
//		if (General.achievement4) {
//			Social.ReportProgress(achievement4,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("4th achievement Success");
//					else
//						Debug.Log ("4th achievement Failed");
//				});
//		}
//		if (General.achievement5) {
//			Social.ReportProgress(achievement5,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement6) {
//			Social.ReportProgress(achievement6,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement7) {
//			Social.ReportProgress(achievement7,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement8) {
//			Social.ReportProgress(achievement8,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement9) {
//			Social.ReportProgress(achievement9,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement10) {
//			Social.ReportProgress(achievement10,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement11) {
//			Social.ReportProgress(achievement11,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement12) {
//			Social.ReportProgress(achievement12,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement13) {
//			Social.ReportProgress(achievement13,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement14) {
//			Social.ReportProgress(achievement14,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
//		if (General.achievement15) {
//			Social.ReportProgress(achievement15,100f, (bool success) => 
//				{
//					if (success)
//						Debug.Log ("5th achievement Success");
//					else
//						Debug.Log ("5th achievement Failed");
//				});
//		}
	}
}
