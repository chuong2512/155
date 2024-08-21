using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingAds : MonoBehaviour
{
	public static int checkLoading = 0;

	// Use this for initialization
	void Start ()
	{

		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update ()
	{		
		StartCoroutine (LevelLoading ());				
	}

	IEnumerator LevelLoading ()
	{
		if (checkLoading == 0) {
			Handheld.StartActivityIndicator ();
			yield return new WaitForSeconds (5);
			Application.LoadLevel (1);
			checkLoading = 1;
		} else {
			Application.LoadLevel (1);
		}
	}
}
