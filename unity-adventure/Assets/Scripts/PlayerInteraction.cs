using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 1.5f;
    public KeyCode interactKey = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);
        foreach (var hit in hits)
        {
            if (hit == null) continue;
            var interactable = hit.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.OnInteract(gameObject);
                return;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0.5f, 1f, 0.25f);
        Gizmos.DrawSphere(transform.position, interactRange);
    }
}
