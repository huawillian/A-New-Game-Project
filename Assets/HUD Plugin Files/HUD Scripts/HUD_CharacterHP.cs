using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Controls the Character HP Bar on the HUD
// Interface:
//		updateHealth(int)
//		updateMaxHealth(int)

public class HUD_CharacterHP : MonoBehaviour
{
	// Need reference to the health bars
	public GameObject healthBarObject;
	public GameObject DamagedHealthBarObject;
	private Slider healthBar;
	private Slider damagedHealthBar;

	public int health = 100;
	public int damagedHealth = 100;
	public int maxHealth = 100;

	// Use this for initialization
	void Start ()
	{
		healthBar = healthBarObject.GetComponent<Slider> ();
		damagedHealthBar = DamagedHealthBarObject.GetComponent<Slider> ();

		healthBar.maxValue = maxHealth;
		damagedHealthBar.maxValue = maxHealth;
		healthBar.value = health;
		damagedHealthBar.value = health;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (damagedHealth > health) {
			damagedHealth--;
		} else if (damagedHealth < health){
			damagedHealth = health;
		}

		damagedHealthBar.value = damagedHealth;

	}

	public void updateHealth(int tempHealth)
	{
		health = tempHealth;
		healthBar.value = health;
	}

	public void updateMaxHealth(int tempMaxHealth)
	{
		maxHealth = tempMaxHealth;
		healthBar.maxValue = maxHealth;
		damagedHealthBar.maxValue = maxHealth;
	}
}
