using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameplay : MonoBehaviour
{
	public void LoadSceneGameplay()
	{
		StartCoroutine(LoadGameplayAsync());
	}


	public void ReloadSceneGameplay()
	{
		StartCoroutine(LoadGameplayAsync());
	}

	IEnumerator LoadGameplayAsync()
	{
		Scene actualScene = SceneManager.GetActiveScene();

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);

		while (!asyncLoad.isDone)
		{
			yield return null;
		}

		yield return new WaitForSeconds(1f);

		SceneManager.UnloadScene(actualScene);
	}
}
