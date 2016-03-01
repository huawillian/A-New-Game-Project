using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public interface Menu_ScrollView_Interface{
	void instantiateScrollView<Menu_String_Data> (Menu_String_Data[] tempData);
	void instantiateScrollView<Menu_StringString_Data> (Menu_StringString_Data[] tempData);
	void instantiateScrollView<Menu_SpriteString_Data> (Menu_SpriteString_Data[] tempData);
	void instantiateScrollView<Menu_SpriteStringString_Data> (Menu_SpriteStringString_Data[] tempData);
	void instantiateScrollView<Menu_StringStringSprite_Data> (Menu_StringStringSprite_Data[] tempData);
	void resetContent ();
	void clearContent();
	void moveUp();
	void moveDown();
	int getValue();
}
