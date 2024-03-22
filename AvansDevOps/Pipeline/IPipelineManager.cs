using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline {
    public interface IPipelineManager {
        public void RetrieveSourceCode();
        public void InstallPackages();
        public void BuildSoftware();
        public void ExecuteTests();
        public void RunCodeAnalysis();
        public void DeployToAzure();
        public void PerformUtilityActions();
    }
}
