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
    public Image image;

    IEnumerator Start()
    {
        image.fillAmount = 0.0f;
        asyncOperation = SceneManager.LoadSceneAsync("GameStart");
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            image.fillAmount = progress;
            progress *= 100f;
            text.text = progress.ToString() + "%";

            yield return new WaitForSeconds( Random.Range(0.5f, 1.0f)) ;

            if (image.fillAmount > 0.7f)
            {
                yield return new WaitForSeconds(3.5f);

                //messagetext.gameObject.SetActive(true);
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}
