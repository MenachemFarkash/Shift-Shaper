using UnityEngine;

public class Machine : MonoBehaviour {
    public GameObject[] objectsInMachine;
    // Start is called before the first frame update
    void Start() {
        objectsInMachine = new GameObject[2];
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Pickable")) {
            print("pickable");
            if (collision.GetComponent<Pickable>().isPickedUp == false) {
                if (objectsInMachine[0] == null) {
                    objectsInMachine[0] = collision.gameObject;
                    collision.gameObject.SetActive(false);
                } else if (objectsInMachine[1] == null) {
                    objectsInMachine[1] = collision.gameObject;
                    collision.gameObject.SetActive(false);
                } else {
                    print("No Place In Machine");
                }
            }
        }
    }
}
