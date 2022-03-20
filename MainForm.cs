using CQS.BreastCancer;
using CQS.FileTemplate;
using CQS.Properties;
using CQS.Sample;
using RCPA.Gui.Command;

namespace CQS.Tools
{
  public partial class MainForm : RCPA.Gui.Command.CommandForm
  {
    public static bool PublishVersion { get; set; }

    public MainForm()
    {
      InitializeComponent();

      this.Text = Constants.GetSqhVanderbiltTitle(CQSToolsAssembly.Title, CQSToolsAssembly.Version);

      //AddCommand(new MicroarrayDataSummaryBuilderUI.Command());

      AddCommand(new BreastCancerSampleItemDefinitionBuilderUI.Command());

      AddCommand(new BreastCancerSampleInformationBuilderUI.Command());

      AddCommand(new HeaderDefinitionBuilderUI.Command());

      AddCommand(new SampleInfoColumnDefinitionBuilderCommand());

      AddCommand(new SampleItemDefinitionBuilderUI.Command());

      AddCommand(new SampleInfoBuilderUI.Command());

      //AddCommand(new MiRNAToDNAConverterUI.Command());
    }
  }
}
