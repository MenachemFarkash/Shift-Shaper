using UnityEngine;

public class Machine : MonoBehaviour {
    public GameObject[] objectsInMachine;
    public Transform screen1;
    public Transform screen2;
    public Transform screen3Output;

    public float scaleDownFactor = 0.2f;
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
                    PlaceObjectOnScreen(1, collision.gameObject);
                } else if (objectsInMachine[1] == null) {
                    PlaceObjectOnScreen(2, collision.gameObject);
                } else {
                    print("No Place In Machine");
                }
            }
        }
    }

    public void PlaceObjectOnScreen(int screenNumber, GameObject newObject) {
        if (screenNumber == 1) {
            objectsInMachine[0] = newObject;
            //newObject.transform.localScale -= new Vector3(scaleDownFactor, scaleDownFactor, scaleDownFactor);
            newObject.transform.position = screen1.position;
            return;
        }

        if (screenNumber == 2) {
            objectsInMachine[1] = newObject;
            //newObject.transform.localScale -= new Vector3(scaleDownFactor, scaleDownFactor, scaleDownFactor);
            newObject.transform.position = screen2.position;
            return;
        }
    }
}
