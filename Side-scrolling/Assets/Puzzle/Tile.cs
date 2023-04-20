using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color color; // Ÿ�� ����
    private Vector2 position; // Ÿ�� ��ǥ
    private float size; // Ÿ�� ũ��
    private Sprite sprite; // Ÿ�� ��������Ʈ
    private GameObject gameObject; // Ÿ�� ���� ������Ʈ

    public Tile(Vector2 position, float size, Sprite sprite)
    {
        this.position = position;
        this.size = size;
        this.sprite = sprite;

        // Ÿ�� ���� ������Ʈ ����
        gameObject = new GameObject();
        gameObject.name = "Tile";
        gameObject.transform.position = position;
        gameObject.transform.localScale = new Vector3(size, size, 1f);
        gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.SetActive(true);

        // Ÿ�� ���� ���� ����
        Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };
        color = colors[Random.Range(0, colors.Length)];
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
    public void MoveTo(Vector2 position, float duration)
    {
        // Ÿ�� �̵� �ִϸ��̼� �ڷ�ƾ ����
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
