using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Speech_ControlPanel : MonoBehaviour
{
	public GameObject panel;
	public GameObject panel1;
	public GameObject panel2;
	public GameObject panel3;
	public GameObject panel4;
	public GameObject panel5;

	public GameObject nodeObj;
	private Speech_Node nodeScript;

	public Sprite img1;
	public Sprite img2;

	public string twoH1;
	public string twoH2;
	public int posX;
	public int posY;
	public bool back;
	public string[] list1;

	public GameObject keyboard;

	public void createBox()
	{
		SpeechBoxData d = new SpeechBoxData ();
		d.image1 = img1;
		d.image2 = img2;
		d.text = speechboxtext;

		nodeScript.instantiateNodeTypeBox (d);
		nodeScript.startNode ();
		panel.SetActive (false);
		keyboard.SetActive (true);
	}

	public void createTwo()
	{
		SpeechBoxData d = new SpeechBoxData ();
		d.image1 = img1;
		d.image2 = img2;
		d.text = speechboxtext;

		SelectTwoData d1 = new SelectTwoData ();
		d1.text1 = twoH1;
		d1.text2 = twoH2;

		nodeScript.instantiateNodeTypeTwo (d, d1, new Vector2(posX, posY), false);
		nodeScript.startNode ();
		panel.SetActive (false);
		keyboard.SetActive (true);
	}

	public void createList()
	{
		SpeechBoxData d = new SpeechBoxData ();
		d.image1 = img1;
		d.image2 = img2;
		d.text = speechboxtext;

		SelectListData d1 = new SelectListData ();
		d1.size = list1.Length;
		d1.texts = new string[d1.size];
		list1.CopyTo (d1.texts, 0);

		nodeScript.instantiateNodeTypeList (d, d1, new Vector2(posX, posY), back);
		nodeScript.startNode ();
		panel.SetActive (false);
		keyboard.SetActive (true);
	}

	public void createTable()
	{
		SpeechBoxData d = new SpeechBoxData ();
		d.image1 = img1;
		d.image2 = img2;
		d.text = speechboxtext;

		SelectTableData d1 = new SelectTableData ();
		d1.size = list1.Length;
		d1.texts1 = new string[d1.size];
		list1.CopyTo (d1.texts1, 0);
		d1.texts2 = new string[d1.size];
		list2.CopyTo (d1.texts2, 0);
		d1.header1 = d1.texts1 [0];
		d1.header2 = d1.texts2 [0];

		nodeScript.instantiateNodeTypeTable (d, d1, new Vector2(posX, posY), back);
		nodeScript.startNode ();
		panel.SetActive (false);
		keyboard.SetActive (true);
	}

	public void updateType(int index)
	{
		if (index == 0) {
			panel2.SetActive (false);
			panel3.SetActive (false);
			panel4.SetActive (false);
			panel5.SetActive (false);
		}

		if (index == 1) {
			panel2.SetActive (true);
			panel3.SetActive (false);
			panel4.SetActive (false);
			panel5.SetActive (false);
		}

		if (index == 2) {
			panel2.SetActive (false);
			panel3.SetActive (true);
			panel4.SetActive (false);
			panel5.SetActive (false);
		}

		if (index == 3) {
			panel2.SetActive (false);
			panel3.SetActive (false);
			panel4.SetActive (true);
			panel5.SetActive (false);
		}

		if (index == 4) {
			panel2.SetActive (false);
			panel3.SetActive (false);
			panel4.SetActive (false);
			panel5.SetActive (true);
		}
	}

	public string speechboxtext;

	public void updateSpeechBox(GameObject s)
	{
		speechboxtext = s.GetComponent<Text>().text;
	}

	public void updatePosX(GameObject s)
	{
		int result;
		int.TryParse (s.GetComponent<Text>().text, out result);
		posX = result;
	}

	public void updatePosY(GameObject s)
	{
		int result;
		int.TryParse (s.GetComponent<Text>().text, out result);
		posY = result;
	}

	public void updateHeader1(GameObject s)
	{
		twoH1 = s.GetComponent<Text>().text;
	}

	public void updateHeader2(GameObject s)
	{
		twoH2 = s.GetComponent<Text>().text;
	}

	public void updateBack(GameObject b)
	{
		back = b.GetComponent<Toggle> ().isOn;
	}

	public void updateList1(GameObject l)
	{
		string s = l.GetComponent<Text> ().text;
		list1 = s.Split (',');
	}

	public void updateList2(GameObject l)
	{
		string s = l.GetComponent<Text> ().text;
		list2 = s.Split (',');
	}

	public string[] list2;

	// Use this for initialization
	void Start () {
		nodeScript = nodeObj.GetComponent<Speech_Node> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
