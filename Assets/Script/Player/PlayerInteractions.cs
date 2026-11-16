using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    RaycastHit hit;
    InputSystem_Actions input;

    void Start()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Ray interactRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(interactRay, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Interactable>())
            {
                //here: make pointer in HUD grow like in hn

                if (input.Player.Interact.WasPressedThisFrame())
                {
                    hit.transform.gameObject.GetComponent<Interactable>().Interact();
                }
            }

        }
    }
}
