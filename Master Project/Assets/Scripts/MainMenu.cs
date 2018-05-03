using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public bool CharacterChosen;
	public bool IsNinaChosen;



	public void CheckChoosen()
	{
		if (PlayerPrefs.HasKey("CharacterIsChosen") && PlayerPrefs.GetInt("CharacterIsChosen") == 1) 
		{
			changeMenuScene ("Game Chooser");
		}
		else 
		{
			changeMenuScene ("Welcome");
		}
	}

	public void changeMenuScene(string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }

	public void CharacterChooseBitFalse()
	{
		CharacterChosen = false;
		PlayerPrefs.SetInt ("CharacterIsChosen", 0);
	}

	public void CharacterChooseBitTrue()
	{
		CharacterChosen = true;
		PlayerPrefs.SetInt ("CharacterIsChosen", 1);
	}

	public void NinaChosenfunc()
	{
		IsNinaChosen = true;
		PlayerPrefs.SetInt ("NinaIsChosen", 1);
	}

	public void WhoIsChosen()
	{
		if (IsNinaChosen == true) {
			Debug.Log ("Nina is Chosen");
		} else
			Debug.Log ("Andy is Chosen");
	}
		



    public void quitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
