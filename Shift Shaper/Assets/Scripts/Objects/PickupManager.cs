using UnityEngine;

public class PickupManager : MonoBehaviour {
    [SerializeField] public Transform holdingSpot;
    [SerializeField] public GameObject currentObjectHeld;
    // Start is called before the first frame update
    void Start() {

    }


    void Update() {
        // Detect if the player clicks the left mouse button
        if (Input.GetMouseButtonDown(0)) {
            // Create a ray from the camera to the point where the mouse clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Check if the ray hit an object
            if (hit.collider != null) {
                // Check if the object has the tag "Pickable"
                print(hit.collider.name);
                if (hit.collider.CompareTag("Pickable") && !currentObjectHeld) {
                    hit.collider.gameObject.GetComponent<Pickable>().HandlePickUp();
                    currentObjectHeld = hit.collider.gameObject;
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && currentObjectHeld) {
            currentObjectHeld.GetComponent<Pickable>().HandleRelease();
            currentObjectHeld = null;
        }
    }
}
