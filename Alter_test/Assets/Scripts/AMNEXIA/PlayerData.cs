using System;


namespace Scripts.Dislexia
{
    [Serializable]
    class PlayerData // clase que creamos para poder guardar en JSON serializando.
    {
        public int score = 5;
        public  int lives = 3;
        public int level = 1;
        public string name = "UNO";
        public PlayerData(int score) // no hereda de monobehaviour, así que las clase necesita un constructor
        {
            // hay que poner aqui las variablespara que se guarden las del juego
            this.score = score; // this es= a 'class Scripts.Dislexia.PlayerData'
        }

    }  
}