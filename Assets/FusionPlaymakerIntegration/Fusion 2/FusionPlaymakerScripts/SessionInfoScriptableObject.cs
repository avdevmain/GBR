using UnityEngine;

namespace GooglyEyesGames.PlayMaker.Fusion
{
    public class SessionInfoScriptableObject : ScriptableObject
    {
        public bool isOpen;
        public bool isValid;
        public bool isVisible;
        public int maxPlayers;
        public string sessionName;
        public int playerCount;
        public string region;

        public string[] sessionProperties;
    }
}

