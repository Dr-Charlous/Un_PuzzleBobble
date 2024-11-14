using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobble : MonoBehaviour
{
    public enum Colors
    {
        Grey,
        Blue,
        Green,
        Orange,
        Violet,
        Red,
        Yellow
    }

    public Colors ColorBobble;
    public bool IsArrived = false;
    public bool IsMoving = false;

    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;

    bool _isAline = false;

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (IsMoving)
        {
            if (transform.position.x < GameManager.Instance.WallLeft.position.x || transform.position.x > GameManager.Instance.WallRight.position.x)
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -transform.eulerAngles.z));
            }

            transform.position += transform.up * _speed * Time.deltaTime;
        }
    }

    public void Align(Vector3 pos)
    {
        if (pos.y > transform.position.y)
            transform.position = new Vector2(Mathf.Round(transform.position.x), pos.y - GameManager.Instance.GridBobbles.BobbleSize * 2);
        else
            transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bobble bobble = collision.GetComponentInParent<Bobble>();

        if (bobble != null && bobble.gameObject != gameObject && !_isAline)
        {
            IsMoving = false;
            IsArrived = true;

            Align(bobble.transform.position);

            var x = (int)Mathf.Round(transform.position.x);
            var y = (int)(transform.position.y / GameManager.Instance.GridBobbles.BobbleSize * 2);

            GameManager.Instance.Combo.CleanLists();
            GameManager.Instance.Combo.GridBobblesPositions[10+x, 10+y] = this;
            var result = GameManager.Instance.Combo.CheckNeighbours(x, y, 1, ColorBobble);

            Debug.Log(result);
            GameManager.Instance.AddScore(result);
            _isAline = true;
        }
    }
}
