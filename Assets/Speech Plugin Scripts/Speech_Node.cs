using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls the Speech Plugin Componenets directly
// To be used with a speech manager
// Interface:
//		Instantiate Node (set component active and set content)
//		Show Node
//		Hide Node
// 		Move Left
//		Move Right
//		Move Up
//		Move Down
// 		Return Index Selected
//		Press Enter
// How to Use:
//		instantiate*(*)
//		startNode();
//		Enter
//		Select Up, Left, Down, Right
//		Enter
//		hideNode();

public class Speech_Node : MonoBehaviour
{
	// Reference to the components
	public GameObject speechBoxObj;
	public GameObject selectTwoObj;
	public GameObject selectListObj;
	public GameObject selectTableObj;

	private Speech_SpeechBox speechBoxScript;
	private Speech_SelectTwo selectTwoScript;
	private Speech_SelectList selectListScript;
	private Speech_SelectTable selectTableScript;

	public enum SpeechNodeState{HIDDEN, TYPING, WAITING, DONE};
	private SpeechNodeState state = SpeechNodeState.HIDDEN;

	public enum SpeechNodeType{BOX, TWO, LIST, TABLE};
	private SpeechNodeType type = SpeechNodeType.BOX;

	private bool backButtonEnabled = false;
	private Vector2 pos;

	private SpeechBoxData boxData;
	private SelectTwoData twoData;
	private SelectListData listData;
	private SelectTableData tableData;

	// Use this for initialization
	void Start ()
	{
		speechBoxScript = speechBoxObj.GetComponent<Speech_SpeechBox> ();
		selectTwoScript = selectTwoObj.GetComponent<Speech_SelectTwo> ();
		selectListScript = selectListObj.GetComponent<Speech_SelectList> ();
		selectTableScript = selectTableObj.GetComponent<Speech_SelectTable> ();
	}

	public void instantiateNodeTypeBox(SpeechBoxData tempBoxData)
	{
		type = SpeechNodeType.BOX;

		boxData = tempBoxData;
	}

	public void instantiateNodeTypeTwo(SpeechBoxData tempBoxData, SelectTwoData tempTwoData, Vector2 tempPosition, bool backButton)
	{
		type = SpeechNodeType.TWO;

		boxData = tempBoxData;

		backButtonEnabled = backButton;
		pos = tempPosition;

		twoData = tempTwoData;
	}

	public void instantiateNodeTypeList(SpeechBoxData tempBoxData, SelectListData tempListData, Vector2 tempPosition, bool backButton)
	{
		type = SpeechNodeType.LIST;

		boxData = tempBoxData;

		backButtonEnabled = backButton;
		pos = tempPosition;

		listData = tempListData;
	}

	public void instantiateNodeTypeTable(SpeechBoxData tempBoxData, SelectTableData tempTableData, Vector2 tempPosition, bool backButton)
	{
		type = SpeechNodeType.TABLE;

		boxData = tempBoxData;

		backButtonEnabled = backButton;
		pos = tempPosition;

		tableData = tempTableData;
	}
	
	public void startNode()
	{
		state = SpeechNodeState.TYPING;

		speechBoxScript.show ();
		speechBoxScript.setContent (boxData);
		speechBoxScript.startText ();
	}

	public void showSelectComponent()
	{
		switch (type) {
		case SpeechNodeType.BOX:
			break;
		case SpeechNodeType.TWO:
			selectTwoScript.show ();
			selectTwoScript.setContent (twoData);
			selectTwoScript.setPosition ((int)pos.x, (int)pos.y);
			if (backButtonEnabled)
				selectTwoScript.enableBackButton ();
			break;
		case SpeechNodeType.LIST:
			selectListScript.show ();
			selectListScript.setContent (listData);
			selectListScript.setPosition ((int)pos.x, (int)pos.y);
			if (backButtonEnabled)
				selectListScript.enableBackButton ();
			break;
		case SpeechNodeType.TABLE:
			selectTableScript.show ();
			selectTableScript.setContent (tableData);
			selectTableScript.setPosition ((int)pos.x, (int)pos.y);
			if (backButtonEnabled)
				selectTableScript.enableBackButton ();
			break;
		default: 
			break;
		}
	}

	public void hideNode()
	{
		state = SpeechNodeState.HIDDEN;

		speechBoxScript.hide ();
		selectTwoScript.hide ();
		selectListScript.hide ();
		selectTableScript.hide ();
	}

	public void selectLeft()
	{
		switch (type) {
		case SpeechNodeType.BOX:
			speechBoxScript.selectLeft ();
			break;
		case SpeechNodeType.TWO:
			selectTwoScript.selectLeft ();
			break;
		case SpeechNodeType.LIST:
			selectListScript.selectLeft ();
			break;
		case SpeechNodeType.TABLE:
			selectTableScript.selectLeft ();
			break;
		default: 
			break;
		}
	}

	public void selectRight()
	{
		switch (type) {
		case SpeechNodeType.BOX:
			speechBoxScript.selectRight ();
			break;
		case SpeechNodeType.TWO:
			selectTwoScript.selectRight ();
			break;
		case SpeechNodeType.LIST:
			selectListScript.selectRight ();
			break;
		case SpeechNodeType.TABLE:
			selectTableScript.selectRight ();
			break;
		default: 
			break;
		}
	}

	public void selectUp()
	{
		switch (type) {
		case SpeechNodeType.BOX:
			speechBoxScript.selectUp ();
			break;
		case SpeechNodeType.TWO:
			selectTwoScript.selectUp ();
			break;
		case SpeechNodeType.LIST:
			selectListScript.selectUp ();
			break;
		case SpeechNodeType.TABLE:
			selectTableScript.selectUp ();
			break;
		default: 
			break;
		}
	}

	public void selectDown()
	{
		switch (type) {
		case SpeechNodeType.BOX:
			speechBoxScript.selectDown ();
			break;
		case SpeechNodeType.TWO:
			selectTwoScript.selectDown ();
			break;
		case SpeechNodeType.LIST:
			selectListScript.selectDown ();
			break;
		case SpeechNodeType.TABLE:
			selectTableScript.selectDown ();
			break;
		default: 
			break;
		}
	}

	public int enter()
	{
		if (state == SpeechNodeState.HIDDEN) {
			Debug.Log ("Warning, enter was pressed while the node in control is hidden...");
			return -2;
		} else if (state == SpeechNodeState.TYPING) {
			speechBoxScript.getValue ();

			if (type == SpeechNodeType.BOX) {
				state = SpeechNodeState.DONE;
			} else {
				showSelectComponent ();
				state = SpeechNodeState.WAITING;
			}

			return -3;
		} else if (state == SpeechNodeState.WAITING) {
			state = SpeechNodeState.DONE;
			return getValue ();
		}

		return -1;
	}

	public void pressEnter()
	{
		enter ();
	}

	private int getValue()
	{
		int returnValue = -1;

		switch (type) {
		case SpeechNodeType.BOX:
			break;
		case SpeechNodeType.TWO:
			returnValue = selectTwoScript.getValue ();
			break;
		case SpeechNodeType.LIST:
			returnValue = selectListScript.getValue ();
			break;
		case SpeechNodeType.TABLE:
			returnValue = selectTableScript.getValue ();
			break;
		default: 
			break;
		}

		Debug.Log ("Return: " + returnValue);

		return returnValue;
	}
}
