using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;

public class EnvironmentSpawner : MonoBehaviour
{
    public UnityEvent<Vector3> OnSpawn { get; private set; } = new();

    [SerializeField] SpriteShapeController _spriteShapeController;

    [SerializeField, Range(3, 100)] int _levelLength = 50;
    [SerializeField, Range(1f, 50f)] float _xMultiplier = 2f;
    [SerializeField, Range(1f, 50f)] float _yMultiplier = 2f;
    [SerializeField, Range(0f, 1f)] float _curveSmoothness = .5f;
    [SerializeField] float _bottom = 10f;

    [SerializeField, Range(10f, 50f)] float _distanceToSpawn = 30f;
    [SerializeField, Range(10, 100)] int _stepToIncreaseLength = 70;

    private Transform _player;

    private float _noiseStep;
    private Vector3 _lastPos;
    private Vector3 _lastPoint;

    private void Start()
    {
        _player = FindObjectOfType<MoveController>().transform;

        _noiseStep = Random.Range(0f, 5f);
        GenerateRandomShape();
    }

    private void Update()
    {
        if (Vector3.Distance(_player.position, _lastPoint) < _distanceToSpawn)
        {
            _levelLength += _stepToIncreaseLength;
            GenerateRandomShape();
            OnSpawn.Invoke(new Vector3(_lastPoint.x, _lastPoint.y - 3.5f));

        }
    }

    private void GenerateRandomShape()
    {
        _spriteShapeController.spline.Clear();

        for (int i = 0; i < _levelLength; i++)
        {
            _lastPos = transform.position + new Vector3(i * _xMultiplier, Mathf.PerlinNoise(0, i * _noiseStep) * _yMultiplier);
            _spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i != 0 && i != _levelLength - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }
        }

        _lastPoint = new Vector3(_lastPos.x, transform.position.y);
        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, transform.position.y - _bottom));
        _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(transform.position.x, transform.position.y - _bottom));
    }
}
