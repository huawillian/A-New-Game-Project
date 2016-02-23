using UnityEngine;
using System.Collections;

public class ClipPlayer : MonoBehaviour
{
	Animator[] animators;
	public float duration;
	public float fadeInDuration;
	public float fadeOutDuration;

	// Use this for initialization
	void Start ()
	{
		animators = this.gameObject.GetComponentsInChildren<Animator> ();
		foreach (Animator anim in animators) {
			anim.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void PlayClip()
	{
		foreach (Animator anim in animators) {
			anim.enabled = true;
		}
	}

	public void StopClip()
	{
		foreach (Animator anim in animators) {
			anim.enabled = false;
		}
	}
}
