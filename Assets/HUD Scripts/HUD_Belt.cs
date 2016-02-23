using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls the Character HP Bar on the HUD
// Interface:
//		updateSelect(int) 0-4
//		updateQuantity(int, int) 0-4, > 0
//		updateItem(int, Sprite) 0-4, Sprite pass by reference
//		resetFadeTimer()

public class HUD_Belt : MonoBehaviour
{
	// Need reference to Belt Objects, Select, and Backgrounds
	public GameObject beltOneObject;
	public GameObject beltTwoObject;
	public GameObject beltThreeObject;
	public GameObject beltFourObject;
	public GameObject beltFiveObject;
	public GameObject beltSelectObject;
	public GameObject beltBackgroundObject;
	public GameObject beltTitleObject;

	public Sprite noneEquippedSprite;

	public float activeDuration = 3.0f;
	public float timeActive = 0.0f;

	public enum BeltState{Visible, Hidden};
	public BeltState state = BeltState.Visible;

	public enum BeltSelect{One, Two, Three, Four, Five};
	public BeltSelect selected = BeltSelect.Three;

	// Use this for initialization
	void Start ()
	{
		resetFadeTimer ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((timeActive + activeDuration) < Time.time) {
			if (state == BeltState.Visible)
				hideBelt ();

			state = BeltState.Hidden;
		} else {
			if (state == BeltState.Hidden)
				showBelt ();

			state = BeltState.Visible;
		}
	}

	public void updateItem(int tempIndex, Sprite tempSprite)
	{
		if (tempIndex > 4 || tempIndex < 0) {
			Debug.Log ("Invalid belt index: " + tempIndex);
			return;
		}

		switch (tempIndex) {
		case 0:
			beltOneObject.GetComponentInChildren<Image> ().sprite = tempSprite;
			break;
		case 1:
			beltTwoObject.GetComponentInChildren<Image> ().sprite = tempSprite;
			break;
		case 2:
			beltThreeObject.GetComponentInChildren<Image> ().sprite = tempSprite;
			break;
		case 3:
			beltFourObject.GetComponentInChildren<Image> ().sprite = tempSprite;
			break;
		case 4:
			beltFiveObject.GetComponentInChildren<Image> ().sprite = tempSprite;
			break;
		default:
			break;
		}
	}

	public void updateQuantity(int tempIndex, int tempQuantity)
	{
		if (tempIndex > 4 || tempIndex < 0) {
			Debug.Log ("Invalid belt index: " + tempIndex);
			return;
		}

		if (tempQuantity < 0) {
			Debug.Log ("Invalid belt quantity: " + tempQuantity);
			return;
		}

		switch (tempIndex) {
		case 0:
			beltOneObject.GetComponentInChildren<Text> ().text = "x " + tempQuantity.ToString() + " ";
			break;
		case 1:
			beltTwoObject.GetComponentInChildren<Text> ().text = "x " + tempQuantity.ToString() + " ";
			break;
		case 2:
			beltThreeObject.GetComponentInChildren<Text> ().text = "x " + tempQuantity.ToString() + " ";
			break;
		case 3:
			beltFourObject.GetComponentInChildren<Text> ().text = "x " + tempQuantity.ToString() + " ";
			break;
		case 4:
			beltFiveObject.GetComponentInChildren<Text> ().text = "x " + tempQuantity.ToString() + " ";
			break;
		default:
			break;
		}
	}
		
	public void updateSelect(int tempIndex)
	{
		if (tempIndex > 4 || tempIndex < 0) {
			Debug.Log ("Invalid belt index: " + tempIndex);
			return;
		}

		switch (tempIndex) {
		case 0:
			selected = BeltSelect.One;
			beltSelectObject.GetComponent<RectTransform> ().localPosition = new Vector3 (-200, -20, 0);
			break;
		case 1:
			selected = BeltSelect.Two;
			beltSelectObject.GetComponent<RectTransform> ().localPosition = new Vector3 (-100, -20, 0);
			break;
		case 2:
			selected = BeltSelect.Three;
			beltSelectObject.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -20, 0);
			break;
		case 3:
			selected = BeltSelect.Four;
			beltSelectObject.GetComponent<RectTransform> ().localPosition = new Vector3 (100, -20, 0);
			break;
		case 4:
			selected = BeltSelect.Five;
			beltSelectObject.GetComponent<RectTransform> ().localPosition = new Vector3 (200, -20, 0);
			break;
		default:
			break;
		}

		resetFadeTimer ();
	}

	public void resetFadeTimer()
	{
		timeActive = Time.time;
	}

	private void hideBelt()
	{
		beltTitleObject.GetComponent<Text> ().color = new Color (255,255,255,0);
		beltBackgroundObject.GetComponent<RawImage> ().color = new Color32 (20,20,20,0);

		GameObject[] beltObjects = { beltOneObject, beltTwoObject, beltThreeObject, beltFourObject, beltFiveObject };

		foreach (GameObject o in beltObjects) {
			o.GetComponentInChildren<Image> ().color = new Color (255,255,255,0);
			o.GetComponentInChildren<Text> ().color = new Color (255, 255, 255, 0);
		}

		switch (selected) {
		case BeltSelect.One:
			beltOneObject.GetComponentInChildren<Image> ().color = new Color (255,255,255,255);
			beltOneObject.GetComponentInChildren<Text> ().color = new Color (255,255,255,255);
			break;
		case BeltSelect.Two:
			beltTwoObject.GetComponentInChildren<Image> ().color = new Color (255,255,255,255);
			beltTwoObject.GetComponentInChildren<Text> ().color = new Color (255,255,255,255);
			break;
		case BeltSelect.Three:
			beltThreeObject.GetComponentInChildren<Image> ().color = new Color (255,255,255,255);
			beltThreeObject.GetComponentInChildren<Text> ().color = new Color (255,255,255,255);
			break;
		case BeltSelect.Four:
			beltFourObject.GetComponentInChildren<Image> ().color = new Color (255,255,255,255);
			beltFourObject.GetComponentInChildren<Text> ().color = new Color (255,255,255,255);
			break;
		case BeltSelect.Five:
			beltFiveObject.GetComponentInChildren<Image> ().color = new Color (255,255,255,255);
			beltFiveObject.GetComponentInChildren<Text> ().color = new Color (255,255,255,255);
			break;
		default:
			break;
		}
	}

	private void showBelt()
	{
		beltTitleObject.GetComponent<Text> ().color = new Color (255,255,255,255);
		beltBackgroundObject.GetComponent<RawImage> ().color = new Color32 (20,20,20,255);

		GameObject[] beltObjects = { beltOneObject, beltTwoObject, beltThreeObject, beltFourObject, beltFiveObject };

		foreach (GameObject o in beltObjects) {
			o.GetComponentInChildren<Image> ().color = new Color (255,255,255,255);
			o.GetComponentInChildren<Text> ().color = new Color (255, 255, 255, 255);
		}
	}
}
