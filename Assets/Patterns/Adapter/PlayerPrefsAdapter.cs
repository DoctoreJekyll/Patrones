using UnityEngine;

namespace Patterns.Adapter
{
    // Adaptador para almacenar y recuperar datos utilizando PlayerPrefs
    public class PlayerPrefsAdapter : IDataStore
    {
        // Método para almacenar datos en PlayerPrefs
        public void SetData<T>(T data, string name)
        {
            // Convertir el objeto 'data' en una cadena JSON
            string json = JsonUtility.ToJson(data);

            // Almacenar la cadena JSON en PlayerPrefs asociada al nombre especificado
            PlayerPrefs.SetString(name, json);

            // Guardar los cambios en PlayerPrefs
            PlayerPrefs.Save();
        }

        // Método para recuperar datos de PlayerPrefs
        public T GetData<T>(string name)
        {
            // Obtener la cadena JSON almacenada en PlayerPrefs asociada al nombre especificado
            string json = PlayerPrefs.GetString(name);

            // Convertir la cadena JSON en un objeto de tipo 'T' utilizando la clase JsonUtility
            return JsonUtility.FromJson<T>(json);
        }
    }
}
