using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Menu_Sidebar_Driver : MonoBehaviour
{
	Menu_StringStringSprite_Data[] testData = new Menu_StringStringSprite_Data[15];

	public Sprite spriteImage;
	public GameObject sidebarObj;
	private Menu_ScrollViewController sidebarController;

	// Use this for initialization
	void Start () {
		sidebarController = sidebarObj.GetComponent<Menu_ScrollViewController>();

		for (int i = 0; i < 15; i++) {
			testData [i] = new Menu_StringStringSprite_Data ();
			testData [i].string1 = i.ToString ();
			testData [i].string2 = i.ToString ();
			testData [i].sprite1 = spriteImage;
		}

		sidebarController.instantiateScrollView<Menu_StringStringSprite_Data> (testData);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
