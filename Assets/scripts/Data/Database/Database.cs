
using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : SingleMono<Database> {

    CharacterBaseCollection characterDatas = null;
    MonsterBaseCollection monsterDatas = null;
    private void Init()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    private void Awake()
    {
        Init();
        characterDatas = new CharacterBaseCollection();
        monsterDatas = new MonsterBaseCollection();
    }

    public CharacterBase GetCharacter(CharacterBaseCollection.ECharacterType type)
    {
        return characterDatas.Get(type);
    }

    public MonsterBaseCollection GetMonstarDatas()
    {
        return monsterDatas;
    }
}
