using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public Bobble[,] GridBobblesPositions = new Bobble[20,50];
    public bool[,] GridBobblesCheck = new bool[20, 50];

    private void Start()
    {
        var GridSize = GameManager.Instance.GridBobbles.GridSize;
        var BobbleSize = GameManager.Instance.GridBobbles.BobbleSize;
        var OffSet = GameManager.Instance.GridBobbles.Offset;

        Vector2 numberBobbles = new Vector2(Mathf.Round(GridSize.x / (BobbleSize * 2)), Mathf.Round((GridSize.y / (BobbleSize * 2)) - OffSet));
    }

    public void CleanLists()
    {
        GridBobblesCheck = null;
    }

    public int CheckNeighbours(int x, int y, int iteration, Bobble.Colors color)
    {
        if (GridBobblesPositions[x, y] == null || GridBobblesCheck[x, y] == true)
            return -1;

        if (GridBobblesPositions[x, y].ColorBobble != color)
            return -1;

        GridBobblesCheck[x, y] = true;

        var result = CheckNeighbours(x + 1, y, iteration++, color);
        if (result != -1 && iteration > 3)
        {
            Destroy(GridBobblesPositions[x, y].gameObject);
            GridBobblesPositions[x, y] = null;
            return result;
        }

        result = CheckNeighbours(x - 1, y, iteration++, color);
        if (result != -1 && iteration > 3)
        {
            Destroy(GridBobblesPositions[x, y].gameObject);
            GridBobblesPositions[x, y] = null;
            return result;
        }

        result = CheckNeighbours(x, y + 1, iteration++, color);
        if (result != -1 && iteration > 3)
        {
            Destroy(GridBobblesPositions[x, y].gameObject);
            GridBobblesPositions[x, y] = null;
            return result;
        }

        result = CheckNeighbours(x, y - 1, iteration++, color);
        if (result != -1 && iteration > 3)
        {
            Destroy(GridBobblesPositions[x, y].gameObject);
            GridBobblesPositions[x, y] = null;
            return result;
        }
        else
            return -1;
    }
}
