using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Interface:
//	show
//	hide
//	moveUp
//	moveDown
//	getValue

public class Menu_SquadController : MonoBehaviour, Menu_Display_Interface
{
	public GameObject tableObj;
	private Menu_ScrollViewController tableScript;

	Menu_StringString_Data[] d = new Menu_StringString_Data[3];

	void Awake()
	{
		tableScript = tableObj.GetComponent<Menu_ScrollViewController> ();

		d [0].string1 = "BOY A";
		d [0].string2 = "Health: 250/450 | Experience: 100/500";

		d [1].string1 = "BOY B";
		d [1].string2 = "Health: 270/450 | Experience: 240/500";

		d [2].string1 = "GIRL A";
		d [2].string2 = "Health: 20/100 | Experience: 57/500";
	}

	// Use this for initialization
	void Start () {
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
