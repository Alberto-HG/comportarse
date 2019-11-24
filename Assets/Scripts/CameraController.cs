using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {
    public float speed = 10;
    public float zoomSpeed = 10;

    void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float zoom = Input.mouseScrollDelta.y;

        if (horizontal != 0f) {
            if (horizontal > 0f && transform.localPosition.z > -100f - horizontal * speed * Time.deltaTime) {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - horizontal * speed * Time.deltaTime);
            }

            if (horizontal < 0f && transform.localPosition.z < 100f - horizontal * speed * Time.deltaTime) {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - horizontal * speed * Time.deltaTime);
            }
        }

        if (vertical != 0f) {
            if (vertical > 0f && transform.localPosition.x < 125f - vertical * speed * Time.deltaTime) {
                transform.localPosition = new Vector3(transform.localPosition.x + vertical * speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
            }

            if (vertical < 0f && transform.localPosition.x > -100f - vertical * speed * Time.deltaTime) {
                transform.localPosition = new Vector3(transform.localPosition.x + vertical * speed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
            }
        }

        if (zoom != 0f) {
            if (zoom > 0 && transform.localPosition.y > 0 + zoom * zoomSpeed * Time.deltaTime) {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - zoom * zoomSpeed * Time.deltaTime, transform.localPosition.z);
            }

            if (zoom < 0 && transform.localPosition.y < 50 + zoom * zoomSpeed * Time.deltaTime) {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - zoom * zoomSpeed * Time.deltaTime, transform.localPosition.z);
            }
        }
    }

    public void Volver() {
        SceneManager.LoadScene(0);
    }
}
