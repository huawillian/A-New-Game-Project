using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Interface:
//	show
//	hide
//	moveUp
//	moveDown
//	getValue

public class Menu_InventoryController : MonoBehaviour, Menu_Display_Interface
{
	public GameObject tableObj;
	private Menu_ScrollViewController tableScript;

	public Sprite img1;
	public Sprite img2;
	public Sprite img3;

	Menu_SpriteStringString_Data[] d = new Menu_SpriteStringString_Data[6];

	void Awake()
	{
		tableScript = tableObj.GetComponent<Menu_ScrollViewController> ();

		d [0].string1 = "Pizza : Heals current player for 50 hp";
		d [0].string2 = "5";
		d [0].sprite1 = img1;

		d [1].string1 = "Candy : Heals current player for 30 hp and increases agility by 5 points";
		d [1].string2 = "1";
		d [1].sprite1 = img2;

		d [2].string1 = "Throwing Dart : Throws a dart forward and damages enemies hit for 30 hp";
		d [2].string2 = "16";
		d [2].sprite1 = img3;

		d [3].string1 = "Pizza : Heals current player for 50 hp";
		d [3].string2 = "5";
		d [3].sprite1 = img1;

		d [4].string1 = "Candy : Heals current player for 30 hp and increases agility by 5 points";
		d [4].string2 = "1";
		d [4].sprite1 = img2;

		d [5].string1 = "Throwing Dart : Throws a dart forward and damages enemies hit for 30 hp";
		d [5].string2 = "16";
		d [5].sprite1 = img3;
	}

	// Use this for initialization
	void Start ()
	{
		tableScript.instantiateScrollView <Menu_SpriteStringString_Data>(d);
	}
	
	public void show ()
	{
		tableScript.instantiateScrollView <Menu_StringString_Data>(d);
	}

	public void hide() 
	{
		tableScript.clearContent ();
	}

	public void moveUp () {
		tableScript.moveUp ();
	}

	public void moveDown() {
		tableScript.moveDown ();
	}

	public void moveRight() {
		// Nothing for tables
	}

	public void moveLeft() {
		// Nothing for tables
	}

	public int getValue() {
		return tableScript.getValue ();
	}
}
