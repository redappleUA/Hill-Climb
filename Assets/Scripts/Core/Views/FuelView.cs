using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelView : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] float _fillingFuelAmount;
    public float FillingFuelAmount => _fillingFuelAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FuelController.instance.FillFuel(FillingFuelAmount);
            Destroy(gameObject);
        }
    }
}
