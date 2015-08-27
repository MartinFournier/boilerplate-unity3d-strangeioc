using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace Game.Controllers
{
    public class GameStartCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject ContextView{ get; set; }

        public override void Execute()
        {
            Debug.Log("Game was started");
        }
    }
}

