using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CQS.Properties;
using CQS.TCGA.Microarray;
using RCPA.Gui.Command;
using CQS.BreastCancer;
using CQS.FileTemplate;
using CQS.Genome.Cuffdiff;
using CQS.Genome.Mirna;
using CQS.Genome.Annotation;
using CQS.Sample;

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
