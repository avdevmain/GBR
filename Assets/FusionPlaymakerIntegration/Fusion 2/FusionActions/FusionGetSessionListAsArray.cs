using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [HutongGames.PlayMaker.Tooltip("Gets active sessions and stores them in an array.")]
    public class FusionGetSessionListAsArray : FsmStateAction
	{
        [RequiredField]
        [UIHint(UIHint.Variable)]
        [ArrayEditor(typeof(SessionInfoScriptableObject))]
        public FsmArray sessions;

        public override void Reset()
        {
            sessions = null;
        }
        public override void OnEnter()
        {
            sessions.Clear();
            sessions.Resize(0);

            foreach (SessionInfo session in PlaymakerFusionNetworkRunner.PFNR.sessions)
            {
                SessionInfoScriptableObject so = ScriptableObject.CreateInstance<SessionInfoScriptableObject>();
                so.isOpen = session.IsOpen;
                so.isValid = session.IsValid;
                so.isVisible = session.IsVisible;
                so.maxPlayers = session.MaxPlayers;
                so.playerCount = session.PlayerCount;
                so.sessionName = session.Name;
                so.region = session.Region;
                so.sessionProperties = new string[session.Properties.Count];

                for (int i = 0; i < session.Properties.Count; i++)
                {
                    string key = session.Properties.ElementAt(i).Key;
                    string value = session.Properties.ElementAt(i).Value;
                    string pair = key + "," + value;
                    so.sessionProperties.SetValue(pair, i);
                }

                sessions.Resize(sessions.Length + 1);
                sessions.Set(sessions.Length - 1, so);
            }
            Finish();
        }

    }

}
