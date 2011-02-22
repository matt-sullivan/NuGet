using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using EnvDTE;

namespace NuGet.VisualStudio {
    public interface ISolutionManager {
        event EventHandler SolutionOpened;
        event EventHandler SolutionClosing;

        string SolutionDirectory { get; }

        string DefaultProjectName { get; set; }
        Project DefaultProject { get; }

        Project GetProject(string projectSafeName);

        //[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This is an expensive operation")]
        IEnumerable<Project> GetProjects();

        /// <summary>
        /// Get the safe name of the specified project which guarantees not to conflict with other projects.
        /// </summary>
        /// <remarks>
        /// It tries to return simple name if possible. Otherwise it returns the unique name.
        /// </remarks>
        string GetProjectSafeName(Project project);

        bool IsSolutionOpen { get; }
    }
}