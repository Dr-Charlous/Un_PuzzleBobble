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

    public bool IsArrived = false;
    public bool IsMoving = false;

    [SerializeField] Colors _colorBobble;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;

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
}
