using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f;

    private Vector2 movement;

    void Update() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY);

        transform.position += moveSpeed * Time.deltaTime * (Vector3)movement;
    }
}