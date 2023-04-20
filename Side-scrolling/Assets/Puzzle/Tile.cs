using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Color color; // Ÿ�� ����
    public Vector2 position; // Ÿ�� ��ǥ
    public Sprite sprite; // Ÿ�� ��������Ʈ
    public float size; // Ÿ�� ũ��
    //private GameObject gameObject; // Ÿ�� ���� ������Ʈ

    public Tile()
    {
        // Ÿ�� ���� ������Ʈ ����
        this.gameObject.name = "Tile";
        this.gameObject.transform.position = position;
        this.gameObject.transform.localScale = new Vector3(size, size, 1f);
        this.gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
        this.gameObject.AddComponent<BoxCollider2D>();
        this.gameObject.SetActive(true);

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
