using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        textCaching = new Dictionary<eData, TextAsset>();
        i = this;
    }

    private static GameDataManager i = null;
    public static GameDataManager I { get { return i; } }

    enum eData
    {
        MonsterBase,
        CharacterBase,
    }

    Dictionary<eData, TextAsset> textCaching;

  
    
    public TextAsset GetData(string path)
    {
        using (AssetLoader loader = new AssetLoader())
        {
            var asset = loader.Load<TextAsset>(path);
            return asset;
        }
    }
   
}
