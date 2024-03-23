using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Pipeline {
    public class PipelineAdapter : IPipelineManager {
        private readonly ExternalPipelineAdapter _adaptee;
        public PipelineAdapter(ExternalPipelineAdapter adapter) { 
            _adaptee = adapter;
        }
        public void BuildSoftware() {
            Console.WriteLine($"'{this._adaptee.ExecuteRequest()}' Build software");
        }

        public void DeployToAzure() {
            Console.WriteLine($"'{this._adaptee.ExecuteRequest()}' Deploy to azure");
        }

        public void ExecuteTests() {
            Console.WriteLine($"'{this._adaptee.ExecuteRequest()}' Execute Tests");
        }

        public void InstallPackages() {
            Console.WriteLine($"'{this._adaptee.ExecuteRequest()}' Install Packages");
        }

        public void PerformUtilityActions() {
            Console.WriteLine($"'{this._adaptee.ExecuteRequest()}' Perform UtilityActions");
        }

        public void RetrieveSourceCode() {
            Console.WriteLine($"'{this._adaptee.ExecuteRequest()}' Retrieve Source Code");
        }

        public void RunCodeAnalysis() {
            Console.WriteLine($"'{this._adaptee.ExecuteRequest()}' Run Code Analysis");
        }
    }
}
