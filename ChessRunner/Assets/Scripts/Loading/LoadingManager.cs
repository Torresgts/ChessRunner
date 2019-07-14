using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
	[SerializeField]
	private Animator loadingAnimator;

    void Start()
	{
		StartCoroutine(LoadGameplayAsync());
	}

	IEnumerator LoadGameplayAsync()
	{
		yield return new WaitForSeconds(1f);

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);

		while (!asyncLoad.isDone)
		{
			yield return null;
		}

		loadingAnimator.SetTrigger("EndLoading");

		yield return new WaitForSeconds(1f);

		SceneManager.UnloadScene(1);
	}
}
