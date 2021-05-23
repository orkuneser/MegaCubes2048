using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float pushForce;
    [SerializeField] private float cubeMaxPosX;
    [Space]
    [SerializeField] private TouchSlider touchSlider;

    private Cube mainCube;

    private bool isPointerDown;
    private bool canMove;
    private Vector3 cubePositions;

    private void Start()
    {
        SpawnCube();
        canMove = true;

        // Listen to slider events:
        touchSlider.OnPointerDownEvent += OnPointerDown;
        touchSlider.OnPointerDragEvent += OnPointerDrag;
        touchSlider.OnPointerUpEvent += OnPointerUp;
    }

    private void Update()
    {
        if (isPointerDown)
        {
            mainCube.transform.position = Vector3.Lerp(mainCube.transform.position,cubePositions,moveSpeed*Time.deltaTime);
        }
    }

    private void OnPointerUp()
    {
        if (isPointerDown)
        {
            isPointerDown = false;
            canMove = false;

            // Push the cube:
            mainCube.cubeRigidbody.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);

            Invoke("SpawnNewCube", 0.3f);

        }
    }

    private void OnPointerDrag(float value)
    {
        if (isPointerDown)
        {
            cubePositions = mainCube.transform.position;
            cubePositions.x = value*cubeMaxPosX;
        }
    }

    private void OnPointerDown()
    {
        isPointerDown = true;
    }

    private void SpawnNewCube()
    {
        mainCube.isMainCube = false;
        canMove = true;
        SpawnCube();
    }
    private void SpawnCube()
    {
        mainCube = CubeSpawner.Instance.SpawnRandom();
        mainCube.isMainCube = true;

        // reset cubePositions variable
        cubePositions = mainCube.transform.position;
    }
    private void OnDestroy()
    {
        // remove listeners:
        touchSlider.OnPointerDownEvent -= OnPointerDown;
        touchSlider.OnPointerDragEvent -= OnPointerDrag;
        touchSlider.OnPointerUpEvent -= OnPointerUp;
    }
}
