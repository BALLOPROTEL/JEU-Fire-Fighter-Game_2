using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerController : MonoBehaviour
{
    public GameObject flameThrowerPrefab;
    public Transform castPoint;
    public float spellDuration = 2.0f;

    private GameObject activeFlameThrower;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) // Touche G pour déclencher le lance-flammes
        {
            if (activeFlameThrower == null)
            {
                ActivateFlameThrower();
            }
        }

        if (Input.GetKeyUp(KeyCode.G)) // Relâcher la touche G pour arrêter le lance-flammes
        {
            if (activeFlameThrower != null)
            {
                DeactivateFlameThrower();
            }
        }
    }

    void ActivateFlameThrower()
    {
        activeFlameThrower = Instantiate(flameThrowerPrefab, castPoint.position, castPoint.rotation);
        activeFlameThrower.transform.parent = castPoint; // Assurer que le lance-flammes suive le personnage
    }

    void DeactivateFlameThrower()
    {
        Destroy(activeFlameThrower);
    }
}
