using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_MenuController : MonoBehaviour
{
	public GameObject headerObj;
	public GameObject footerObj;
	public GameObject displayObj;
	public GameObject sidebarObj;

	public GameObject squadDisplayObj;
	public GameObject inventoryDisplayObj;

	private Menu_HeaderViewController headerScript;
	private Menu_FooterViewController footerScript;
	private Menu_Sidebar_Driver sidebarScript;
	private Menu_SquadController squadScript;
	private Menu_InventoryController inventoryScript;

	public enum MenuState{NONE, SIDEBAR, SQUAD, INVENTORY};
	public MenuState state = MenuState.NONE;


	// Use this for initialization
	void Start ()
	{
		headerScript = headerObj.GetComponent<Menu_HeaderViewController> ();
		footerScript = footerObj.GetComponent<Menu_FooterViewController> ();
		sidebarScript = this.GetComponent<Menu_Sidebar_Driver> ();
		squadScript = squadDisplayObj.GetComponent<Menu_SquadController> ();
		inventoryScript = inventoryDisplayObj.GetComponent<Menu_InventoryController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state == MenuState.NONE) {
			if (Input.GetKeyDown (KeyCode.Backspace)) {
				// Change State to Menu
				// Make Menu Components Active and showing
				this.show();
				state = MenuState.SIDEBAR;
				Menu_String_Data[] d = new Menu_String_Data[2];
				d[0].string1 = "Squad";
				d[1].string1 = "Inventory";
				sidebarScript.setSidebarContent (d);
				sidebarScript.show ();
			}
		} else {
			if (Input.GetKeyDown (KeyCode.Backspace)) {
				switch (state) {
				case MenuState.SIDEBAR:
					// Change State to None
					// Make Menu Components inactive and hiding
					this.hide();
					state = MenuState.NONE;
					break;
				case MenuState.SQUAD:
					squadScript.hide ();
					squadDisplayObj.SetActive (false);
					displayObj.SetActive (false);
					state = MenuState.SIDEBAR;
					break;
				case MenuState.INVENTORY:
					inventoryScript.hide ();
					inventoryDisplayObj.SetActive (false);
					displayObj.SetActive (false);
					state = MenuState.SIDEBAR;
					break;
				}
			}

			if (Input.GetKeyDown (KeyCode.W)) {
				switch (state) {
				case MenuState.SIDEBAR:
					sidebarScript.moveUp ();
					break;
				case MenuState.SQUAD:
					squadScript.moveUp ();
					break;
				case MenuState.INVENTORY:
					inventoryScript.moveUp ();
					break;
				}
			}

			if (Input.GetKeyDown (KeyCode.S)) {
				switch (state) {
				case MenuState.SIDEBAR:
					sidebarScript.moveDown ();
					break;
				case MenuState.SQUAD:
					squadScript.moveDown ();
					break;
				case MenuState.INVENTORY:
					inventoryScript.moveDown ();
					break;
				}
			}
		
			if (Input.GetKeyDown (KeyCode.Return)) {
				Debug.Log ("Enter Pressed");

				switch (state) {
				case MenuState.SIDEBAR:
					int result = sidebarScript.getValue ();

					Debug.Log (result);
					if (result == 0) {
						displayObj.SetActive (true);
						squadDisplayObj.SetActive (true);
						squadScript.show ();
						state = MenuState.SQUAD;
					} else {
						displayObj.SetActive (true);
						inventoryDisplayObj.SetActive (true);
						inventoryScript.show ();
						state = MenuState.INVENTORY;
					}
					break;
				case MenuState.SQUAD:
					break;
				case MenuState.INVENTORY:
					break;
				}
			}
		}
	}

	public void show()
	{
		headerObj.SetActive (true);
		footerObj.SetActive (true);
		sidebarObj.SetActive (true);
		displayObj.SetActive (true);
	}

	public void hide()
	{
		headerObj.SetActive (false);
		footerObj.SetActive (false);
		sidebarObj.SetActive (false);
		displayObj.SetActive (false);
	}


}
