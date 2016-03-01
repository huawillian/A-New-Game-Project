using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls the Support Panel on the HUD
// Interface:
//		updateCharacter(int) 0,3
//		updateCooldown(int)  > 0

public class HUD_Support : MonoBehaviour
{
	// Need reference to the Image and Text
	public GameObject supportImageObject;
	public GameObject supportCooldownObject;
	private Image image;
	private Text text;

	public Sprite supportCharacterOneSprite;
	public Sprite supportCharacterTwoSprite;
	public Sprite supportCharacterThreeSprite;
	public Sprite supportCharacterFourSprite;

	// Use this for initialization
	void Start () {
		image = supportImageObject.GetComponent<Image> ();
		text = supportCooldownObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateCharacter(int tempIndex) {
		if (tempIndex > 3 || tempIndex < 0) {
			Debug.Log ("Invalid assist character index: " + tempIndex);
			return;
		}

		switch (tempIndex) {
		case 0:
			image.sprite = supportCharacterOneSprite;
			break;
		case 1:
			image.sprite = supportCharacterTwoSprite;
			break;
		case 2:
			image.sprite = supportCharacterThreeSprite;
			break;
		case 3:
			image.sprite = supportCharacterFourSprite;
			break;
		default:
			break;
		}
	}

	public void updateCooldown(int tempCooldown) {
		if (tempCooldown < 0) {
			Debug.Log ("Invalid cooldown: " + tempCooldown);
			return;
		}

		if (tempCooldown == 0) {
			text.text = "READY!";
		} else {
			text.text = ": " + tempCooldown.ToString ();
		}
	}
}
