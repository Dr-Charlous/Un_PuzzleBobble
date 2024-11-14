using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2 GridSize;
    public float BobbleSize;
    public float Offset;

    private void Start()
    {
        GridSize = new Vector2(Mathf.Abs(GameManager.Instance.WallLeft.position.x) + Mathf.Abs(GameManager.Instance.WallRight.position.x), Mathf.Abs(GameManager.Instance.WallUp.position.y) + Mathf.Abs(GameManager.Instance.Chara.transform.position.y));
    }

    private void OnDrawGizmosSelected()
    {
        if (GameManager.Instance != null)
        {
            Vector2 numberBobbles = new Vector2(Mathf.Round(GridSize.x / (BobbleSize * 2)), Mathf.Round((GridSize.y / (BobbleSize * 2)) - Offset));

            for (int y = 0; y < numberBobbles.y; y++)
            {
                for (int x = 0; x < numberBobbles.x; x++)
                {
                    if (y % 2 == 0)
                        Gizmos.DrawWireSphere(new Vector2(GameManager.Instance.WallLeft.position.x + BobbleSize * 2 * x, GameManager.Instance.WallUp.position.y - BobbleSize * 2 * y), BobbleSize);
                    else
                        Gizmos.DrawWireSphere(new Vector2(GameManager.Instance.WallLeft.position.x + BobbleSize * 2 * x + BobbleSize, GameManager.Instance.WallUp.position.y - BobbleSize * 2 * y), BobbleSize);
                }
            }
        }
    }
}
