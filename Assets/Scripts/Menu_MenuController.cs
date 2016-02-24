using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Interface:
// public void setBreadcrumbs(string tempData)
// public void setAreaName(string tempData)
// public void setAreaImage(Sprite tempData)
// public void setLevel(string tempData)
// public void setRAM(string tempData)
// public void setTime(string tempData)
// public void setInstruction(string tempData1, string tempData2)

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

	public enum MenuState{HIDDEN, VISIBLE};
	public enum FocusState{NONE, SIDEBAR, DISPLAY};
	public enum DisplayState{NONE, SQUADDASHBOARD, BELTDASHBOARD, INVENTORYDASHBOARD, CRAFTINGDASHBOARD, 
		MAPDASHBOARD, QUESTDASHBOARD, GAMEDASHBOARD, SQUAD, INVENTORY};

	public MenuState menuState = MenuState.HIDDEN;
	public FocusState focusState = FocusState.NONE;
	public DisplayState displayState = DisplayState.NONE;

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
		if (menuState == MenuState.HIDDEN) {
			// Backspace when menu is hidden... 
			if (Input.GetKeyDown (KeyCode.Backspace)) {
				this.show();	// show menu, change menu state to visible
				showDashboardSidebar();	// set sidebar content, set focus state to sidebar
				focusState = FocusState.SIDEBAR;
				changeDisplay (DisplayState.SQUADDASHBOARD);	// display squad dashboard
			}

		} else {
			if (focusState == FocusState.NONE) {
				Debug.Log ("WARNING, menu is showing, but there is no focus on sidebar or display");
			} else if (focusState == FocusState.SIDEBAR) {
				if (Input.GetKeyDown (KeyCode.W)) {
					switch (displayState) {
					case DisplayState.SQUADDASHBOARD:
						break;
					case DisplayState.BELTDASHBOARD:
						changeDisplay (DisplayState.SQUADDASHBOARD);
						break;
					case DisplayState.INVENTORYDASHBOARD:
						changeDisplay (DisplayState.BELTDASHBOARD);
						break;
					case DisplayState.CRAFTINGDASHBOARD:
						changeDisplay (DisplayState.INVENTORYDASHBOARD);
						break;
					case DisplayState.MAPDASHBOARD:
						changeDisplay (DisplayState.CRAFTINGDASHBOARD);
						break;
					case DisplayState.QUESTDASHBOARD:
						changeDisplay (DisplayState.MAPDASHBOARD);
						break;
					case DisplayState.GAMEDASHBOARD:
						changeDisplay (DisplayState.QUESTDASHBOARD);
						break;
					default:
						break;
					}

					sidebarScript.moveUp ();
				}
				if (Input.GetKeyDown (KeyCode.S)) {
					switch (displayState) {
					case DisplayState.SQUADDASHBOARD:
						changeDisplay (DisplayState.BELTDASHBOARD);
						break;
					case DisplayState.BELTDASHBOARD:
						changeDisplay (DisplayState.INVENTORYDASHBOARD);
						break;
					case DisplayState.INVENTORYDASHBOARD:
						changeDisplay (DisplayState.CRAFTINGDASHBOARD);
						break;
					case DisplayState.CRAFTINGDASHBOARD:
						changeDisplay (DisplayState.MAPDASHBOARD);
						break;
					case DisplayState.MAPDASHBOARD:
						changeDisplay (DisplayState.QUESTDASHBOARD);
						break;
					case DisplayState.QUESTDASHBOARD:
						changeDisplay (DisplayState.GAMEDASHBOARD);
						break;
					case DisplayState.GAMEDASHBOARD:
						break;
					default:
						break;
					}

					sidebarScript.moveDown ();
				}
				if (Input.GetKeyDown (KeyCode.Backspace)) {
					if (displayState == DisplayState.SQUADDASHBOARD || displayState == DisplayState.BELTDASHBOARD || displayState == DisplayState.INVENTORYDASHBOARD || displayState == DisplayState.CRAFTINGDASHBOARD || displayState == DisplayState.MAPDASHBOARD || displayState == DisplayState.QUESTDASHBOARD || displayState == DisplayState.GAMEDASHBOARD) {
						changeDisplay (DisplayState.NONE);
						focusState = FocusState.NONE;
						hide ();
					}
				}
				if (Input.GetKeyDown (KeyCode.Return)) {
					switch (displayState) {
					case DisplayState.SQUADDASHBOARD:
						changeDisplay (DisplayState.SQUAD);
						focusState = FocusState.DISPLAY;
						showSquadSidebar ();
						break;
					case DisplayState.BELTDASHBOARD:
						changeDisplay (DisplayState.SQUAD);
						focusState = FocusState.DISPLAY;
						showSquadSidebar ();
						break;
					case DisplayState.INVENTORYDASHBOARD:
						changeDisplay (DisplayState.INVENTORY);
						focusState = FocusState.DISPLAY;
						showInventorySidebar ();
						break;
					case DisplayState.CRAFTINGDASHBOARD:
						changeDisplay (DisplayState.INVENTORY);
						focusState = FocusState.DISPLAY;
						showInventorySidebar ();
						break;
					case DisplayState.MAPDASHBOARD:
						changeDisplay (DisplayState.INVENTORY);
						focusState = FocusState.DISPLAY;
						showInventorySidebar ();
						break;
					case DisplayState.QUESTDASHBOARD:
						changeDisplay (DisplayState.INVENTORY);
						focusState = FocusState.DISPLAY;
						showInventorySidebar ();
						break;
					case DisplayState.GAMEDASHBOARD:
						changeDisplay (DisplayState.INVENTORY);
						focusState = FocusState.DISPLAY;
						showInventorySidebar ();
						break;
					default:
						break;
					}
				}
			} else if (focusState == FocusState.DISPLAY) {
				if (Input.GetKeyDown (KeyCode.W)) {
					switch (displayState) {
					case DisplayState.SQUAD:
						squadScript.moveUp ();
						break;
					case DisplayState.INVENTORY:
						inventoryScript.moveUp ();
						break;
					default:
						break;
					}
				}
				if (Input.GetKeyDown (KeyCode.S)) {
					switch (displayState) {
					case DisplayState.SQUAD:
						squadScript.moveDown ();
						break;
					case DisplayState.INVENTORY:
						inventoryScript.moveDown ();
						break;
					default:
						break;
					}
				}
				if (Input.GetKeyDown (KeyCode.Backspace)) {
					switch (displayState) {
					case DisplayState.SQUAD:
						changeDisplay (DisplayState.SQUADDASHBOARD);
						showDashboardSidebar ();
						focusState = FocusState.SIDEBAR;
						break;
					case DisplayState.INVENTORY:
						changeDisplay (DisplayState.SQUADDASHBOARD);
						showDashboardSidebar ();
						focusState = FocusState.SIDEBAR;
						break;
					default:
						break;
					}
				}
				if (Input.GetKeyDown (KeyCode.Return)) {
					switch (displayState) {
					case DisplayState.SQUAD:
						Debug.Log (squadScript.getValue ());
						break;
					case DisplayState.INVENTORY:
						Debug.Log (inventoryScript.getValue ());
						break;
					default:
						break;
					}
				}
			}
		}
	}

	private void show()
	{
		headerObj.SetActive (true);
		footerObj.SetActive (true);
		sidebarObj.SetActive (true);
		displayObj.SetActive (true);

		menuState = MenuState.VISIBLE;
	}

	private void hide()
	{
		headerObj.SetActive (false);
		footerObj.SetActive (false);
		sidebarObj.SetActive (false);
		displayObj.SetActive (false);

		menuState = MenuState.HIDDEN;
	}

	private void changeDisplay(DisplayState tempState)
	{
		if (displayObj.activeInHierarchy) {
			switch (tempState) {
			case DisplayState.NONE:
				hideAllDisplays ();
				displayObj.SetActive (false);
				break;
			case DisplayState.SQUADDASHBOARD:
				hideAllDisplays ();
				squadDisplayObj.SetActive (true);
				squadScript.show ();
				break;
			case DisplayState.BELTDASHBOARD:
				hideAllDisplays ();
				squadDisplayObj.SetActive (true);
				squadScript.show ();
				break;
			case DisplayState.INVENTORYDASHBOARD:
				hideAllDisplays ();
				inventoryDisplayObj.SetActive (true);
				inventoryScript.show ();
				break;
			case DisplayState.CRAFTINGDASHBOARD:
				hideAllDisplays ();
				inventoryDisplayObj.SetActive (true);
				inventoryScript.show ();
				break;
			case DisplayState.MAPDASHBOARD:
				hideAllDisplays ();
				inventoryDisplayObj.SetActive (true);
				inventoryScript.show ();
				break;
			case DisplayState.QUESTDASHBOARD:
				hideAllDisplays ();
				inventoryDisplayObj.SetActive (true);
				inventoryScript.show ();
				break;
			case DisplayState.GAMEDASHBOARD:
				hideAllDisplays ();
				inventoryDisplayObj.SetActive (true);
				inventoryScript.show ();
				break;
			case DisplayState.SQUAD:
				hideAllDisplays ();
				squadDisplayObj.SetActive (true);
				squadScript.show ();
				break;
			case DisplayState.INVENTORY:
				hideAllDisplays ();
				inventoryDisplayObj.SetActive (true);
				inventoryScript.show ();
				break;
			default:
				Debug.Log ("Invalid display state to change display...");
				break;
			}

			displayState = tempState;

		} else {
			Debug.Log ("Display Object is already inactive, cannot change display contents...");
		}
	}

	private void hideAllDisplays()
	{
		if (displayObj.activeInHierarchy) {
			squadDisplayObj.SetActive (false);
			inventoryDisplayObj.SetActive (false);
		} else {
			Debug.Log ("Display Object is already inactive, cannot hide display contents...");
		}
	}

	private void showDashboardSidebar()
	{
		// set sidebar content, set focus state to sidebar
		Menu_String_Data[] d = new Menu_String_Data[7];
		d[0].string1 = "Squad";
		d[1].string1 = "Belt";
		d[2].string1 = "Inventory";
		d[3].string1 = "Crafting";
		d[4].string1 = "Map";
		d[5].string1 = "Quest";
		d[6].string1 = "Quit Game";

		sidebarScript.setSidebarContent (d);
		sidebarScript.show ();
	}

	private void showSquadSidebar()
	{
		// set sidebar content, set focus state to sidebar
		Menu_String_Data[] d = new Menu_String_Data[1];
		d[0].string1 = "Squad Statistics";

		sidebarScript.setSidebarContent (d);
		sidebarScript.show ();
	}

	private void showInventorySidebar()
	{
		// set sidebar content, set focus state to sidebar
		Menu_String_Data[] d = new Menu_String_Data[1];
		d[0].string1 = "Inventory";

		sidebarScript.setSidebarContent (d);
		sidebarScript.show ();
	}

	public void setBreadcrumbs(string tempData)
	{
		Menu_String_Data d = new Menu_String_Data ();
		d.string1 = tempData;

		headerScript.setBreadcrumbs (d);
	}

	public void setAreaName(string tempData)
	{
		Menu_String_Data d = new Menu_String_Data ();
		d.string1 = tempData;

		headerScript.setAreaName (d);
	}

	public void setAreaImage(Sprite tempData)
	{
		headerScript.setAreaImage (tempData);
	}

	public void setLevel(string tempData)
	{
		Menu_String_Data d = new Menu_String_Data ();
		d.string1 = tempData;

		footerScript.setLevel (d);
	}

	public void setRAM(string tempData)
	{
		Menu_String_Data d = new Menu_String_Data ();
		d.string1 = tempData;

		footerScript.setRAM (d);
	}

	public void setTime(string tempData)
	{
		Menu_String_Data d = new Menu_String_Data ();
		d.string1 = tempData;

		footerScript.setTime (d);
	}

	public void setInstruction(string tempData1, string tempData2)
	{
		Menu_StringString_Data d = new Menu_StringString_Data ();
		d.string1 = tempData1;
		d.string2 = tempData2;

		footerScript.setInstruction (d);
	}
}
