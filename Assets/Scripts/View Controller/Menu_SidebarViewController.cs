using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu_SidebarViewController : MonoBehaviour
{
	private GameObject sidebarviewObj;
	private GameObject contentObj;

	public GameObject sidebarRowPrefab;

	private float contentHeight;
	private float rowHeight;
	private int numVisibleRows;

	public string[] contentviewElements;

	// Use this for initialization
	void Start ()
	{
		sidebarviewObj = this.gameObject;
		contentObj = sidebarviewObj.GetComponent<ScrollRect> ().content.gameObject;

		contentHeight = sidebarviewObj.GetComponent<RectTransform>().rect.height;
		Debug.Log (contentHeight);
		rowHeight = sidebarRowPrefab.GetComponent<RectTransform> ().rect.height;
		Debug.Log (rowHeight);
		numVisibleRows = (int)(contentHeight / rowHeight);
		Debug.Log (numVisibleRows);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Instantiate given array of strings
	// Move Up
	// Move Down
	// Get Value
	// Clear Content
	// Reset Select


}
