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

    [Header("Components :")]
    public Bobble ActualBobble;
    public CharaController Chara;
    public Grid GridBobbles;
    public FallingWall Wall;
    public UiManager Ui;
    public ComboManager Combo;

    [Header("Values :")]
    public bool IsGamePause = false;

    [Header("Walls :")]
    public Transform WallUp;
    public Transform WallRight;
    public Transform WallLeft;

    [Header("Score :")]
    [SerializeField] int _score = 0;
    [SerializeField] int _scorePerBobblesPosed = 10;

    private void Update()
    {
        CheckBobble();
    }

    public void KillPalyer()
    {
        IsGamePause = true;
        Debug.Log("You die");
    }

    void CheckBobble()
    {
        if (ActualBobble.transform.position.y >= WallUp.position.y)
        {
            ActualBobble.IsMoving = false;
            ActualBobble.IsArrived = true;
            ActualBobble.Align(ActualBobble.transform.position);

            AddScore(_scorePerBobblesPosed);
        }

        if (ActualBobble.IsArrived)
            ActualBobble = Chara.ActualBobble;
    }

    public void AddScore(int score)
    {
        _score += score;
        Ui.UpdateText("Score : " + _score);
    }

    public void AddScore()
    {
        _score += _scorePerBobblesPosed;
        Ui.UpdateText("Score : " + _score);
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
}
