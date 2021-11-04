using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]

public class HealthSO : ScriptableObject
{
    public delegate void OnHealthChange();


    public event UnityAction<float, PlayerController> healthChange;

    public void OnHealthChanges(float force, PlayerController player)
    {

        if (healthChange != null)
        {
            healthChange(force, player);
        }

    }
}
