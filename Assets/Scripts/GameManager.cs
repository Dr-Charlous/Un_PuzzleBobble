using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("2 GameManager");
    }
    #endregion Singleton

    public Bobble ActualBobble;
    public CharaController Chara;
    public Transform WallUp;
    public Transform WallRight;
    public Transform WallLeft;

    private void Update()
    {
        KillPalyer();
        CheckBobble();
    }

    void KillPalyer()
    {
        if (ActualBobble.transform.position.y <= Chara.transform.position.y)
            Debug.Log("You die");
    }

    void CheckBobble()
    {
        if (ActualBobble.transform.position.y >= WallUp.position.y)
        {
            ActualBobble.IsMoving = false;
            ActualBobble.IsArrived = true;
        }

        if (ActualBobble.IsArrived)
            ActualBobble = Chara.ActualBobble;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3[] points = new Vector3[8];

        points[0] = new Vector2(WallLeft.position.x, WallUp.position.y);
        points[1] = new Vector2(WallRight.position.x, WallUp.position.y);
        points[2] = new Vector2(WallRight.position.x, WallUp.position.y);
        points[3] = new Vector2(WallRight.position.x, Chara.transform.position.y);
        points[4] = new Vector2(WallRight.position.x, Chara.transform.position.y);
        points[5] = new Vector2(WallLeft.position.x, Chara.transform.position.y);
        points[6] = new Vector2(WallLeft.position.x, Chara.transform.position.y);
        points[7] = new Vector2(WallLeft.position.x, WallUp.position.y);

        Gizmos.DrawLineList(points);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3[] points = new Vector3[4];

        points[0] = new Vector2(WallLeft.position.x, WallUp.position.y);
        points[1] = new Vector2(WallRight.position.x, WallUp.position.y);
        points[2] = new Vector2(WallRight.position.x, Chara.transform.position.y);
        points[3] = new Vector2(WallLeft.position.x, Chara.transform.position.y);

        Gizmos.DrawLineList(points);
    }
}
