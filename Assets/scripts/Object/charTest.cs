using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using UniRx;
using System.Text;

public class charTest : MonoBehaviour {

    public Text txtChar = null;
    public Button defBtn = null;
    private CharacterData data = null;
	// Use this for initialization
	void Start () {
         data = DataWarehouse.G.GetDataRX<CharacterData>();

        if(defBtn != null)
        {
            defBtn.onClick.AddListener(OnClickDefence);
        }

        if(txtChar != null)
        {
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("HP : {0} \n Energy : {1}", data.characterCur.HP, data.characterCur.Energy);
                txtChar.text = builder.ToString();
            }

            data.characterCur.Ob.Subscribe(x =>
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("HP : {0} \n Energy : {1}",x.HP,x.Energy);

                txtChar.text = builder.ToString();
            });
        }
	}
	
    public void OnClickDefence()
    {
        data.characterCur.HP -= 1;
    }
	
}
