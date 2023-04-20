using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameController : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public int width = 8;
    public int height = 14;
    public Vector2 blockSize = new Vector2(1, 1);
    public int minimumConnectedBlocks = 3;
    public float specialBlockChance = 0.1f;
    public Color[] colors = new Color[6];

    private Block[,] blocks;
    private bool isRemovingBlocks;

    void Start()
    {
        blocks = new Block[width, height];
        RefillBlocks();
    }

    private bool IsEmpty(int x, int y)
    {
        return blocks[x, y] == null;
    }


    // ** �������� ����� �����ϰ�, Ư�� ��� Ȯ���� ���� �Ϲ� ��ϰ� Ư�� ����� �����մϴ�.
    private void RefillBlocks()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (blocks[x, y] == null)
                {
                    int randomPrefabIndex = UnityEngine.Random.Range(0, blockPrefabs.Length);
                    GameObject blockPrefab = blockPrefabs[randomPrefabIndex];
                    Vector2 position = GetBlockPosition(x, y);
                    GameObject newBlock = Instantiate(blockPrefab, position, Quaternion.identity, transform);

                    Block blockComponent = newBlock.GetComponent<Block>();
                    int randomColorIndex = UnityEngine.Random.Range(0, colors.Length);
                    blockComponent.SetColor(colors[randomColorIndex], randomColorIndex);

                    blocks[x, y] = blockComponent;
                }
            }
        }
    }

    // ** ���ο� �� ����
    private void CreateBlock(int x, int y)
    {
        int randomPrefabIndex = Random.Range(0, blockPrefabs.Length);
        Vector2 spawnPosition = new Vector2(x * blockSize.x, y * blockSize.y);
        GameObject newBlock = Instantiate(blockPrefabs[randomPrefabIndex], spawnPosition, Quaternion.identity);
        newBlock.transform.parent = transform;

        Block blockComponent = newBlock.GetComponent<Block>();
        int randomColorIndex = Random.Range(0, colors.Length);
        blockComponent.SetColor(colors[randomColorIndex], randomColorIndex);
        blockComponent.blockType = (UnityEngine.Random.value < specialBlockChance) ? Block.BlockType.Special : Block.BlockType.Normal;

        blocks[x, y] = blockComponent;
    }

    private Vector2 GetBlockPosition(int x, int y)
    {
        return new Vector2(x * blockSize.x, y * blockSize.y);
    }

    private int GetConnectedBlocks(int x, int y, int type, bool isSpecial, List<Block> connectedBlocks)
    {
        // �̹� üũ�� ���� ����
        if (connectedBlocks.Contains(blocks[x, y])) return 0;

        // ���� ������ ���� �ƴϸ� ����
        if (blocks[x, y] == null || blocks[x, y].type != type || blocks[x, y].blockType != BlockType.Special) return 0;

        // ���� üũ�� �� ����Ʈ�� �߰�
        connectedBlocks.Add(blocks[x, y]);

        // ���� ������ �����¿��� ������ üũ
        int count = 1;
        count += GetConnectedBlocks(x, y + 1, type, isSpecial, connectedBlocks);
        count += GetConnectedBlocks(x, y - 1, type, isSpecial, connectedBlocks);
        count += GetConnectedBlocks(x - 1, y, type, isSpecial, connectedBlocks);
        count += GetConnectedBlocks(x + 1, y, type, isSpecial, connectedBlocks);

        return count;
    }

    private void RemoveConnectedBlocks(int x, int y, int type, bool isSpecial)
    {
        // ���� ���� ���� ����, ���� Ư�� ���� ���� ������ ��� ����
        if (blocks[x, y] != null && blocks[x, y].type == type && blocks[x, y].blockType == isSpecial)
        {
            Destroy(blocks[x, y].gameObject);
            blocks[x, y] = null;
        }

        if (x > 0) RemoveConnectedBlocks(x - 1, y, type, isSpecial);
        if (x < width - 1) RemoveConnectedBlocks(x + 1, y, type, isSpecial);
        if (y > 0) RemoveConnectedBlocks(x, y - 1, type, isSpecial);
        if (y < height - 1) RemoveConnectedBlocks(x, y + 1, type, isSpecial);
    }

    private IEnumerator ShiftBlocksDown()
    {
        bool blocksShifted = false;

        for (int x = 0; x < width; x++)
        {
            for (int y = 1; y < height; y++)
            {
                if (blocks[x, y] != null && blocks[x, y - 1] == null)
                {
                    blocks[x, y - 1] = blocks[x, y];
                    blocks[x, y] = null;
                    blocks[x, y - 1].transform.position = GetBlockPosition(x, y - 1);
                    blocksShifted = true;
                }
            }
        }

        yield return new WaitForSeconds(0.1f);

        if (blocksShifted)
        {
            StartCoroutine(ShiftBlocksDown());
        }
        else
        {
            RefillBlocks();
            isRemovingBlocks = false;
        }
    }

    private void ExecuteSpecialFunction()
    {
        // �� �Լ��� ���߿� �ʿ��� ������� ä������ �� �ֽ��ϴ�.
    }

    void Update()
    {
        if (isRemovingBlocks) return;

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x = Mathf.FloorToInt(mouseWorldPosition.x / blockSize.x);
            int y = Mathf.FloorToInt(mouseWorldPosition.y / blockSize.y);

            if (x >= 0 && x < width && y >= 0 && y < height && blocks[x, y] != null)
            {
                List<Block> connectedBlocks = new List<Block>();
                int connectedCount = GetConnectedBlocks(x, y, blocks[x, y].type, blocks[x, y].blockType, connectedBlocks);

                if (connectedCount >= minimumConnectedBlocks)
                {
                    isRemovingBlocks = true;
                    RemoveConnectedBlocks(x, y, blocks[x, y].type, blocks[x, y].blockType);
                    if (blocks[x, y].blockType)
                    {
                        ExecuteSpecialFunction();
                    }
                    StartCoroutine(ShiftBlocksDown());
                }
            }
        }
    }
}
public enum BlockType
{
    Normal,
    Special,
    // �߰����� ��� Ÿ�Ե� (��: PowerUp, Bomb ��)
}

[System.Serializable]
public class Block : MonoBehaviour
{
    public int type;
    public BlockType BlockType;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetColor(Color color, int colorIndex)
    {
        spriteRenderer.color = color;
        type = colorIndex;
    }
}
