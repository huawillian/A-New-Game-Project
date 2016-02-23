using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public interface ISpeechComponents <T> {
	void setContent(T speechData);
	void setPosition(int x, int y);
	void enableBackButton();
	void show();
	void hide();
	void selectUp();
	void selectDown();
	void selectLeft();
	void selectRight();
	int getValue();
}
