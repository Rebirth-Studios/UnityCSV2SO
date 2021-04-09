using Sirenix.OdinInspector;
using UnityCSV2SO.PrimitiveData;
using UnityEngine;

namespace UnityCSV2SO
{
    /// <summary>
    /// Inherit CSV data scriptable objects from this class.
    /// </summary>
    public abstract class CSVPopulableScriptableObject : ScriptableObject
    {
#if UNITY_EDITOR
        //TextAsset for the relevant CSV file.
        [SerializeField] private TextAsset CSV;
        [SerializeField] public string assetPath;
        /// <summary>
        /// Key from which to read data.
        /// </summary>
        public abstract string CSVKey { get; }

        public abstract void UpdateSelf(ScriptableObject refToUpdate, ScriptableObject newValues);

        /// <summary>
        /// Editor button that populates CSV data into appropriate fields.
        /// </summary>
        [Button("Populate CSV")]
        public void PopulateFromCSV()
        {
            if (CSV == null)
            {
                Debug.LogError("No CSV!");
                return;
            }
            CSVReader.SetFile(CSV);
            PrimitiveDataDictionary dictionary;

            if (CSVReader.TryGetPrimitiveDictionary(CSVKey, out dictionary))
            {
                // PopulateDataFromOneRow<>(dictionary);
            }
            else
            {
                string[] keys = new string[CSVReader._CSVDictionaries.Keys.Count];
                CSVReader._CSVDictionaries.Keys.CopyTo(keys, 0);
                Debug.LogError("Couldn't find data!" + keys[0]);
                return;
            }
        }
    
    
        public T PopulateDataFromOneRow<T>(string[] valuesAsStrings, string[] keys, ref T reference) where T : ScriptableObject
        {
            var returnVal = CreateInstance<T>();

            for (int i = 0; i < valuesAsStrings.Length; i++)
            {
                if (valuesAsStrings[0] == "" && valuesAsStrings[1] == "") return returnVal;
                SetValue<T>(valuesAsStrings[i], keys[i], ref reference);  
            }
            return returnVal;
        }

        protected abstract void SetValue<T>(string value, string key, ref T reference);

#endif
    }
}