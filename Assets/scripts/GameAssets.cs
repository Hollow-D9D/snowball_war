using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _assets;
    // Start is called before the first frame update
    public static GameAssets assets {
        get
        {
            if (_assets == null) _assets = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _assets;
        }
    }
    public Transform pfDamagePopup;
    public Transform pfReloadCircle;
}
