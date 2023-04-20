using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGroup : MonoBehaviour
{
    public List<Tile> tiles; // 매칭된 타일 리스트

    public TileGroup()
    {
        tiles = new List<Tile>();
    }

    public void AddTile(Tile tile)
    {
        tiles.Add(tile);
    }
}
