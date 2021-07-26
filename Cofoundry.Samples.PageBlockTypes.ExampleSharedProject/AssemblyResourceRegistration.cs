using Cofoundry.Core.ResourceFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cofoundry.Samples.PageBlockTypes.ExampleSharedProject
{
    /// <summary>
    /// Registers this assembly so that embedded resources (e.g. views/css/js) 
    /// can be picked up. No implementation is required, this is just a marker
    /// class that is automatically detected by Cofoundry.
    /// </summary>
    public class AssemblyResourceRegistration : IAssemblyResourceRegistration
    {
    }
}
