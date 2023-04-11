using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    private AsyncOperation asyncOperation;
    public Text text;
    public Text messagetext;

    IEnumerator Start()
    {
        //EditorApplication.isPaused = true;
        asyncOperation = SceneManager.LoadSceneAsync("GameStart");
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f * 100f;
            text.text = progress.ToString() + "%";

            yield return null;

            if (asyncOperation.progress > 0.7f)
            {
                yield return new WaitForSeconds(2.5f);

                messagetext.gameObject.SetActive(true);

                if(Input.GetMouseButtonDown(0))
                    asyncOperation.allowSceneActivation = true;
            }
        }


    }
}
