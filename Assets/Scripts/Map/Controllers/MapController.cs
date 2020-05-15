using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapController : IMapController
{
    private readonly TileMapView _tilemapView;
    private readonly ITeamPointStorage _teamPointStorage;
    private readonly ITeamStorage _teamStorage;

    public MapController(TileMapView tilemapView) 
    {
        _tilemapView = tilemapView;
        _tilemapView.CompressMap();
    }

    public List<Vector3> GetTeamTiles(TileBase teamTile)
    {
        int sizeX = _tilemapView.TileMap.origin.x +  _tilemapView.TileMap.size.x;
        int sizeY = _tilemapView.TileMap.origin.y +  _tilemapView.TileMap.size.y;    

        Vector3Int tmpCoords = new Vector3Int();

        List<Vector3> teamTiles = null;

        for (int i=_tilemapView.TileMap.origin.x; i<sizeX; i++)
        {
            for (int y=_tilemapView.TileMap.origin.y; y<sizeY; y++)
            {
                tmpCoords.x = i;
                tmpCoords.y = y;

                var tile = _tilemapView.TileMap.GetTile(tmpCoords);

                if (tile == teamTile)
                {
                    if (teamTiles == null)
                        teamTiles = new List<Vector3>();

                    teamTiles.Add(_tilemapView.TileMap.GetCellCenterWorld(tmpCoords));
                }
            }
        }
        
        return teamTiles;
    }

    public bool isSameCell(Vector3 pos1, Vector3 pos2)
    {
        Vector3Int cellCoord1 = _tilemapView.TileMap.WorldToCell(pos1);
        Vector3Int cellCoord2 = _tilemapView.TileMap.WorldToCell(pos2);

        return cellCoord1.Equals(cellCoord2);
    }

    public Vector3 GetCellCenterPoint(Vector3 worldPosition)
    {
        Vector3Int cellCoord = _tilemapView.TileMap.WorldToCell(worldPosition);
        return _tilemapView.TileMap.GetCellCenterWorld(cellCoord);   
    }
}
