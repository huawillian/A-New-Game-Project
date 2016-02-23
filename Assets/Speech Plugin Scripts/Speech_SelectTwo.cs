using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls Select Two component for the Speech Plugin

public class Speech_SelectTwo : MonoBehaviour, ISpeechComponents<SelectTwoData>
{
	public GameObject noObj;
	public GameObject yesObj;
	public GameObject backgroundObj;
	public GameObject filterObj;

	public float posX = -230;
	public float posY = 125;

	public enum SelectTwoState{HIDDEN, YES, NO};
	SelectTwoState state = SelectTwoState.HIDDEN;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (state == SelectTwoState.YES) {
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -45, 0);
		}

		if (state == SelectTwoState.NO) {
			filterObj.GetComponent<RectTransform> ().localPosition = new Vector3 (0, -105, 0);
		}
	}

	public void setContent(SelectTwoData data)
	{
		yesObj.GetComponent<Text> ().text = data.text1;
		noObj.GetComponent<Text> ().text = data.text2;
	}

	public void setPosition(int x, int y)
	{
		this.gameObject.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
		posX = x;
		posY = y;
	}

	public void enableBackButton() 
	{
	}

	public void show()
	{
		backgroundObj.SetActive (true);
		noObj.SetActive (true);
		yesObj.SetActive (true);
		filterObj.SetActive (true);

		state =	SelectTwoState.YES;
	}

	public void hide()
	{
		backgroundObj.SetActive (false);
		noObj.SetActive (false);
		yesObj.SetActive (false);
		filterObj.SetActive (false);

		state =	SelectTwoState.HIDDEN;
	}

	public void selectUp()
	{
		state = SelectTwoState.YES;
	}

	public void selectDown()
	{
		state = SelectTwoState.NO;
	}

	public void selectLeft()
	{
	}

	public void selectRight()
	{
	}

	public int getValue()
	{
		if (state == SelectTwoState.YES) {
			return 0;
		}

		if (state == SelectTwoState.NO) {
			return 1;
		}

		return -1;
	}
}
