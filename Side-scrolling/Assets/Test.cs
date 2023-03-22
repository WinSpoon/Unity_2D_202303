using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject ui;
    public RectTransform uiTranspos;


    public float sizeX;
    public float sizeY;

    private void Awake()
    {
        uiTranspos = ui.GetComponent<RectTransform>();
    }

    private void Start()
    {
        uiTranspos.sizeDelta = new Vector2(5.0f, 5.0f);

        sizeX = 1000.0f;
        sizeY = 500.0f;

        StartCoroutine(EffectUi());
    }

    private void OnEnable()
    {
        StartCoroutine(EffectUi());
    }

    private void OnDisable()
    {
        uiTranspos.sizeDelta = new Vector2(5.0f, 5.0f);
    }

    IEnumerator EffectUi()
    {
        float fTime = 0.0f;

        while (uiTranspos.sizeDelta.y < sizeY)
        {
            fTime += Time.deltaTime * 4.0f;

            uiTranspos.sizeDelta = Vector2.Lerp(
                new Vector2(5.0f, 5.0f),
                new Vector2(5.0f, sizeY),
               fTime);

            yield return null;
        }

        fTime = 0.0f;

        while (uiTranspos.sizeDelta.x < sizeX)
        {
            fTime += Time.deltaTime * 4.0f;

            uiTranspos.sizeDelta = Vector2.Lerp(
                new Vector2(5.0f, sizeY),
                new Vector2(sizeX, sizeY),
               fTime);

            yield return null;
        }
    }
}
