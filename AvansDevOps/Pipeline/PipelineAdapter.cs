using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline {
    public class PipelineAdapter : IPipelineManager {
        public void BuildSoftware() {
            Console.WriteLine("Build software");
        }

        public void DeployToAzure() {
            Console.WriteLine("Deploy to azure");
        }

        public void ExecuteTests() {
            Console.WriteLine("Execute Tests");
        }

        public void InstallPackages() {
            Console.WriteLine("Install Packages");
        }

        public void PerformUtilityActions() {
            Console.WriteLine("Perform UtilityActions");
        }

        public void RetrieveSourceCode() {
            Console.WriteLine("Retrieve Source Code");
        }

        public void RunCodeAnalysis() {
            Console.WriteLine("Run Code Analysis");
        }
    }
}
