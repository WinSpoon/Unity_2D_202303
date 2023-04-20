using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color color; // 타일 색상
    private Vector2 position; // 타일 좌표
    private float size; // 타일 크기
    private Sprite sprite; // 타일 스프라이트
    private GameObject gameObject; // 타일 게임 오브젝트

    public Tile(Vector2 position, float size, Sprite sprite)
    {
        this.position = position;
        this.size = size;
        this.sprite = sprite;

        // 타일 게임 오브젝트 생성
        gameObject = new GameObject();
        gameObject.name = "Tile";
        gameObject.transform.position = position;
        gameObject.transform.localScale = new Vector3(size, size, 1f);
        gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.SetActive(true);

        // 타일 색상 랜덤 설정
        Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };
        color = colors[Random.Range(0, colors.Length)];
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
    public void MoveTo(Vector2 position, float duration)
    {
        // 타일 이동 애니메이션 코루틴 실행
        StartCoroutine(Move(position, duration));
    }

    private IEnumerator Move(Vector2 position, float duration)
    {
        float elapsedTime = 0f;
        Vector2 startPosition = gameObject.transform.position;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            gameObject.transform.position = Vector2.Lerp(startPosition, position, t);
            yield return null;
        }
        gameObject.transform.position = position;
    }
}
