using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
	public GameObject faderObject;
	private RawImage faderImage;

	private float alphaValue;
	public float AlphaValue {
		get {
			return alphaValue;
		}
		set {
			if (value > 255)
				alphaValue = 255;
			else if (value < 0)
				alphaValue = 0;
			else
				alphaValue = value;
		}
	}

	void Awake ()
	{
		faderImage = faderObject.GetComponent<RawImage> ();
		AlphaValue = 255f;
		faderImage.color = new Color (0,0,0,0);
	}

	// Use this for initialization
	void Start ()
	{
		// fadeIn (3.0f);
		// fadeOut (5.0f);
	}

	void Update()
	{
		faderImage.color = new Color (0, 0, 0, AlphaValue / 255f);
	}

	public void fadeIn(float dur)
	{
		StopCoroutine ("fadeInCoroutine");
		StopCoroutine ("fadeOutCoroutine");
		AlphaValue = 255f;
		StartCoroutine ("fadeInCoroutine", dur);
	}

	public void fadeOut(float dur)
	{
		StopCoroutine ("fadeInCoroutine");
		StopCoroutine ("fadeOutCoroutine");
		AlphaValue = 0f;
		StartCoroutine ("fadeOutCoroutine", dur);
	}

	private IEnumerator fadeInCoroutine(float dur)
	{
		float timeStart = Time.time;
		float timeEnd = timeStart + dur;

		Debug.Log ("Start fading in...");
		while (Time.time <= timeEnd) {
			float progress = (Time.time - timeStart) / dur; // Value between 0 and 1
			AlphaValue = 255.0f * (1.0f-progress);
			yield return new WaitForSeconds (0.01f);
		}

		AlphaValue = 0;
		Debug.Log ("Done fading in...");
		yield return new WaitForSeconds (0.05f);
	}

	private IEnumerator fadeOutCoroutine(float dur)
	{
		float timeStart = Time.time;
		float timeEnd = timeStart + dur;

		Debug.Log ("Start fading out...");
		while (Time.time <= timeEnd) {
			float progress = (Time.time - timeStart) / dur; // Value between 0 and 1
			AlphaValue = 255.0f * (progress);
			yield return new WaitForSeconds (0.01f);
		}

		AlphaValue = 255;
		Debug.Log ("Done fading in...");
		yield return new WaitForSeconds (0.05f);
	}
}
