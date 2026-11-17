using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    RaycastHit hit;
    InputSystem_Actions input;
    public GameObject heldObj;
    public float throwStrength = 5f;

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

                if (input.Player.Attack.WasPressedThisFrame())
                {
                    hit.transform.gameObject.GetComponent<Interactable>().Interact(this);
                }
            }
        }

        if (input.Player.Throw.WasPressedThisFrame() && heldObj)
        { 
            //drop items
            heldObj.GetComponent<Interactable>().Drop(this, throwStrength);
        }
    }
}
