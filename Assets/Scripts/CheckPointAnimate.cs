using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointAnimate : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		//StartCoroutine (AnimateFunction ());
	}
	
	// Update is called once per frame
	void Update ()
	{

		transform.Rotate (0, 0, 100 * Time.deltaTime);
	}

	IEnumerator AnimateFunction ()
	{
		while (true) {

			transform.Translate (0, 2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, 2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, 2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, 2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, 2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, 2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, 2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, -2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, -2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, -2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, -2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, -2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, -2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
			transform.Translate (0, -2 * Time.deltaTime, 0);
			yield return new WaitForSeconds (0.01f);
		}
	}
}
