using System;
using UnityEngine;
using Object = UnityEngine.Object;

public static class Cells
{
    private static Grid _grid;

    public static void Initialize(GridLayout.CellLayout layout, Vector3 cellSize, Vector3 cellGap, GridLayout.CellSwizzle swizzle)
    {
        if (!Application.isPlaying)
            throw new Exception("This class must be used only in play mode");
            
        var go = new GameObject("Static_TechnicalGrid");
            
        Object.DontDestroyOnLoad(go);
        go.hideFlags = HideFlags.HideAndDontSave;
            
        var grid = go.AddComponent<Grid>();

        grid.cellLayout = layout;
        grid.cellSize = cellSize;
        grid.cellGap = cellGap;
        grid.cellSwizzle = swizzle;

        _grid = grid;
    }

    public static Vector3Int WorldPosToCells(this Vector2 pos)
    {
        return _grid.WorldToCell(pos);
    }

    public static Vector2 CellToWorld_CentredCell(this Vector3Int cell)
    {
        return _grid.GetCellCenterWorld(cell);
    }
}