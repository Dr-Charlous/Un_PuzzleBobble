using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWall : MonoBehaviour
{
    public float TimerDuration = 20;
    public int Turns = 0;

    Vector3 _initialePosition;
    float _timer;

    private void Start()
    {
        Initialize();
    }

    void Initialize()
    {
        _initialePosition = transform.position;
        _timer = TimerDuration;
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGamePause)
        {
            if (_timer >= 0)
                _timer -= Time.deltaTime;
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - GameManager.Instance.GridBobbles.BobbleSize * 2, transform.position.z);
                Turns++;
                _timer = TimerDuration;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(5, 0.5f));
    }
}
