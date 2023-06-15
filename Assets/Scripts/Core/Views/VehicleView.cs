using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleView : MonoBehaviour
{
    [SerializeField] Rigidbody2D _frontTireRB;
    [SerializeField] Rigidbody2D _backTireRB;
    [SerializeField] Rigidbody2D _carRB;
    [SerializeField] float _speed;
    [SerializeField] float _rotationSpeed;

    public Rigidbody2D FrontTireRB => _frontTireRB;
    public Rigidbody2D BackTireRB => _backTireRB;
    public Rigidbody2D CarRB => _carRB;
    public float Speed => _speed;
    public float RotationSpeed => _rotationSpeed;
}
