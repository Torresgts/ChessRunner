using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
	public void GoToGameplay()
	{
		StartCoroutine(LoadGameplayAsync());

	}

	IEnumerator LoadGameplayAsync()
	{

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

		while(!asyncLoad.isDone)
		{
			yield return null;
		}

		yield return new WaitForSeconds(1f);

		SceneManager.UnloadScene(0);
	}

}
