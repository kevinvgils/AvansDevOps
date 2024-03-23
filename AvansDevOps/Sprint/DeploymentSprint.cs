using AvansDevOps.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.Sprint {
    public class DeploymentSprint : Sprint {
        private ExternalPipelineAdapter Adaptee = new();
        private IPipelineManager Adapter;
        public DeploymentSprint(string name) : base(name) {
            Name = name;
            Adapter = new PipelineAdapter(Adaptee);
        }

        public override void SprintEnded() {
            Console.WriteLine("Sprint Ended Starting Deployment...");
            Adapter.RetrieveSourceCode();
            Adapter.RunCodeAnalysis();
            Adapter.BuildSoftware();
            Adapter.ExecuteTests();
            Adapter.DeployToAzure();
        }
    }
}
