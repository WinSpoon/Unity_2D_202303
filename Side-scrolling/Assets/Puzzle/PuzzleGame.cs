using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGame : MonoBehaviour
{
    //public Transform parent;
    public int width = 20; // ���� �� ���� ����
    public int height = 20; // ���� �� ���� ����
    public float tileSize = 1f; // ���� Ÿ�� ũ��
    public Sprite[] tileSprites; // ���� Ÿ�� ��������Ʈ

    private Tile[,] tiles; // ���� �� Ÿ�� �迭
    private bool isShifting; // ���� ��Ī �� Ÿ�� �̵� ������ ����

    private void Start()
    {
        // ���� �� �ʱ�ȭ
        InitializeTiles();

        // �ʱ� ��Ī �˻�
        StartCoroutine(FindMatches());
    }

    private void InitializeTiles()
    {
        tiles = new Tile[width, height];

        // �� ��ǥ���� ������ ������ Ÿ�� ����
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject gameObject = new GameObject();
                Tile tile = gameObject.AddComponent<Tile>();
                tile.position = new Vector2(x * tileSize, y * tileSize);
                tile.sprite = tileSprites[Random.Range(0, tileSprites.Length)];
                tile.sprite = tileSprites[Random.Range(0, tileSprites.Length)];
                tile.size = tileSize;

                tile.transform.SetParent(transform);

                //tiles[x, y] = tile;
                //tiles[x, y].transform.SetParent(this.transform);
            }
        }
    }

    private IEnumerator FindMatches()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            List<TileGroup> matches = GetMatches();

            if (matches.Count > 0)
            {
                isShifting = true;
                yield return StartCoroutine(RemoveMatches(matches));
                yield return StartCoroutine(ShiftTilesDown());
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                isShifting = false;
                yield return null;
            }
        }
    }

    private List<TileGroup> GetMatches()
    {
        List<TileGroup> matches = new List<TileGroup>();

        // ���η� ��Ī �˻�
        for (int y = 0; y < height; y++)
        {
            int x = 0;
            while (x < width - 2)
            {
                if (tiles[x, y].color == tiles[x + 1, y].color && tiles[x + 1, y].color == tiles[x + 2, y].color)
                {
                    TileGroup group = new TileGroup();
                    group.AddTile(tiles[x, y]);
                    group.AddTile(tiles[x + 1, y]);
                    group.AddTile(tiles[x + 2, y]);
                    matches.Add(group);
                    x += 3;
                }
                else
                {
                    x++;
                }
            }
        }

        // ���η� ��Ī �˻�
        for (int x = 0; x < width; x++)
        {
            int y = 0;
            while (y < height - 2)
            {
                if (tiles[x, y].color == tiles[x, y + 1].color && tiles[x, y + 1].color == tiles[x, y + 2].color)
                {
                    TileGroup group = new TileGroup();
                    group.AddTile(tiles[x, y]);
                    group.AddTile(tiles[x, y + 1]);
                    group.AddTile(tiles[x, y + 2]);
                    matches.Add(group);
                    y += 3;
                }
                else
                {
                    y++;
                }
            }
        }

        return matches;
    }

    private IEnumerator RemoveMatches(List<TileGroup> matches)
    {
        foreach (TileGroup match in matches)
        {
            foreach (Tile tile in match.tiles)
            {
                // ��Ī�� Ÿ���� ��Ȱ��ȭ
                tile.gameObject.SetActive(false);
            }
        }

        yield return null;
    }

    private IEnumerator ShiftTilesDown()
    {
        for (int x = 0; x < width; x++)
        {
            int emptyCount = 0;
            for (int y = 0; y < height; y++)
            {
                if (tiles[x, y].gameObject.activeSelf == false)
                {
                    emptyCount++;
                }
                else if (emptyCount > 0)
                {
                    // �� Ÿ�� �Ʒ��� Ÿ�� �̵�
                    tiles[x, y - emptyCount] = tiles[x, y];
                    tiles[x, y] = null;
                    tiles[x, y - emptyCount].MoveTo(new Vector2(x * tileSize, (y - emptyCount) * tileSize), 0.1f);
                }
            }
        }

        yield return new WaitForSeconds(0.1f);

        // �� Ÿ�� ���ʿ� ������ Ÿ�� ����
        for (int x = 0; x < width; x++)
        {
            int emptyCount = 0;
            for (int y = 0; y < height; y++)
            {
                if (tiles[x, y] == null)
                {
                    Vector2 position = new Vector2(x * tileSize, (y + emptyCount) * tileSize);
                    Sprite sprite = tileSprites[Random.Range(0, tileSprites.Length)];
                    //Tile tile = new Tile(position, tileSize, sprite);
                    //tiles[x, y] = tile;
                    emptyCount++;
                }
            }
        }

        yield return null;
    }
}
