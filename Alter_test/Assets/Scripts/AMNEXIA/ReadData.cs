using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace Scripts.Dislexia
{
    public class ReadData : MonoBehaviour
    {

        const string JSONPATH = "data.json";


        private int gameScore = 0; // variable del juego.


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        // PARA CONECTAR CON PYTHON HAY QUE USAR RELFEXIÓN (wrapper) para que se comunique a través de c++

        public void SaveData()
        {
            Debug.Log("SET A BUTTON FOR TESTING");

            // crear objeto con sus variables
            PlayerData playerData = new PlayerData(gameScore);
            // crear json
            var jsonData = JsonUtility.ToJson(playerData);

            // llamar al metodo guardar los datos en json
            var path = Path.Combine(Application.dataPath, JSONPATH);
            File.WriteAllText(path, jsonData);

        }

        private void ReadJSON() // https://es.wikipedia.org/wiki/Serializaci%C3%B3n
        {
            var path = Path.Combine(Application.dataPath, JSONPATH);
            if (File.Exists(path))
            {
                var jsonText = File.ReadAllText(path);
                var playerData = JsonUtility.FromJson<PlayerData>(jsonText);
                gameScore = playerData.score;
            }
            else
            {
                gameScore = 0;
                Debug.LogError("JSON file not found");
            }
        }
    }
}