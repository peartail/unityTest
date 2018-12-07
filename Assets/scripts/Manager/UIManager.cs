using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface CUI
{
    Transform GetT();
}


public class UIManager : MonoBehaviour {

    private Transform root;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        i = this;
        root = gameObject.transform;
    }

    private static UIManager i = null;
    public static UIManager I { get { return i; } }



    private static readonly string uiDirPath = "UI/";
    private static readonly string extention = ".prefab";
    public static T GetUI<T>(string uiname = "")
    {
        using (AssetLoader loader = new AssetLoader())
        {
            if(uiname == "")
            {
                uiname = typeof(T).ToString();
            }
            var asset = loader.LoadAssetInstance<GameObject>(uiDirPath + uiname + extention);
            return asset.GetComponent<T>();
        }
    }

    public T OpenUI<T>(string uiname = "") where T : CUI
    {
        T data = GetUI<T>(uiname);
        if(data != null)
        {
            OpenUI(data);
        }

        return data;
    }

    public void OpenUI(CUI ui)
    {
        ui.GetT().SetParent(root,false);
    }

    public void CloseUI(CUI ui)
    {
        DestroyImmediate(ui.GetT().gameObject);
    }
}
