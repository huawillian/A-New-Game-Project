using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls Select List component for the Speech Plugin

public class Speech_SelectList : MonoBehaviour, ISpeechComponents<SelectListData>
{
	public GameObject backObj;
	public GameObject listObj;
	public GameObject filterObj;
	public GameObject filterBackObj;
	public GameObject select1Obj;
	public GameObject select2Obj;
	public GameObject select3Obj;
	public GameObject select4Obj;
	public GameObject select5Obj;

	public float posX = -33;
	public float posY = -50;

	public enum SelectListState{HIDDEN, NONE, ONE, TWO, THREE, FOUR, FIVE};
	SelectListState state = SelectListState.HIDDEN;

	public enum BackButtonState{HIDDEN, SELECTED, NOTSELECTED, DISABLED};
	BackButtonState backState = BackButtonState.DISABLED;

	public SelectListData listData; 

	public int indexSelected = 0;
	SelectListState listStateBeforeBack = SelectListState.ONE;

	private GameObject[] contentObjects = new GameObject[5];

	// Use this for initialization
	void Start () {
		contentObjects [0] = select1Obj;
		contentObjects [1] = select2Obj;
		contentObjects [2] = select3Obj;
		contentObjects [3] = select4Obj;
		contentObjects [4] = select5Obj;

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

		if (state == SelectListState.NONE) {
			filterObj.SetActive (false);
		}

		if (state == SelectListState.ONE) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 150f, 0);
		}

		if (state == SelectListState.TWO) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 75.5f, 0);
		}

		if (state == SelectListState.THREE) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 0, 0);
		}

		if (state == SelectListState.FOUR) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -75.5f, 0);
		}

		if (state == SelectListState.FIVE) {
			filterObj.SetActive (true);
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -150f, 0);
		}
	}

	public void setContent(SelectListData data)
	{
		listData.size = data.size;
		listData.texts = new string[listData.size];

		for (int i = 0; i < listData.size; i++) {
			listData.texts [i] = data.texts [i];
		}

		state = SelectListState.ONE;

		indexSelected = 0;

		for (int i=0; i<5; i++) {
			if (i < listData.size) {
				contentObjects[i].GetComponent<Text> ().text = listData.texts [i];
			} else {
				contentObjects[i].GetComponent<Text> ().text = "";
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

		if (state == SelectListState.HIDDEN) {
			backState = BackButtonState.HIDDEN;
		} else {
			backState = BackButtonState.NOTSELECTED;
		}
	}

	public void show()
	{
		listObj.SetActive (true);
		state =	SelectListState.NONE;

		if (backState != BackButtonState.DISABLED) {
			backObj.SetActive (true);
			backState = BackButtonState.NOTSELECTED;
		}
	}
		
	public void hide()
	{
		listObj.SetActive (false);
		state =	SelectListState.HIDDEN;

		if (backState != BackButtonState.DISABLED) {
			backObj.SetActive (false);
			backState = BackButtonState.HIDDEN;
		}
	}
		
	public void selectUp()
	{
		if (state == SelectListState.HIDDEN || state == SelectListState.NONE ) {
			Debug.Log ("Warning, attempt to selectUp for SelectList before entering ONE...FIVE state.");
			return;
		}

		int newIndex = indexSelected - 1;

		// change content and filter, given
		//	index, new index, and filter state

		if (newIndex < 0 && state == SelectListState.ONE) {
			// Don't do anything
		}

		if (newIndex >= 0 && state == SelectListState.ONE) {
			// Update table, shifting all values up one cell
			// Update index selected
			indexSelected = newIndex;

			select1Obj.GetComponent<Text> ().text = listData.texts [indexSelected];
			select2Obj.GetComponent<Text> ().text = listData.texts [indexSelected + 1];
			select3Obj.GetComponent<Text> ().text = listData.texts [indexSelected + 2];
			select4Obj.GetComponent<Text> ().text = listData.texts [indexSelected + 3];
			select5Obj.GetComponent<Text> ().text = listData.texts [indexSelected + 4];
		}

		if (newIndex >= 0 && state != SelectListState.ONE) {
			// Update index selected
			// Update state
			state = state - 1;
			indexSelected = newIndex;
		}

		Debug.Log ("Select: " + indexSelected);
	}

	public void selectDown()
	{
		if (state == SelectListState.HIDDEN || state == SelectListState.NONE ) {
			Debug.Log ("Warning, attempt to selectDown for SelectList before entering ONE...FIVE state.");
			return;
		}

		int newIndex = indexSelected + 1;

		// change content and filter, given
		//	index, new index, and filter state

		if (newIndex > listData.size - 1 && state == SelectListState.FIVE) {
			// Don't do anything
		}

		if (newIndex <= listData.size - 1 && state == SelectListState.FIVE) {
			// Update table, shifting all values up one cell
			// Update index selected
			indexSelected = newIndex;

			select1Obj.GetComponent<Text> ().text = listData.texts [indexSelected - 4];
			select2Obj.GetComponent<Text> ().text = listData.texts [indexSelected - 3];
			select3Obj.GetComponent<Text> ().text = listData.texts [indexSelected - 2];
			select4Obj.GetComponent<Text> ().text = listData.texts [indexSelected - 1];
			select5Obj.GetComponent<Text> ().text = listData.texts [indexSelected];
		}

		if (newIndex >= 0 && state != SelectListState.FIVE && newIndex < listData.size) {
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
			if (state != SelectListState.NONE) {
				listStateBeforeBack = state;
				state = SelectListState.NONE;
				backState = BackButtonState.SELECTED;
			}
		}
	}

	public void selectRight()
	{
		if (backState != BackButtonState.DISABLED && backState != BackButtonState.HIDDEN) {
			if (state == SelectListState.NONE) {
				state = listStateBeforeBack;
				backState = BackButtonState.NOTSELECTED;
			}
		}
	}

	public int getValue()
	{
		if (state != SelectListState.NONE && state != SelectListState.HIDDEN) {
			return indexSelected;
		} else if (state == SelectListState.NONE && backState == BackButtonState.SELECTED) {
			return -2;
		} else {
			return -1;
		}
	}

}
