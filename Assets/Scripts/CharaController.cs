using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    public Bobble ActualBobble;

    [SerializeField] GameObject[] _bobblePrefabs;
    [Tooltip("The transform of rotating part")]
    [SerializeField] Transform _nillController;
    [SerializeField] Transform _previewPoint;
    [SerializeField] Transform _previewLaunchPoint;
    [Tooltip("Speed of rotation")]
    [SerializeField] float _speed = 1;

    Bobble _nextBobble;
    Vector3 _direction;
    bool _isShooting = false;

    private void Start()
    {
        var bobbleNext = Instantiate(_bobblePrefabs[Random.Range(0, _bobblePrefabs.Length)], _previewPoint.position, Quaternion.identity);
        _nextBobble = bobbleNext.GetComponent<Bobble>();

        var bobble = Instantiate(_bobblePrefabs[Random.Range(0, _bobblePrefabs.Length)], _nillController.position, Quaternion.identity);
        ActualBobble = bobble.GetComponent<Bobble>();

        GameManager.Instance.ActualBobble = ActualBobble;
    }

    private void Update()
    {
        Inputs();
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsGamePause)
        {
            Rotation();

            if (_isShooting)
                Shooting();
        }
    }

    #region Actions
    void Inputs()
    {
        _direction += Vector3.back * Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        //Max angle of rotation
        if (_direction.z > 80)
            _direction = new Vector3(_direction.x, _direction.y, 80);
        else if (_direction.z < -80)
            _direction = new Vector3(_direction.x, _direction.y, -80);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isShooting = true;
        }
    }

    void Rotation()
    {
        _nillController.rotation = Quaternion.Euler(_direction);
    }

    void Shooting()
    {
        if (ActualBobble != null && ActualBobble == GameManager.Instance.ActualBobble)
        {
            ActualBobble.transform.rotation = Quaternion.Euler(_direction);
            ActualBobble.transform.position = _previewLaunchPoint.position;
            ActualBobble.GetComponent<Bobble>().IsMoving = true;
            ActualBobble.transform.SetParent(GameManager.Instance.GridBobbles.transform);

            ActualBobble = _nextBobble;
            ActualBobble.transform.position = _nillController.transform.position;

            var bobble = Instantiate(_bobblePrefabs[Random.Range(0, _bobblePrefabs.Length)], _previewPoint.position, Quaternion.identity);
            _nextBobble = bobble.GetComponent<Bobble>();
        }

        _isShooting = false;
    }
    #endregion Actions

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_previewLaunchPoint.position, new Vector2(0.5f, 0.1f));
    }
}