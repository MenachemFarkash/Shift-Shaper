using UnityEngine;

public class Pickable : MonoBehaviour {
    public Transform holdingSpot;
    public Transform droppingSpot;
    public bool isPickedUp = false;
    public bool isInMachine = false;

    void Update() {
        if (isPickedUp)
            transform.position = holdingSpot.position;
    }

    public void HandlePickUp() {
        isPickedUp = true;
        holdingSpot = PlayerManager.instance.player.GetComponent<PickupManager>().holdingSpot.transform;
        transform.position = holdingSpot.position;
        transform.parent = holdingSpot;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void HandleRelease() {
        transform.parent = null;
        isPickedUp = false;
        transform.position = PlayerManager.instance.player.transform.position;
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
}
