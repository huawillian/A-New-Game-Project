using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Interface:
//	setBreadcrumbs
//	setAreaName
//	setAreaImage

public class Menu_HeaderViewController : MonoBehaviour
{
	public GameObject breadcrumbsObj;
	public GameObject areaNameObj;
	public GameObject areaImageObj;

	private Menu_String_Data breadcrumbsData;
	private Menu_String_Data areaNameData;
	private Sprite areaImageData;

	public Sprite sp;

	void Start()
	{
		setAreaImage (sp);
	}
		
	public void setBreadcrumbs(Menu_String_Data tempData)
	{
		breadcrumbsObj.GetComponent<Text> ().text = tempData.string1;
		breadcrumbsData.string1 = tempData.string1;
	}

	public void setAreaName(Menu_String_Data tempData)
	{
		areaNameObj.GetComponent<Text> ().text = tempData.string1;
		areaNameData.string1 = tempData.string1;
	}

	public void setAreaImage(Sprite tempData)
	{
		areaImageData = tempData;
		areaImageObj.GetComponent<Image> ().sprite = areaImageData;
	}
}
