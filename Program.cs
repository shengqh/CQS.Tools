using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CQS.Genome.Annotation;
using CQS.Genome.Bed;
using CQS.Genome.Cuffdiff;
using CQS.Genome.Fastq;
using CQS.Genome.Gtf;
using CQS.Genome.Mapping;
using CQS.Genome.Mirna;
using CQS.Genome.Pileup;
using CQS.Genome.Sam;
using CQS.Genome.SmallRNA;
using CQS.Properties;
using CQS.TCGA;
using CQS.Tools;
using RCPA.Gui.Command;
using RCPA.Utils;
using CQS.Genome.QC;
using CQS.Genome.Tophat;
using CQS.Genome.Bacteria.Rockhopper;
using CQS.Genome.Depth;

namespace CQS
{
  internal static class Program
  {
    private const int AttachParentProcess = -1;

    [DllImport("kernel32.dll")]
    private static extern bool AttachConsole(int dwProcessId);

    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args)
    {
      var commands = new ICommandLineCommand[]
      {
        new MirnaCountProcessorCommand(),
        new TCGATreeBuilderCommand(),
        new TCGADataDownloaderCommand(),
        new FastqLengthDistributionBuilderCommand(),
        new AlignmentResultCleanerCommand(),
        new IdenticalQueryBuilderCommand(),
        new CuffdiffSignificantFileMergerCommand(),
        new FileDefinitionBuilderCommand(),
        new AnnovarGenomeSummaryRefinedResultBuilderCommand(),
        new AnnovarSummaryBamDistillerCommand(),
        new ReadGroupTrackingExtractorCommand(),
        new TCGADatatableBuilderCommand(),
        new Bam2FastqProcessorCommand(),
        new MirnaMappedOverlapBuilderCommand(),
        new DataTableBuilderCommand(),
        new GtfGeneIdGeneNameMapBuilderCommand(),
        new PileupCountBuilderCommand(),
        new MirnaDataTableBuilderCommand(),
        new MappedCountProcessorCommand(),
        new MappedCountTableBuilderCommand(),
        new MappedPositionBuilderCommand(),
        new Gtf2BedGeneIdBuilderCommand(),
        new Bed2FastaProcessorCommand(),
        new SmallRNACategoryBuilderCommand(),
        new SmallRNACategoryGroupBuilderCommand(),
        new AnnovarResultMultipleToOneBuilderCommand(),
        new DistinctMappedReadProcessorCommand(),
        new ParalyzerClusterAnnotatorCommand(),
        new FastqTrimmerCommand(),
        new BamSummaryBuilderCommand(),
        new TophatSummaryBuilderCommand(),
        new FastqDemultiplexProcessorCommand(),
        new RockhopperSummaryBuilderCommand(),
        new AlleleCountBuilderCommand(),
        new DepthProcessorCommand(),
        new ChromosomeCountProcessorCommand(),
        new ChromosomeCountTableBuilderCommand()
      }.ToDictionary(m => m.Name.ToLower());

      if (!SystemUtils.IsLinux && args.Length == 0)
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var mainForm = new MainForm();
        foreach (var command in commands.Values)
        {
          if (command is IToolCommand)
          {
            mainForm.AddCommand(command as IToolCommand);
          }
        }

        Application.Run(mainForm);
      }
      else
      {
        if (!SystemUtils.IsLinux)
        {
          AttachConsole(AttachParentProcess);
        }

        ICommandLineCommand command;
        if (args.Length == 0)
        {
          ShowUsage(commands);
        }
        else if (commands.TryGetValue(args[0].ToLower(), out command))
        {
          try
          {
            if (command.Process(args.Skip(1).ToArray()))
            {
              Console.WriteLine("Done!");
            }
          }
          catch (Exception ex)
          {
            Console.Error.WriteLine("Failed : " + ex.StackTrace);
          }
        }
        else
        {
          Console.WriteLine("Error command " + args[0] + ".");
          ShowUsage(commands);
        }
      }
    }

    private static void ShowUsage(Dictionary<string, ICommandLineCommand> commands)
    {
      Console.WriteLine(Constants.GetSqhVanderbiltTitle(ThisAssembly.Title, ThisAssembly.Version));
      Console.WriteLine("Those commands are available :");
      (from c in commands.Values
        orderby c.Name
        select "\t" + c.Name + "\t" + c.Description).ToList().ForEach(Console.WriteLine);
    }
  }
}