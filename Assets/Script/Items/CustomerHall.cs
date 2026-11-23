using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerHall : Interactable
{
    public TextMeshPro txtBox1;
    public TextMeshPro txtBox2;
    public TextMeshPro txtBox3;

    [Serialize]
    public List<Ingredient> ordersPool;
    public List<Ingredient> orders;
    public List<bool> ordersStatus;
    public Ingredient completed;

    private void Start()
    {
        UpdateCustomer();
    }

    protected override void Update()
    {
        base.Update(); //run parent update

        
    }

    protected override void ExecuteInteraction(PlayerInteractions playerHand)
    {
        for (int i = 0; i < orders.Count; i++)
        {
            if (playerHand.heldObj && playerHand.heldObj.GetComponent<Ingredient>().itemID == orders[i].itemID)
            {
                
                

                //TODO: give money

                ordersStatus[i] = true;
                orders[i] = completed;
                UpdateCustomer();
                Destroy(playerHand.heldObj);
                return;
            }
        }
    }

    void UpdateCustomer()
    {
        bool isDone = false;

        for (int i = 0; i < ordersStatus.Count; i++)
        {
            if (ordersStatus[i]) isDone = true;
            else
            {
                isDone = false;
                break;
            }
        }

        //reset customer once completed
        if (isDone)
        {
            orders = new List<Ingredient>();
            ordersStatus = new List<bool>();

            for (int i = 0; i < 3; i++) //TODO: cambiar el 3 por la posibilidad de menos pedidios
            {
                orders.Add(ordersPool[Random.Range(0, orders.Count)]);
            }

            for (int i = 0; i < orders.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        txtBox1.text = orders[i].itemTitle;
                        break;
                    case 1:
                        txtBox2.text = orders[i].itemTitle;
                        break;
                    case 2:
                        txtBox3.text = orders[i].itemTitle;
                        break;
                }
            }

            for (int i = 0; i < orders.Count; i++)
            {
                ordersStatus.Add(false);
            }
        }
    }
}
