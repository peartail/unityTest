using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : SingleMono<Database> {

    CharacterBaseCollection characterDatas;
    private void Init()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    private void Awake()
    {
        Init();
        characterDatas = new CharacterBaseCollection();
        
    }

    public CharacterBase GetCharacter(CharacterBaseCollection.ECharacterType type)
    {
        return characterDatas.Get(type);
    }
}
