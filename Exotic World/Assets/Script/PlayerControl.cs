using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControl : MonoBehaviour
{
    private Camera cam;
    public LayerMask movementMask;
    public PlayerMotor motor;

    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    private void Update()
    {
        onLeftClick();
        onRightClick();
    }

    // When LeftButton is Clicked, go to the point clicked.
    private void onLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000, movementMask))
            {
                Debug.Log(hit.point);
                Debug.Log(hit.collider.name);
                motor.MoveToPoint(hit.point);
                // stop focusing any object 
            }
        }
    }

    // When RightButton is Clicked, focus on the object if interactable.
    private void onRightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // interact withe the object
            }
        }
    }
}