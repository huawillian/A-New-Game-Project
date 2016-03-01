using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Control Panel for the HUD Plugin
// Used to test the various components

public class HUD_ControlPanel : MonoBehaviour
{
	public GameObject charObj;
	public GameObject hpObj;
	public GameObject rageObj;
	public GameObject supObj;
	public GameObject beltObj;

	private HUD_CharacterImage charScript;
	private HUD_CharacterHP hpScript;
	private HUD_CharacterRage rageScript;
	private HUD_Support supScript;
	private HUD_Belt beltScript;

	// Use this for initialization
	void Start () 
	{
		charScript = charObj.GetComponent<HUD_CharacterImage> ();
		hpScript = hpObj.GetComponent<HUD_CharacterHP> ();
		rageScript = rageObj.GetComponent<HUD_CharacterRage> ();
		supScript = supObj.GetComponent<HUD_Support> ();
		beltScript = beltObj.GetComponent<HUD_Belt> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void switchCharacter(int index)
	{
		charScript.switchCharacter (index);
	}

	public void damagePlayer(int num)
	{
		int health = hpScript.health - num;
		charScript.updateHealth (health);
		hpScript.updateHealth (health);
		charScript.startHurt ();
	}

	public void healPlayer(int num)
	{
		int health = hpScript.health + num;
		charScript.updateHealth (health);
		hpScript.updateHealth (health);
	}

	public void setMaxHealth(int num)
	{
		hpScript.updateMaxHealth (num);
		charScript.updateMaxHealth (num);
	}

	public void addRage(int num)
	{
		rageScript.updateRage (rageScript.rage + num);
	}

	public void decreaseRage(int num)
	{
		rageScript.updateRage (rageScript.rage - num);
	}

	public void setMaxRage(int num)
	{
		rageScript.updateMaxRage (num);
	}

	public void setSupportCharacter(int num)
	{
		supScript.updateCharacter (num);
	}

	public void setCooldown(int num)
	{
		supScript.updateCooldown (num);
	}

	public void moveLeft()
	{
		beltScript.updateSelect (0);
	}

	public void moveRight()
	{
		beltScript.updateSelect (4);
	}

	public void useItem()
	{
		beltScript.updateQuantity (3, 10);
	}

	public void discardItem()
	{
		beltScript.updateQuantity (3, 0);
	}
}
