using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public static WeaponDisplay instance;

    [SerializeField] private SpriteRenderer activeSprite;
    public Image[] weaponSprites;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);

            Debug.LogWarning("There was more than one WeaponDisplay in the scene");
        }
        instance = this;
        weaponSprites[0].sprite = activeSprite.sprite;
        weaponSprites[0].color = activeSprite.color;
    }
    public void UpdateSelectedWeapon(int index, Sprite sprite)
    {
        for (int i = 0; i < weaponSprites.Length; i++)
        {
            activeSprite.sprite = sprite;

            if (i == index)
            {
                // Set the alpha of the selected weapon to 1
                Color selectedAlpha = weaponSprites[i].color;
                selectedAlpha.a = 1f;
                weaponSprites[i].color = selectedAlpha;
            }
            else if (weaponSprites[index] != null)
            {
                // Set the alpha of all other weapons to 0.5
                Color inactiveAlpha = weaponSprites[i].color;
                inactiveAlpha.a = 0.25f;
                weaponSprites[i].color = inactiveAlpha;
            }
        }
    }
}
