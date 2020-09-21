﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis.Tools.MSBuild;

namespace Microsoft.CodeAnalysis.Tools.Tests.Utilities
{
    /// <summary>
    /// This test fixture ensures that MSBuild is loaded.
    /// </summary>
    public sealed class MSBuildFixture : IDisposable
    {
        private static int s_registered;

        public static string MSBuildPath { get; private set; }


        public void RegisterInstance()
        {
            if (Interlocked.Exchange(ref s_registered, 1) == 0)
            {
                var msBuildInstance = Build.Locator.MSBuildLocator.QueryVisualStudioInstances().First();

                MSBuildPath = msBuildInstance.MSBuildPath;

                LooseVersionAssemblyLoader.Register(MSBuildPath);
                Build.Locator.MSBuildLocator.RegisterInstance(msBuildInstance);
            }
        }

        public void Dispose()
        {
        }
    }
}
