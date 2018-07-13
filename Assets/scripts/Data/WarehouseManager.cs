using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


namespace Data
{
    public class WarehouseManager : IDisposable
    {
        bool disposed = false;
        public void NewWarehouse()
        {
            StringBuilder builder = new StringBuilder("saveData_");
            builder.Append(DateTime.Now.ToShortDateString());

            string saveName = builder.ToString();

            DataBox box = new DataBox(saveName);


            //Character 끌어오기
            var myChar = Database.G.GetCharacter(CharacterBaseCollection.ECharacterType.Warrior);
            
            //Database.G.GetCharacter()
            CharacterData data = new CharacterData(myChar);
            box.Add(data);
            //data.characterCur.HP
            //box.Add();
            DataWarehouse.G.SetCurrentBox(box);
        }

        public DataBox CurrentBox
        { get { return DataWarehouse.G.GetCurrentBox(); } }

        private void SaveData()
        {

        }

        private void LoadData()
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
            }

            disposed = true;
        }
    }

}

