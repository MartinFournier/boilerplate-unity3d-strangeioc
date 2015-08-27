using strange.extensions.context.impl;
using Game.Controllers;
using UnityEngine;

namespace Game
{
    static class GameBindings
    {
        internal static void MapBindings(MVCSContext context)
        {
            //Commands & Signals
            context.commandBinder.Bind<GameStartSignal>().To<GameStartCommand>();

            //Singleton signals
            //injectionBinder.Bind<PlayerMovedSignal>().ToSingleton();

            //Models
            //injectionBinder.Bind<IPlayer>().To<Player>().ToSingleton();

            //Mediation
            //mediationBinder.Bind<LevelSceneView>().To<LevelSceneMediator>();

            //Services
            //injectionBinder.Bind<ILevelGenerator>().To<SpecificLevelGenerator>();
        }

        internal static void PostBindings(MVCSContext context)
        {
            var contextView = (context.contextView as GameObject);
            var camera = contextView.GetComponentInChildren<UnityEngine.Camera>();
            context.injectionBinder.Bind<UnityEngine.Camera>().ToValue(camera);

            var configs = contextView.GetComponentInChildren<GameConfigs>();
            context.injectionBinder.Bind<GameConfigs>().ToValue(configs);
        }

    }
}

