using UnityEngine;
using System.Collections;

public interface Menu_Display_Interface {
	void show ();
	void hide();
	void moveUp ();
	void moveDown();
	void moveRight();
	void moveLeft();
	int getValue();
}
