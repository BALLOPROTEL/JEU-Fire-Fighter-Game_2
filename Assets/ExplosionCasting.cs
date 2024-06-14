using UnityEngine;

public class ExplosionCasting : MonoBehaviour
{
    public GameObject explosionPrefab;
    public Transform castPoint;
    public float explosionRadius = 5f;
    public Animator animator;
    public string explosionTriggerName = "ExplosionTrigger";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Touche E pour déclencher l'explosion
        {
            TriggerExplosion();
        }
    }

    void TriggerExplosion()
    {
        Debug.Log("TriggerExplosion function called, setting trigger");
        // Activer l'animation de l'explosion
        animator.SetTrigger(explosionTriggerName);
    }

    // Cette fonction sera appelée par l'événement d'animation
    public void ExecuteExplosion()
    {
        Debug.Log("ExecuteExplosion function called");

        // Instancier l'explosion au CastPoint
        if (explosionPrefab != null && castPoint != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, castPoint.position, castPoint.rotation);
            Debug.Log("Explosion instantiated at position: " + castPoint.position);

            // Détruire l'explosion après une durée spécifique pour éviter les fuites de mémoire
            Destroy(explosion, 2.0f);
        }
        else
        {
            Debug.LogError("Explosion prefab or cast point is not assigned.");
        }

        // Ajouter une logique pour l'effet de l'explosion si nécessaire (par exemple, infliger des dégâts aux ennemis proches)
    }
}
