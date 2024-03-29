﻿using SampSharp.Entities.SAMP;

using Torcidas.Core.Components.Server;

namespace Torcidas.Application.Services.Interfaces
{
    public interface IFpsService
    {
        void OnPlayerSpawnHandler(Player player);
        void OnPlayerUpdateHandler(ServerConfigComponent serverConfigComponent);

    }
}
