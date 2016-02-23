using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls the Character Rage Bar on the HUD
// Interface:
//		updateRage(int)
//		updateMaxRage(int) 100,200,300,400,500

public class HUD_CharacterRage : MonoBehaviour
{
	// Need reference to the health bars
	public GameObject rageBarObject;
	public GameObject rageBar1Object;
	public GameObject rageBar2Object;
	public GameObject rageBar3Object;
	public GameObject rageBar4Object;
	private Slider rageBar;
	private Slider rageBar1;
	private Slider rageBar2;
	private Slider rageBar3;
	private Slider rageBar4;

	public int rage = 150;
	public int maxRage = 200;

	// Use this for initialization
	void Start ()
	{
		rageBar = rageBarObject.GetComponent<Slider> ();
		rageBar1 = rageBar1Object.GetComponent<Slider> ();
		rageBar2 = rageBar2Object.GetComponent<Slider> ();
		rageBar3 = rageBar3Object.GetComponent<Slider> ();
		rageBar4 = rageBar4Object.GetComponent<Slider> ();

		updateMaxRage (maxRage);
		updateRage (rage);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateRage(int tempRage)
	{
		if (tempRage > maxRage || tempRage < 0) {
			Debug.Log ("Invalid Rage: " + tempRage);
		}

		rage = tempRage;

		rageBar.value = rage % 100;

		if (rage == maxRage)
			rageBar.value = 100;

		if (rage >= 100) {
			rageBar1.value = 1;
		} else { 
			rageBar1.value = 0;
		}

		if (rage >= 200) {
			rageBar2.value = 1;
		} else { 
			rageBar2.value = 0;
		}

		if (rage >= 300) {
			rageBar3.value = 1;
		} else { 
			rageBar3.value = 0;
		}

		if (rage >= 400) {
			rageBar4.value = 1;
		} else { 
			rageBar4.value = 0;
		}
	}

	public void updateMaxRage(int tempMaxRage)
	{
		if (!(tempMaxRage == 100 || tempMaxRage == 200 || tempMaxRage == 300 || tempMaxRage == 400 || tempMaxRage == 500)) {
			Debug.Log ("Invalid max rage: " + tempMaxRage);
			return;
		}

		maxRage = tempMaxRage;

		switch (maxRage) {
		case 100:
			rageBar1Object.SetActive (false);
			rageBar2Object.SetActive (false);
			rageBar3Object.SetActive (false);
			rageBar4Object.SetActive (false);
			break;
		case 200:
			rageBar1Object.SetActive (true);
			rageBar2Object.SetActive (false);
			rageBar3Object.SetActive (false);
			rageBar4Object.SetActive (false);
			break;
		case 300:
			rageBar1Object.SetActive (true);
			rageBar2Object.SetActive (true);
			rageBar3Object.SetActive (false);
			rageBar4Object.SetActive (false);
			break;
		case 400:
			rageBar1Object.SetActive (true);
			rageBar2Object.SetActive (true);
			rageBar3Object.SetActive (true);
			rageBar4Object.SetActive (false);
			break;
		case 500:
			rageBar1Object.SetActive (true);
			rageBar2Object.SetActive (true);
			rageBar3Object.SetActive (true);
			rageBar4Object.SetActive (true);
			break;
		default:
			break;
		}
	}
}
