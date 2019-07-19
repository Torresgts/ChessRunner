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
        Horse.playerIsDead = false;
	}

	IEnumerator LoadGameplayAsync()
	{
		Scene actualScene = SceneManager.GetActiveScene();

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);

		while (!asyncLoad.isDone)
		{
			yield return null;
		}

		yield return new WaitForSeconds(1f);

		SceneManager.UnloadScene(actualScene);
	}

    IEnumerator LoadMainMenuAsync()
    {
        Scene actualScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        SceneManager.UnloadScene(actualScene);
    }
}
