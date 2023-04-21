using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ColorYype
{
    Red,
    Green,
    Blue,
    Yellow,
    Purple,
    Orange
}

public enum BlockType
{
    Regular,
    Special,
    Additional
}

public class BlockGameController : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public int width = 8;
    public int height = 14;
    public Vector2 blockSize = new Vector2(1, 1);
    public int minimumConnectedBlocks = 3;
    public float specialBlockChance = 0.1f;

    private Vector3 offset;


    /*
    private Block selectedBlock;
    private Vector3 initialBlockPosition;
    private Vector2Int initialBlockCoord;
     */

    private Block selectedBlock;
    private Vector2 initialMousePosition;
    private Vector2Int initialBlockCoord;


    private Block[,] blocks;
    private bool isRemovingBlocks;

    void Start()
    {
        blocks = new Block[width, height];
        offset = new Vector3((blockSize.x * width) * .5f, (blockSize.y * height) * .5f);
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
                if (IsEmpty(x, y))
                {
                    CreateBlock(x , y);
                }
            }
        }
    }

    // ** ���ο� �� ����
    private void CreateBlock(int x, int y)
    {
        int randomblock = Random.Range(0, blockPrefabs.Length);
        GameObject blockObject = Instantiate(blockPrefabs[randomblock], GetBlockPosition(x - (int)offset.x, y - (int)offset.y + 3), Quaternion.identity, transform);
        blockObject.name = "Block_" + (y * 8 + x).ToString();

        Block block = blockObject.GetComponent<Block>();
        block.SetColor((ColorYype)Random.Range(0, 6));
        block.type = Random.value < specialBlockChance ? BlockType.Special : BlockType.Regular;
        blocks[x, y] = block;
    }
    private Vector2 GetBlockPosition(int x, int y)
    {
        return new Vector2(x * blockSize.x, y * blockSize.y);
    }

    private Block BlockPicking()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject != null)
            {
            }
            print(hit.transform.gameObject);    
        }

        Block block = new Block();


        return block;
    }




    /*

    private int GetConnectedBlocks(int x, int y, ColorYype colorType, BlockType blockType, List<Block> connectedBlocks)
    {
        if (x < 0 || x >= width || y < 0 || y >= height || blocks[x, y] == null || connectedBlocks.Contains(blocks[x, y]))
        {
            return 0;
        }

        if (blocks[x, y].colortype != colorType || blocks[x, y].type != blockType)
        {
            return 0;
        }

        connectedBlocks.Add(blocks[x, y]);

        int count = 1;
        count += GetConnectedBlocks(x, y + 1, colorType, blockType, connectedBlocks);
        count += GetConnectedBlocks(x, y - 1, colorType, blockType, connectedBlocks);
        count += GetConnectedBlocks(x - 1, y, colorType, blockType, connectedBlocks);
        count += GetConnectedBlocks(x + 1, y, colorType, blockType, connectedBlocks);

        return count;
    }

    // ** ���� ���� ���� ����, ���� Ư�� ���� ���� ������ ��� ����
    private void RemoveConnectedBlocks(int x, int y, ColorYype colorType, BlockType blockType)
    {

        List<Block> connectedBlocks = new List<Block>();
        GetConnectedBlocks(x, y, colorType, blockType, connectedBlocks);

        if (connectedBlocks.Count >= minimumConnectedBlocks)
        {
            foreach (Block block in connectedBlocks)
            {
                int blockX = (int)(block.transform.position.x / blockSize.x);
                int blockY = (int)(block.transform.position.y / blockSize.y);
                blocks[blockX, blockY] = null;
                Destroy(block.gameObject);
            }

            isRemovingBlocks = true;
            StartCoroutine(ShiftBlocksDown());
        }
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
        // ** �� �Լ��� ���߿� Ư������ ������� ä������ �� �ֽ��ϴ�.
        print("Ư�����");
    }

    private Vector2 beginPoint;
    private Vector2 endPoint;

    */
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BlockPicking();
            /*
            beginPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("beginPoint : " + beginPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("endPoint : " + endPoint);
             */
        }
    }
}