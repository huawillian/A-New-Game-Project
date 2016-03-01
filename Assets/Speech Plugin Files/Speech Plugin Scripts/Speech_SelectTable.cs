using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls Select Table component for the Speech Plugin
//	Interface:
//		setPosition(int, int)
//		showSelectTable()
//		hideSelectTable()
//		selectUp()
//		selectDown()
//		selectRight()
//		selectLeft()
//		setContent(int, string[], string[], string, string)
//		showBackButton()
//		hideBackButton()
//		enableBackButton()
//		disableBackButton()
//
// 	Use e.g.
//		showSelectTable();
//		enableBackButton ();
//		hideBackButton ();
//		showBackButton ();
//		setPosition(0,0);
//		setContent(10, {one, two, three, four, five, six, seven, eight, nine, ten}, {one, two, three, four, five, six, seven, eight, nine, ten}, lol, hey);
//		selectDown();
//		hideSelectTable();

public class Speech_SelectTable : MonoBehaviour, ISpeechComponents<SelectTableData>
{
	public GameObject backObj;
	public GameObject tableObj;
	public GameObject filterObj;
	public GameObject filterBackObj;
	public GameObject select1Obj;
	public GameObject select2Obj;
	public GameObject select3Obj;
	public GameObject select4Obj;
	public GameObject select5Obj;
	public GameObject select6Obj;
	public GameObject select7Obj;
	public GameObject header1Obj;
	public GameObject header2Obj;

	public float posX = 381;
	public float posY = 125;

	public enum SelectTableState{HIDDEN, NONE, ONE, TWO, THREE, FOUR, FIVE, SIX, SEVEN};
	SelectTableState state = SelectTableState.HIDDEN;

	public enum BackButtonState{HIDDEN, SELECTED, NOTSELECTED, DISABLED};
	BackButtonState backState = BackButtonState.DISABLED;

	private GameObject[] contentObjects = new GameObject[7];
	public SelectTableData tableData;

	public int indexSelected = 0;
	SelectTableState tableStateBeforeBack = SelectTableState.ONE;

	// Use this for initialization
	void Start ()
	{
		contentObjects [0] = select1Obj;
		contentObjects [1] = select2Obj;
		contentObjects [2] = select3Obj;
		contentObjects [3] = select4Obj;
		contentObjects [4] = select5Obj;
		contentObjects [5] = select6Obj;
		contentObjects [6] = select7Obj;

		backState =	BackButtonState.DISABLED;
		backObj.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (backState == BackButtonState.SELECTED) {
			filterBackObj.SetActive (true);
		}

		if (backState == BackButtonState.NOTSELECTED) {
			filterBackObj.SetActive (false);
		}

		if (state == SelectTableState.NONE) {
			filterObj.SetActive (false);
		}

		if (state == SelectTableState.ONE) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 90f + 50f, 0);
		}

		if (state == SelectTableState.TWO) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 35f + 50f, 0);
		}

		if (state == SelectTableState.THREE) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -27f + 50f, 0);
		}

		if (state == SelectTableState.FOUR) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -83f + 50f, 0);
		}

		if (state == SelectTableState.FIVE) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -145f + 50f, 0);
		}

		if (state == SelectTableState.SIX) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -207f + 50f, 0);
		}

		if (state == SelectTableState.SEVEN) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -270f + 50f, 0);
		}
	}

	public void setContent(SelectTableData data)
	{
		tableData.size = data.size;
		tableData.texts1 = new string[tableData.size];
		tableData.texts2 = new string[tableData.size];

		for (int i = 0; i < tableData.size; i++) {
			tableData.texts1 [i] = data.texts1 [i];
			tableData.texts2 [i] = data.texts2 [i];
		}

		state = SelectTableState.ONE;

		indexSelected = 0;

		tableData.header1 = data.header1;
		tableData.header2 = data.header2;

		header1Obj.GetComponent<Text> ().text = tableData.header1;
		header2Obj.GetComponent<Text> ().text = tableData.header2;

		for (int i = 0; i < 7; i++) {
			if (i < tableData.size) {
				Text[] texts = contentObjects [i].GetComponentsInChildren<Text> ();
				texts [0].text = data.texts1 [i];
				texts [1].text = data.texts2 [i];
			} else {
				Text[] texts = contentObjects [i].GetComponentsInChildren<Text> ();
				texts [0].text = "";
				texts [1].text = "";
			}
		}
	}

	public void setPosition(int x, int y)
	{
		this.gameObject.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
		posX = x;
		posY = y;
	}

	public void enableBackButton()
	{
		backObj.SetActive (true);

		if (state == SelectTableState.HIDDEN) {
			backState = BackButtonState.HIDDEN;
		} else {
			backState = BackButtonState.NOTSELECTED;
		}
	}

	public void show()
	{
		tableObj.SetActive (true);
		state =	SelectTableState.NONE;

		if (backState != BackButtonState.DISABLED) {
			backObj.SetActive (true);
			backState = BackButtonState.NOTSELECTED;
		}
	}

	public void hide()
	{
		tableObj.SetActive (false);
		state =	SelectTableState.HIDDEN;

		if (backState != BackButtonState.DISABLED) {
			backObj.SetActive (false);
			backState = BackButtonState.HIDDEN;
		}
	}

	public void selectUp()
	{
		if (state == SelectTableState.HIDDEN || state == SelectTableState.NONE ) {
			Debug.Log ("Warning, attempt to selectUp for SelectTable before entering ONE...SEVEN state.");
			return;
		}

		int newIndex = indexSelected - 1;

		// change content and filter, given
		//	index, new index, and filter state

		if (newIndex < 0 && state == SelectTableState.ONE) {
			// Don't do anything
		}

		if (newIndex >= 0 && state == SelectTableState.ONE) {
			// Update table, shifting all values up one cell
			// Update index selected
			indexSelected = newIndex;

			for (int i = 0; i < 7; i++) {
				Text[] texts = contentObjects [i].GetComponentsInChildren<Text> ();
				texts [0].text = tableData.texts1 [indexSelected + i];
				texts [1].text = tableData.texts2 [indexSelected + i];
			}
		}

		if (newIndex >= 0 && state != SelectTableState.ONE) {
			// Update index selected
			// Update state
			state = state - 1;
			indexSelected = newIndex;
		}

		Debug.Log ("Select: " + indexSelected);
	}

	public void selectDown()
	{
		if (state == SelectTableState.HIDDEN || state == SelectTableState.NONE ) {
			Debug.Log ("Warning, attempt to selectDown for SelectTable before entering ONE...SEVEN state.");
			return;
		}

		int newIndex = indexSelected + 1;

		// change content and filter, given
		//	index, new index, and filter state

		if (newIndex > tableData.size - 1 && state == SelectTableState.SEVEN) {
			// Don't do anything
		}

		if (newIndex <= tableData.size - 1 && state == SelectTableState.SEVEN) {
			// Update table, shifting all values up one cell
			// Update index selected
			indexSelected = newIndex;


			for (int i = 0; i < 7; i++) {
				Text[] texts = contentObjects [i].GetComponentsInChildren<Text> ();
				texts [0].text = tableData.texts1 [indexSelected + i - 6];
				texts [1].text = tableData.texts2 [indexSelected + i - 6];
			}
		}

		if (newIndex >= 0 && state != SelectTableState.SEVEN && newIndex < tableData.size) {
			// Update index selected
			// Update state
			state = state + 1;
			indexSelected = newIndex;
		}

		Debug.Log ("Select: " + indexSelected);
	}

	public void selectLeft()
	{
		if (backState != BackButtonState.DISABLED && backState != BackButtonState.HIDDEN) {
			if (state != SelectTableState.NONE) {
				tableStateBeforeBack = state;
				state = SelectTableState.NONE;
				backState = BackButtonState.SELECTED;
			}
		}
	}

	public void selectRight()
	{
		if (backState != BackButtonState.DISABLED && backState != BackButtonState.HIDDEN) {
			if (state == SelectTableState.NONE) {
				state = tableStateBeforeBack;
				backState = BackButtonState.NOTSELECTED;
			}
		}
	}


	public int getValue()
	{
		if (state != SelectTableState.NONE && state != SelectTableState.HIDDEN) {
			return indexSelected;
		} else if (state == SelectTableState.NONE && backState == BackButtonState.SELECTED) {
			return -2;
		} else {
			return -1;
		}
	}
}
