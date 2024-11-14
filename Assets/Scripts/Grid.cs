using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Vector2 _gridSize;
    [SerializeField] float _bobbleSize;

    private void Start()
    {
        _gridSize = new Vector2(Mathf.Abs(GameManager.Instance.WallLeft.position.x) + Mathf.Abs(GameManager.Instance.WallRight.position.x), Mathf.Abs(GameManager.Instance.WallUp.position.y) + Mathf.Abs(GameManager.Instance.Chara.transform.position.y));
    }

    private void OnDrawGizmos()
    {
        if (GameManager.Instance != null)
        {
            Vector2 numberBobbles = new Vector2(Mathf.Round(_gridSize.x / (_bobbleSize * 2)), Mathf.Round(_gridSize.y / (_bobbleSize * 2)));

            for (int y = 0; y < numberBobbles.y; y++)
            {
                for (int x = 0; x < numberBobbles.x; x++)
                {
                    if (y % 2 == 0)
                        Gizmos.DrawWireSphere(new Vector2(GameManager.Instance.WallLeft.position.x + _bobbleSize * 2 * x, GameManager.Instance.WallUp.position.y - _bobbleSize * 2 * y), _bobbleSize);
                    else
                        Gizmos.DrawWireSphere(new Vector2(GameManager.Instance.WallLeft.position.x + _bobbleSize * 2 * x + _bobbleSize, GameManager.Instance.WallUp.position.y - _bobbleSize * 2 * y), _bobbleSize);
                }
            }
        }
    }
}
