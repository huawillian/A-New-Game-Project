using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Interface:
//	SetLevel
//	SetRAM
//	SetTime
//	SetInstruction

public class Menu_FooterViewController : MonoBehaviour
{
	public GameObject lvlObj;
	public GameObject lvlEntry;
	public GameObject ramObj;
	public GameObject ramEntry;
	public GameObject timeObj;
	public GameObject timeEntry;
	public GameObject instructionTitleObj;
	public GameObject instructionSubtitleObj;

	private Menu_String_Data lvlData;
	private Menu_String_Data ramData;
	private Menu_String_Data timeData;
	private Menu_StringString_Data instructionData;

	public void setLevel(Menu_String_Data tempData)
	{
		lvlEntry.GetComponent<Text> ().text = tempData.string1;
		lvlData.string1 = tempData.string1;
	}

	public void setRAM(Menu_String_Data tempData)
	{
		ramEntry.GetComponent<Text> ().text = tempData.string1;
		ramData.string1 = tempData.string1;
	}

	public void setTime(Menu_String_Data tempData)
	{
		timeEntry.GetComponent<Text> ().text = tempData.string1;
		timeData.string1 = tempData.string1;
	}

	public void setInstruction(Menu_StringString_Data tempData)
	{
		instructionTitleObj.GetComponent<Text> ().text = tempData.string1;
		instructionSubtitleObj.GetComponent<Text> ().text = tempData.string2;

		instructionData.string1 = tempData.string1;
		instructionData.string2 = tempData.string2;
	}
}
