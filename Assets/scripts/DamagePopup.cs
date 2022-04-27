using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DamagePopup : MonoBehaviour
{
    private TextMeshPro damagePopupText;
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
    }

    // Update is called once per frame
    private void Setup(int damageAmount)
    {
        damagePopupText.SetText(damageAmount.ToString());
    }

    private void Update()
    {
        float moveYSpeed = 8f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

    }

}
