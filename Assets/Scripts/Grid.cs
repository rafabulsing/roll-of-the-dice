using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private int[,] gridArray;
    private float cellSize;
    private TextMesh[,] debugTextArray;

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder) {
        var obj = new GameObject("World_Text", typeof(TextMesh));
        var transform = obj.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        var textMesh = obj.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    public Grid(int width, int height, float cellSize) {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int i=0; i<gridArray.GetLength(0); i++) {
            for (int j=0; j<gridArray.GetLength(1); j++) {
                debugTextArray[i, j] = CreateWorldText(null, gridArray[i,j].ToString(), GetWorldPosition(i, j) + new Vector3(cellSize, cellSize) / 2, 20, Color.white, TextAnchor.MiddleCenter, TextAlignment.Center, 1);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i, j + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(i, j), GetWorldPosition(i + 1, j), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize;
    }

    public void SetValue(int x, int y, int value) {
        if (x >= 0 && x < width && y >= 0 && y < height) {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = value.ToString();
        }
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y) {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }

    public void SetValue(Vector3 worldPosition, int value) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y) {
        if (x >= 0 && x < width && y >= 0 && y < height) {
            return gridArray[x, y];
        }
        return -1;
    }

    public int GetValue(Vector3 worldPosition) {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
