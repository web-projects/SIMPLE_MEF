using Devices.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devices.Sdk.Features
{
    public interface IAppWorkflowFeature : IFeature
    {
        string GetAvailableStateActions();
    }
}
