using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform castPoint;
    public float fireballSpeed = 10f;
    public Animator animator;
    public string castSpellTriggerName = "CastSpellTrigger";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) // Touche T pour déclencher le sort
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        // Activer l'animation de lancer de sort
        animator.SetTrigger(castSpellTriggerName);
    }

    // Cette fonction sera appelée par l'événement d'animation
    public void ShootFireball()
    {
        Debug.Log("ShootFireball called"); // Ajouter un log pour vérifier si la fonction est appelée

        // Instancier la boule de feu au CastPoint
        GameObject fireball = Instantiate(fireballPrefab, castPoint.position, castPoint.rotation);

        // Vérifier si le Rigidbody est présent, sinon l'ajouter
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = fireball.AddComponent<Rigidbody>();
        }
        rb.velocity = castPoint.forward * fireballSpeed;

        // Détruire la boule de feu après 2 secondes pour éviter les fuites de mémoire
        Destroy(fireball, 2.0f);
    }
     
}
