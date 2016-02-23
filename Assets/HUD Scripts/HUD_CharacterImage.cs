using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls the Character Image on the HUD
// Interface:
//		updateHealth(int)
//		updateMaxHealth(int)
//		startHurt()
//		switchCharacter(int) 0-2

public class HUD_CharacterImage : MonoBehaviour
{
	// Sprites need to be set
	public Sprite characterOneGoodSprite;
	public Sprite characterTwoGoodSprite;
	public Sprite characterThreeGoodSprite;
	public Sprite characterOneBadSprite;
	public Sprite characterTwoBadSprite;
	public Sprite characterThreeBadSprite;
	public Sprite characterOneHurtSprite;
	public Sprite characterTwoHurtSprite;
	public Sprite characterThreeHurtSprite;

	// Child element, Character Image
	public GameObject characterImageObject;

	// Used to update image based on hp and recently damaged
	private enum CharacterState{Good, Bad, Hurt};
	private CharacterState state = CharacterState.Good;

	// Used to update image based character currently being played
	private enum CharacterSelected {One, Two, Three};
	private CharacterSelected character = CharacterSelected.One;

	// Show hurt image for duration
	public float hurtDuration = 1.0f;

	// Used to stop updating character state to good or bad
	private bool hurtFlag = false;

	// Used to determine character state good or bad
	public int health = 100;
	public int maxHealth = 100;

	// Used to reference image via, image.sprite = 'value'
	private UnityEngine.UI.Image image;

	// Used to reference the red halo, appears when hp is low
	private Light halo;

	// Use this for initialization
	void Start ()
	{
		image = characterImageObject.GetComponent<UnityEngine.UI.Image> ();
		halo = characterImageObject.GetComponent<Light> ();
		StartCoroutine ("showHalo");
		StartCoroutine ("startHalo");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!hurtFlag)
		{
			updateCharacterStateGoodBad ();
		}

		switch (state) {
		case CharacterState.Good:
			if (character == CharacterSelected.One)
				image.sprite = characterOneGoodSprite;
			else if (character == CharacterSelected.Two)
				image.sprite = characterTwoGoodSprite;
			else if (character == CharacterSelected.Three)
				image.sprite = characterThreeGoodSprite;
			break;
		case CharacterState.Bad:
			if (character == CharacterSelected.One)
				image.sprite = characterOneBadSprite;
			else if (character == CharacterSelected.Two)
				image.sprite = characterTwoBadSprite;
			else if (character == CharacterSelected.Three)
				image.sprite = characterThreeBadSprite;
			break;
		case CharacterState.Hurt:
			if (character == CharacterSelected.One)
				image.sprite = characterOneHurtSprite;
			else if (character == CharacterSelected.Two)
				image.sprite = characterTwoHurtSprite;
			else if (character == CharacterSelected.Three)
				image.sprite = characterThreeHurtSprite;
			break;
		default:
			break;
		}
	}

	// Helper Methods
	private void updateCharacterStateGoodBad()
	{
		float healthpercentage = ((float) health) / ((float) maxHealth);

		// If health above 25%, then show good, else show bad image
		if (healthpercentage > 0.25) {
			state = CharacterState.Good;
		} else {
			state = CharacterState.Bad;
		}
	}

	private IEnumerator showHurt()
	{
		Debug.Log ("showing hurt image");
		hurtFlag = true;
		state = CharacterState.Hurt;
		yield return new WaitForSeconds (hurtDuration);
		updateCharacterStateGoodBad ();
		hurtFlag = false;
		Debug.Log ("done showing hurt image");
	}

	private IEnumerator showHalo()
	{
		while (true) {
			yield return new WaitForSeconds (1.0f);
			if (state == CharacterState.Bad) {
				halo.intensity = 8;
			} else {
				halo.intensity = 0;
			}
		}
	}

	private IEnumerator startHalo()
	{
		bool incrementing = true;
		halo.range = 20;

		do {
			if (incrementing)
				halo.range += 1;
			else
				halo.range -= 1;

			if (halo.range > 30)
				incrementing = false;

			if (halo.range < 20)
				incrementing = true;
			
			yield return new WaitForSeconds (0.1f);
		} while(true);

	}

	// Public Methods
	public void updateHealth (int tempHealth)
	{
		Debug.Log ("update HUD health to: " + tempHealth);
		health = tempHealth;
	}

	public void updateMaxHealth (int tempMaxHealth)
	{
		Debug.Log ("update HUD maxhealth to: " + tempMaxHealth);
		maxHealth = tempMaxHealth;
	}

	public void startHurt()
	{
		StartCoroutine ("showHurt");
	}

	public void switchCharacter(int characterIndex)
	{
		if (characterIndex > 2 || characterIndex < 0) {
			Debug.Log ("Invalid character Index: " + characterIndex);
			return;
		}

		Debug.Log ("switching hud character given indexes 0-2 to: " + characterIndex);

		switch (characterIndex) {
		case 0:
			character = CharacterSelected.One;
			break;
		case 1:
			character = CharacterSelected.Two;
			break;
		case 2:
			character = CharacterSelected.Three;
			break;
		default:
			break;
		}
	}


}
