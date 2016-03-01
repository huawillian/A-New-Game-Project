using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Interface:
//	setSidebarContent(Menu_String_Data[])
//	show
//	hide
//	moveUp
//	moveDown
//	getValue

public class Menu_Sidebar_Driver : MonoBehaviour, Menu_Display_Interface
{
	Menu_String_Data[] testData = new Menu_String_Data[10];

	public GameObject sidebarObj;
	private Menu_ScrollViewController sidebarController;

	void Awake()
	{
		sidebarController = sidebarObj.GetComponent<Menu_ScrollViewController>();

		for (int i = 0; i < 10; i++) {
			testData [i] = new Menu_String_Data ();
			testData [i].string1 = i.ToString ();
		}
	}

	// Use this for initialization
	void Start () {
	}

	public void setSidebarContent(Menu_String_Data[] tempData)
	{
		testData = (Menu_String_Data[])tempData.Clone ();
	}
	
	public void show ()
	{
		sidebarController.instantiateScrollView <Menu_StringString_Data>(testData);
	}

	public void hide() 
	{
		sidebarController.clearContent ();
	}

	public void moveUp () {
		sidebarController.moveUp ();
	}

	public void moveDown() {
		sidebarController.moveDown ();
	}

	public void moveRight() {
		// Nothing for tables
	}

	public void moveLeft() {
		// Nothing for tables
	}

	public int getValue() {
		return sidebarController.getValue ();
	}
}
