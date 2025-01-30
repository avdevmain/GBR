using Fusion;
using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;

namespace GooglyEyesGames.PlayMaker.Fusion
{

	[ActionCategory("Fusion")]
    [Tooltip("Used with a SessionInfo Scriptable Object generated from 'FusionGetSessionListAsArray'.")]
    public class FusionGetSessionInfo : FsmStateAction
	{
        [RequiredField]
        [ObjectType(typeof(SessionInfoScriptableObject))]
        public FsmObject session;

        [UIHint(UIHint.Variable)]
        public FsmBool isOpen;

        [UIHint(UIHint.Variable)]
        public FsmBool isValid;

        [UIHint(UIHint.Variable)]
        public FsmBool isVisible;

        [UIHint(UIHint.Variable)]
        public FsmInt maxPlayers;

        [UIHint(UIHint.Variable)]
        public FsmString name;

        [UIHint(UIHint.Variable)]
        public FsmInt playerCount;

        [UIHint(UIHint.Variable)]
        [ArrayEditor(VariableType.String)]
        [Tooltip("Each array entry is a key/value pair.")]
        public FsmArray properties;

        [UIHint(UIHint.Variable)]
        public FsmString region;


        public override void Reset()
        {
            session = null;
        }
        public override void OnEnter()
        {

            SessionInfoScriptableObject s = session.Value as SessionInfoScriptableObject;
            isOpen.Value = s.isOpen;
            isValid.Value = s.isValid;
            isVisible.Value = s.isVisible;
            maxPlayers.Value = s.maxPlayers;
            name.Value = s.sessionName;
            playerCount.Value = s.playerCount;


            properties.Clear();
            properties.Resize(s.sessionProperties.Length);

            for (int i = 0; i < s.sessionProperties.Length; i++)
            {
                properties.Set(i, s.sessionProperties[i]);
            }

            region.Value = s.region;

            Finish();
        }

    }

}
