using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using System;

namespace Game.Controllers
{
    public class GameStartCommand : Command
    {
        [Inject]
        public GameConfigs Configs { get; set; }

        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject ContextView{ get; set; }

        public override void Execute()
        {
            Debug.Log("Game was started");
            Debug.Log(
                String.Format("Config Value: {0}", Configs.BoilerplateValue));
        }
    }
}

