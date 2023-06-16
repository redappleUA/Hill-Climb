using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuelController : MonoBehaviour
{
    [SerializeField] FuelView _fuelView;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FuelController.instance.FillFuel(_fuelView.FillingFuelAmount);
            Destroy(gameObject);
        }
    }
}
