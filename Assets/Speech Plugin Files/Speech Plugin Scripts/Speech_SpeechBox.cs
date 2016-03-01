using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls Speech Box for the Speech Plugin
//	Interface:
//		setTextAndImages(string, Sprite, Sprite)
//		showSpeechBox()
//		hideSpeechBox()
//		startText()
//
// 	Use e.g.
//		showSpeechBox ();
//		setTextAndImages ("An example text for the speech box plugin. La, la, la. My name is Willian.", image1, image2);
//		startText ();
//		Wait 3 seconds...
//		hideSpeechBox();

public class Speech_SpeechBox : MonoBehaviour, ISpeechComponents<SpeechBoxData>
{
	public GameObject textObj;
	public GameObject imageObj;
	public GameObject backgroundObj;

	private Text textRef;
	private Image imageRef;

	public Sprite image1;
	public Sprite image2;
	public string text = "An example text for the speech box plugin. La, la, la. My name is Willian.";

	public enum SpeechBoxState{HIDING, SHOWING, READY, TYPING, DONE};
	SpeechBoxState state = SpeechBoxState.HIDING;

	public enum SpeechBoxImageState{NONE, ONE, TWO};
	SpeechBoxImageState imageState = SpeechBoxImageState.NONE;

	public float imageSwitchTime = 1.0f;
	public float textFillTime = 0.05f;

	// Use this for initialization
	void Start ()
	{
		textRef = textObj.GetComponent<Text> ();
		imageRef = imageObj.GetComponent<Image> ();
		StartCoroutine ("switchImageThread");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (imageState == SpeechBoxImageState.ONE)
			imageRef.sprite = image1;
		if (imageState == SpeechBoxImageState.TWO)
			imageRef.sprite = image2;
	}

	public void setContent(SpeechBoxData data)
	{
		text = data.text;
		image1 = data.image1;
		image2 = data.image2;
		state = SpeechBoxState.READY;
		imageState = SpeechBoxImageState.ONE;
	}

	public void setPosition(int x, int y)
	{
	}

	public void enableBackButton()
	{
	}

	public void show()
	{
		textObj.SetActive (true);
		imageObj.SetActive (true);
		backgroundObj.SetActive (true);
		state = SpeechBoxState.SHOWING;
	}

	public void hide()
	{
		if (state == SpeechBoxState.TYPING)
			Debug.Log ("Warning, hiding speechbox during typing");

		textObj.SetActive (false);
		imageObj.SetActive (false);
		backgroundObj.SetActive (false);
		state = SpeechBoxState.HIDING;
	}

	public void selectUp()
	{
	}

	public void selectDown()
	{
	}

	public void selectLeft()
	{
	}

	public void selectRight()
	{
	}

	public int getValue()
	{
		// Show whole text is not finished typing and return -1
		if (state == SpeechBoxState.READY || state == SpeechBoxState.TYPING) {
			StopCoroutine ("startTextThread");
			textRef.text = text;
			state = SpeechBoxState.DONE;
			return -1;
		} else if (state == SpeechBoxState.DONE) {
			// If finished, then return 0
			return 0;
		} else {
			return -1;
		}
	}

	public void startText()
	{
		StopCoroutine ("startTextThread");
		StartCoroutine ("startTextThread");
	}

	private IEnumerator startTextThread()
	{
		// Start Animating the text
		if (state == SpeechBoxState.READY) {
			state = SpeechBoxState.TYPING;

			int numChars = text.Length;
			int curChars = 0;

			while (curChars <= numChars) {
				textRef.text = text.Substring (0, curChars);
				curChars++;
				yield return new WaitForSeconds (textFillTime);
			}

			state = SpeechBoxState.DONE;
			// Then call an event to the Speech Plugin Manager telling it the speechbox has finished typing
		} else {
			Debug.Log ("Warning, attempt to call startingTextThread for speechbox before entering ready state.");
		}


		yield return new WaitForSeconds (0.1f);
	}

	private IEnumerator switchImageThread()
	{
		do {
			yield return new WaitForSeconds (imageSwitchTime);

			if(imageState == SpeechBoxImageState.NONE || state == SpeechBoxState.HIDING)
				continue;
			else {
				if(imageState == SpeechBoxImageState.ONE)
					imageState = SpeechBoxImageState.TWO;
				else
					imageState = SpeechBoxImageState.ONE;
			}
		} while(true);
	}
}
