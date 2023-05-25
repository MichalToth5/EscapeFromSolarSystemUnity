using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private HealthBar healthBar;
    private PlayerMovement playerMovement;
    private Attack attack;
    public AudioSource useItemSound;
 

    [System.Serializable]
    public class InventorySlot
    {
        public bool isUsed;
        public PickupObjectType objectType;
        public RawImage texture;
    }

    public List<InventorySlot> slots = new List<InventorySlot>();

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        playerMovement = GetComponent<PlayerMovement>();
        attack = GetComponent<Attack>();
    }


    public bool AddItemToInventory(PickupObjectType type)
    {
        if (type != null)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (slots[i].isUsed == false)
                {

                    if (type == PickupObjectType.CHEST)
                    {
                        slots[i].isUsed = true;
                        slots[i].texture.enabled = true;
                        slots[i].texture.texture = ResData.Gui.chest01;
                        slots[i].objectType = type;
                    }
                    if (type == PickupObjectType.BOTTLE)
                    {
                        slots[i].isUsed = true;
                        slots[i].texture.enabled = true;
                        slots[i].texture.texture = ResData.Gui.bottle01;
                        slots[i].objectType = type;
                    }
                    if (type == PickupObjectType.KEY)
                    {
                        slots[i].isUsed = true;
                        slots[i].texture.enabled = true;
                        slots[i].texture.texture = ResData.Gui.key01;
                        slots[i].objectType = type;
                    }
                    if(type == PickupObjectType.SPEEDBOOTS)
                    {
                        slots[i].isUsed = true;
                        slots[i].texture.enabled = true;
                        slots[i].texture.texture = ResData.Gui.speedBoots01;
                        slots[i].objectType = type;
                    }
                    if (type == PickupObjectType.TRAMPOLINE)
                    {
                        slots[i].isUsed = true;
                        slots[i].texture.enabled = true;
                        slots[i].texture.texture = ResData.Gui.jumpBoost01;
                        slots[i].objectType = type;
                    }
                    return true;
                }
            }
        }

        return false;
    }

    public void RemoveFromInventory(int index)
    {
        if (index <= slots.Count)
        {
            if (slots[index].objectType == PickupObjectType.BOTTLE)
            {
                useItemSound.Play();
                if (healthBar.currentHealth < healthBar.maxHealth)
                {
                    healthBar.currentHealth++;
                    healthBar.healthSlider.value = healthBar.currentHealth;
                    slots[index].isUsed = false;
                    slots[index].texture.texture = null;
                    slots[index].texture.enabled = false;
                    slots[index].objectType = PickupObjectType.NONE;
                }
                else
                {
                    slots[index].isUsed = false;
                    slots[index].texture.texture = null;
                    slots[index].texture.enabled = false;
                    slots[index].objectType = PickupObjectType.NONE;
                }
                
            }

            if (slots[index].objectType == PickupObjectType.CHEST)
            {
                useItemSound.Play();
                attack.currentBullets += 5;
                attack.magazineSlider.value = attack.currentBullets;
                slots[index].isUsed = false;
                slots[index].texture.texture = null;
                slots[index].texture.enabled = false;
                slots[index].objectType = PickupObjectType.NONE;
            }

            if (slots[index].objectType == PickupObjectType.KEY)
            {
                //co sa ma stat ked sa vyhodi kluc + osetrit aby sa nemohol vyhodit mimo pouzitia
                slots[index].isUsed = false;
                slots[index].texture.texture = null;
                slots[index].texture.enabled = false;
                slots[index].objectType = PickupObjectType.NONE;
            }

            if(slots[index].objectType == PickupObjectType.SPEEDBOOTS)
            {
                useItemSound.Play();
                slots[index].isUsed = false;
                slots[index].texture.texture = null;
                slots[index].texture.enabled = false;
                slots[index].objectType = PickupObjectType.NONE;
                StartCoroutine(SpeedBoostCoroutine());               
            }

            if (slots[index].objectType == PickupObjectType.TRAMPOLINE)
            {
                useItemSound.Play();
                slots[index].isUsed = false;
                slots[index].texture.texture = null;
                slots[index].texture.enabled = false;
                slots[index].objectType = PickupObjectType.NONE;
                StartCoroutine(JumpForceCoroutine());
            }
        }
    }

    private IEnumerator SpeedBoostCoroutine()
    {
        playerMovement.speed = playerMovement.boostedSpeed;
        yield return new WaitForSeconds(10);
        playerMovement.speed = playerMovement.baseSpeed;
    }
    private IEnumerator JumpForceCoroutine()
    {
        playerMovement.jumpPower = playerMovement.boostedJumpPower;
        yield return new WaitForSeconds(10);
        playerMovement.jumpPower = playerMovement.baseJumpPower;
    }

    //?public bool[] isFull;
    //public GameObject[] slots;
}
