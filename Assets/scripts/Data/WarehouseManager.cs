using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


namespace Data
{
    public class WarehouseManager : MonoBehaviour
    {

        private void NewWarehouse()
        {
            StringBuilder builder = new StringBuilder("saveData_");
            builder.Append(DateTime.Now.ToShortDateString());

            string saveName = builder.ToString();

            DataBox box = new DataBox(saveName);
            DataWarehouse.G.SetCurrentBox(box);
        }


        private void SaveData()
        {

        }

        private void LoadData()
        {

        }
    }

}

