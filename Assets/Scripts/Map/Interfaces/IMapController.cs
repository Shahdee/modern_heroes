using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IMapController 
{
    List<Vector3> GetTeamTiles(TileBase teamTile);

    bool isSameCell(Vector3 pos1, Vector3 pos2);
}
