using GameEngine.Base;
using UnityEngine;

namespace GameEngine.Scripts.Base.SaveLoadGame
{
    public abstract class DataRepository<T>
    {
        protected abstract string Key { get; }

        protected bool LoadData(out T data)
        {
            if (PlayerPrefs.HasKey((this.Key)))
            {
                data = PlayerPreferences.Load<T>(this.Key);
                return true;
            }

            data = default;
            return false;
        }

        protected virtual void SaveData(T data)
        {
            PlayerPreferences.Save<T>(this.Key, data);
        }

        public virtual void RemoveData()
        {
            PlayerPreferences.Remove(Key);
        }
    }
}