using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DamagePopup : MonoBehaviour
{
    private TextMeshPro damagePopupText;
    private float disappearTimer; 
    private Color textColor;
    public static DamagePopup Create(Vector3 position, int damageAmount)
    {
        Transform popupTransform = Instantiate(GameAssets.assets.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = popupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);
        return damagePopup;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        damagePopupText = transform.GetComponent<TextMeshPro>();
        Debug.Log("hey");
    }

    // Update is called once per frame
    private void Setup(int damageAmount)
    {
        Debug.Log("hey");
        damagePopupText.SetText(damageAmount.ToString());
        disappearTimer = 1f;
    }

    private void Update()
    {
        float moveYSpeed = 8f;
        float dissapearSpeed = 3f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        { 
            textColor.a -= dissapearSpeed * Time.deltaTime;
            damagePopupText.color = textColor;
            if (textColor.a < 0)
            { 
                Destroy(gameObject);
            }    
        }
    }

}
