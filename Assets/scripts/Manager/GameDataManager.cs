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

    private static readonly string monsterdb = "Data/MonsterBase.bytes";
    private static readonly string characterdb = "Data/CharacterBase.bytes";
    public MonsterBaseData GetMonsterData()
    {
        using (AssetLoader loader = new AssetLoader())
        {
            var asset = loader.Load<TextAsset>(monsterdb);
        }

        return null;
    }
}
