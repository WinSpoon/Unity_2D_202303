using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGroup : MonoBehaviour
{
    public List<Tile> tiles; // ��Ī�� Ÿ�� ����Ʈ

    public TileGroup()
    {
        tiles = new List<Tile>();
    }

    public void AddTile(Tile tile)
    {
        tiles.Add(tile);
    }
}
