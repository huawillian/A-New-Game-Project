using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
	public GameObject clipsObject;
	public Queue<GameObject> clipsQueue = new Queue<GameObject>();
	public bool loadNextScene;
	public string nextSceneName;
	public AudioClip soundFile;

	// Use this for initialization
	void Start ()
	{
		Transform[] clipTransforms = clipsObject.GetComponentsInChildren<Transform> ();

		foreach (Transform t in clipTransforms) {
			if (t.gameObject.GetComponent<ClipPlayer> () != null) {
				Debug.Log ("Enqueuing " + t.gameObject.name);
				t.gameObject.GetComponentInChildren<Camera> ().enabled = false;
				t.gameObject.GetComponentInChildren<AudioListener> ().enabled = false;
				clipsQueue.Enqueue (t.gameObject);
			}
		}

		this.GetComponent<AudioSource> ().clip = soundFile;
		this.GetComponent<AudioSource> ().Play ();
		StartCoroutine ("StartCinematic");
	}

	private IEnumerator StartCinematic()
	{
		Debug.Log ("Starting Cinematic...");

		while (clipsQueue.Count > 0) {
			GameObject clip = clipsQueue.Dequeue ();
			Debug.Log ("Playing " + clip.gameObject.name);

			clip.gameObject.GetComponentInChildren<Camera> ().enabled = true;

			clip.GetComponent<ClipPlayer> ().PlayClip ();
			this.GetComponent<Fader> ().fadeIn (clip.GetComponent<ClipPlayer> ().fadeInDuration);
			yield return new WaitForSeconds (clip.GetComponent<ClipPlayer> ().duration - clip.GetComponent<ClipPlayer> ().fadeOutDuration);
			this.GetComponent<Fader> ().fadeOut (clip.GetComponent<ClipPlayer> ().fadeOutDuration);
			yield return new WaitForSeconds (clip.GetComponent<ClipPlayer> ().fadeOutDuration);
			clip.GetComponent<ClipPlayer> ().StopClip ();

			clip.gameObject.GetComponentInChildren<Camera> ().enabled = false;
		}

		yield return new WaitForSeconds (0.05f);
		Debug.Log ("End of Cinematic");

		if (loadNextScene) {
			Debug.Log ("Loading Scene " + nextSceneName);
			yield return new WaitForSeconds (2.0f);
			SceneManager.LoadScene (nextSceneName);
		}

	}
}
