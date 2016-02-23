using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_ScrollViewController: MonoBehaviour, Menu_ScrollView_Interface
{
	public GameObject rowPrefab;

	public enum Menu_ScrollViewType{STRINGONLY, STRINGSTRING, SPRITESTRING, SPRITESTRINGSTRING, STRINGSTRINGSPRITE};
	public Menu_ScrollViewType type = Menu_ScrollViewType.STRINGONLY;

	private GameObject scrollviewObj;
	private GameObject contentObj;
	private Scrollbar verticalScrollbar;

	private float contentHeight;
	private float rowHeight;
	private float originalContentHeight;
	private int numVisibleRows;

	private Menu_String_Data[] stringElements;
	private Menu_StringString_Data[] stringStringElements;
	private Menu_SpriteString_Data[] spriteStringElements;
	private Menu_SpriteStringString_Data[] spriteStringStringElements;
	private Menu_StringStringSprite_Data[] stringStringSpriteElements;

	public int numRows = 0;

	public bool isInstantiate = false;
	public int indexSelected = 0;
	public int indexVisible = 0;

	void Awake()
	{
		scrollviewObj = this.gameObject;
		contentObj = scrollviewObj.GetComponent<ScrollRect> ().content.gameObject;
		verticalScrollbar = scrollviewObj.GetComponent<ScrollRect> ().verticalScrollbar;

		contentHeight = scrollviewObj.GetComponent<RectTransform>().rect.height;
		originalContentHeight = contentHeight;
		rowHeight = rowPrefab.GetComponent<RectTransform> ().rect.height;
		numVisibleRows = (int)(contentHeight / rowHeight);

		string prefabName = rowPrefab.name;

		switch (prefabName) {
		case "StringRow":
			type = Menu_ScrollViewType.STRINGONLY;
			break;
		case "StringStringRow":
			type = Menu_ScrollViewType.STRINGSTRING;
			break;
		case "SpriteStringRow":
			type = Menu_ScrollViewType.SPRITESTRING;
			break;
		case "SpriteStringStringRow":
			type = Menu_ScrollViewType.SPRITESTRINGSTRING;
			break;
		case "StringStringSpriteRow":
			type = Menu_ScrollViewType.STRINGSTRINGSPRITE;
			break;
		default:
			Debug.Log ("ERROR! Invalid prefab for scrollview...");
			break;
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}

		
	public void instantiateScrollView<Menu_String_Data> (Menu_String_Data[] tempData){
		if (type != Menu_ScrollViewType.STRINGONLY) {
			Debug.Log ("ERROR, type of prefab for scroll view content is inconsistent with instantiate data...");
			return;
		}

		stringElements = new Menu_String_Data[tempData.Length];
		stringElements = (Menu_String_Data[])tempData.Clone ();

		numRows = tempData.Length;

		isInstantiate = true;
		resetContent ();
	}

	public void instantiateScrollView<Menu_StringString_Data> (Menu_StringString_Data[] tempData){
		if (type != Menu_ScrollViewType.STRINGSTRING) {
			Debug.Log ("ERROR, type of prefab for scroll view content is inconsistent with instantiate data...");
			return;
		}

		stringStringElements = new Menu_StringString_Data[tempData.Length];
		stringStringElements = (Menu_StringString_Data[])tempData.Clone ();

		numRows = tempData.Length;

		isInstantiate = true;
		resetContent ();
	}

	public void instantiateScrollView<Menu_SpriteString_Data> (Menu_SpriteString_Data[] tempData){
		if (type != Menu_ScrollViewType.SPRITESTRING) {
			Debug.Log ("ERROR, type of prefab for scroll view content is inconsistent with instantiate data...");
			return;
		}

		spriteStringElements = new Menu_SpriteString_Data[tempData.Length];
		spriteStringElements = (Menu_SpriteString_Data[])tempData.Clone ();

		numRows = tempData.Length;

		isInstantiate = true;
		resetContent ();
	}

	public void instantiateScrollView<Menu_SpriteStringString_Data> (Menu_SpriteStringString_Data[] tempData){
		if (type != Menu_ScrollViewType.SPRITESTRINGSTRING) {
			Debug.Log ("ERROR, type of prefab for scroll view content is inconsistent with instantiate data...");
			return;
		}

		spriteStringStringElements = new Menu_SpriteStringString_Data[tempData.Length];
		spriteStringStringElements = (Menu_SpriteStringString_Data[])tempData.Clone ();

		numRows = tempData.Length;

		isInstantiate = true;
		resetContent ();
	}

	public void instantiateScrollView<Menu_StringStringSprite_Data> (Menu_StringStringSprite_Data[] tempData){
		if (type != Menu_ScrollViewType.STRINGSTRINGSPRITE) {
			Debug.Log ("ERROR, type of prefab for scroll view content is inconsistent with instantiate data...");
			return;
		}

		stringStringSpriteElements = new Menu_StringStringSprite_Data[tempData.Length];
		stringStringSpriteElements = (Menu_StringStringSprite_Data[])tempData.Clone ();

		numRows = tempData.Length;

		isInstantiate = true;
		resetContent ();
	}

	public void resetContent ()
	{
		// Destroy all existing objects
		clearContent ();

		// Create Objects given prefab and the data and type of Scroll View
		switch (type) {
		case Menu_ScrollViewType.STRINGONLY:
			for (int i = 0; i < stringElements.Length; i++) {
				GameObject tempObjRef = (GameObject)GameObject.Instantiate (rowPrefab);
				tempObjRef.transform.SetParent (contentObj.transform);
				tempObjRef.GetComponent<RectTransform> ().localScale = Vector3.one;
				tempObjRef.GetComponent<RectTransform> ().localPosition = new Vector3 (0, rowHeight / (-2) - i * rowHeight, 0);
				tempObjRef.GetComponent<Text> ().text = stringElements [i].string1;
			}

			contentHeight = stringElements.Length * rowHeight;

			if (contentHeight > originalContentHeight) {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, contentHeight);
			} else {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, originalContentHeight);
			}
			break;
		case Menu_ScrollViewType.STRINGSTRING:
			for (int i = 0; i < stringStringElements.Length; i++) {
				GameObject tempObjRef = (GameObject)GameObject.Instantiate (rowPrefab);
				tempObjRef.transform.SetParent (contentObj.transform);
				tempObjRef.GetComponent<RectTransform> ().localScale = Vector3.one;
				tempObjRef.GetComponent<RectTransform> ().localPosition = new Vector3 (0, rowHeight / (-2) - i * rowHeight, 0);

				tempObjRef.GetComponentsInChildren<Text>()[0].text  = stringStringElements [i].string1;
				tempObjRef.GetComponentsInChildren<Text>()[1].text  = stringStringElements [i].string2;
			}

			contentHeight = stringStringElements.Length * rowHeight;

			if (contentHeight > originalContentHeight) {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, contentHeight);
			} else {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, originalContentHeight);
			}
			break;
		case Menu_ScrollViewType.SPRITESTRING:
			for (int i = 0; i < spriteStringElements.Length; i++) {
				GameObject tempObjRef = (GameObject)GameObject.Instantiate (rowPrefab);
				tempObjRef.transform.SetParent (contentObj.transform);
				tempObjRef.GetComponent<RectTransform> ().localScale = Vector3.one;
				tempObjRef.GetComponent<RectTransform> ().localPosition = new Vector3 (0, rowHeight / (-2) - i * rowHeight, 0);

				tempObjRef.GetComponentsInChildren<Text>()[0].text  = spriteStringElements [i].string1;
				tempObjRef.GetComponentsInChildren<Image>()[0].sprite  = spriteStringElements [i].sprite1;
			}

			contentHeight = spriteStringElements.Length * rowHeight;

			if (contentHeight > originalContentHeight) {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, contentHeight);
			} else {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, originalContentHeight);
			}
			break;
		case Menu_ScrollViewType.SPRITESTRINGSTRING:
			for (int i = 0; i < spriteStringStringElements.Length; i++) {
				GameObject tempObjRef = (GameObject)GameObject.Instantiate (rowPrefab);
				tempObjRef.transform.SetParent (contentObj.transform);
				tempObjRef.GetComponent<RectTransform> ().localScale = Vector3.one;
				tempObjRef.GetComponent<RectTransform> ().localPosition = new Vector3 (0, rowHeight / (-2) - i * rowHeight, 0);

				tempObjRef.GetComponentsInChildren<Text>()[0].text  = spriteStringStringElements [i].string1;
				tempObjRef.GetComponentsInChildren<Text>()[1].text  = spriteStringStringElements [i].string2;
				tempObjRef.GetComponentsInChildren<Image>()[0].sprite  = spriteStringStringElements [i].sprite1;
			}

			contentHeight = spriteStringStringElements.Length * rowHeight;

			if (contentHeight > originalContentHeight) {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, contentHeight);
			} else {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, originalContentHeight);
			}
			break;
		case Menu_ScrollViewType.STRINGSTRINGSPRITE:
			for (int i = 0; i < stringStringSpriteElements.Length; i++) {
				GameObject tempObjRef = (GameObject)GameObject.Instantiate (rowPrefab);
				tempObjRef.transform.SetParent (contentObj.transform);
				tempObjRef.GetComponent<RectTransform> ().localScale = Vector3.one;
				tempObjRef.GetComponent<RectTransform> ().localPosition = new Vector3 (0, rowHeight / (-2) - i * rowHeight, 0);

				tempObjRef.GetComponentsInChildren<Text>()[0].text  = stringStringSpriteElements [i].string1;
				tempObjRef.GetComponentsInChildren<Text>()[1].text  = stringStringSpriteElements [i].string2;
				tempObjRef.GetComponentsInChildren<Image>()[0].sprite  = stringStringSpriteElements [i].sprite1;
			}

			contentHeight = stringStringSpriteElements.Length * rowHeight;

			if (contentHeight > originalContentHeight) {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, contentHeight);
			} else {
				contentObj.GetComponent<RectTransform> ().sizeDelta = new Vector2 (contentObj.GetComponent<RectTransform> ().rect.width, originalContentHeight);
			}
			break;
		default: 
			break;
		}

		// Set Select to 0, or call setSelect to handle the bolding and stuff
		setSelect (0);
		setVisible (0);
	}

	public void clearContent()
	{
		foreach (Transform child in contentObj.transform) {
			GameObject.Destroy(child.gameObject);
		}
		contentObj.transform.DetachChildren ();
	}

	public void moveUp()
	{
		int newIndex = indexSelected - 1;

		if (newIndex >= 0) {
			setSelect (newIndex);
		}

		if (newIndex < indexVisible) {
			setVisible (newIndex);
		}
	}

	public void moveDown()
	{
		int newIndex = indexSelected + 1;

		if (newIndex <= numRows - 1) {
			setSelect (newIndex);
		}

		if (newIndex > indexVisible + numVisibleRows - 1) {
			setVisible (newIndex - numVisibleRows + 1);
		}
	}

	public int getValue(){
		return indexSelected;
	}

	private void setSelect(int tempIndex)
	{
		int i=0;

		foreach (Transform child in contentObj.transform) {
			if (i == tempIndex) {
				foreach (Text childText in child.GetComponentsInChildren<Text>()) {
					childText.color = new Color32 (255, 255, 255, 255);
				}
			} else {
				foreach (Text childText in child.GetComponentsInChildren<Text>()) {
					childText.color = new Color32 (50, 50, 50, 255);
				}
			}

			i++;
		}

		indexSelected = tempIndex;
	}

	private void setVisible(int tempIndex)
	{
		if (numRows < numVisibleRows) {
			return;
		} else {
			verticalScrollbar.value = (float)1 - ((float)(tempIndex) / (float)(numRows -  numVisibleRows));
		}

		indexVisible = tempIndex;
	}

}
