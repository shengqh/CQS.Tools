﻿using CQS.Genome.Annotation;
using CQS.Genome.Bacteria.Rockhopper;
using CQS.Genome.Bed;
using CQS.Genome.CNV;
using CQS.Genome.Cuffdiff;
using CQS.Genome.Database;
using CQS.Genome.Depth;
using CQS.Genome.Fastq;
using CQS.Genome.Gtf;
using CQS.Genome.Gwas;
using CQS.Genome.Mapping;
using CQS.Genome.Mirna;
using CQS.Genome.Parclip;
using CQS.Genome.Pileup;
using CQS.Genome.Plink;
using CQS.Genome.QC;
using CQS.Genome.Quantification;
using CQS.Genome.Sam;
using CQS.Genome.SmallRNA;
using CQS.Genome.Tophat;
using CQS.Genome.Vcf;
using CQS.Microarray;
using CQS.Properties;
using CQS.TCGA;
using CQS.Tools;
using RCPA;
using RCPA.Commandline;
using RCPA.Gui.Command;
using RCPA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
        //new MirnaCountProcessorCommand(),
        new TCGATreeBuilderCommand(),
        new TCGADataDownloaderCommand(),
        new GseMatrixDownloaderCommand(),
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
        //new MirnaMappedOverlapBuilderCommand(),
        new DataTableBuilderCommand(),
        new GtfGeneIdGeneNameMapBuilderCommand(),
        new PileupCountBuilderCommand(),
        //new MirnaDataTableBuilderCommand(),
        new MappedCountProcessorCommand(),
        new MappedCountTableBuilderCommand(),
        new MappedPositionBuilderCommand(),
        new Gtf2BedGeneIdBuilderCommand(),
        new Bed2FastaProcessorCommand(),
        new SmallRNACategoryGroupBuilderCommand(),
        new AnnovarResultMultipleToOneBuilderCommand(),
        new DistinctMappedReadProcessorCommand(),
        new ParalyzerClusterAnnotatorCommand(),
        new BamSummaryBuilderCommand(),
        new TophatSummaryBuilderCommand(),
        new FastqDemultiplexProcessorCommand(),
        new RockhopperSummaryBuilderCommand(),
        new AlleleCountBuilderCommand(),
        new DepthProcessorCommand(),
        new ChromosomeCountProcessorCommand(),
        new ChromosomeCountTableBuilderCommand(),
        new MirnaNonTemplatedNucleotideAdditionsQueryBuilderCommand(),
        new TrnaNonTemplatedNucleotideAdditionsQueryBuilderCommand(),
        new TGIRTCountProcessorCommand(),
        //new MirnaNTACountTableBuilderCommand(),
        new MappedReadBuilderCommand(),
        new Impute2ResultDistillerCommand(),
        new SmallRNADatabaseBuilderCommand(),
        new SmallRNACountProcessorCommand(),
        new SmallRNACountTableBuilderCommand(),
        new PlinkStrandFlipProcessorCommand(),
        new SmallRNAUnmappedReadBuilderCommand(),
        new HTSeqCountToFPKMCalculatorCommand(),
        new ParclipSmallRNAT2CBuilderCommand(),
        new ParclipSmallRNATargetBuilderCommand(),
        new FastQCSummaryBuilderCommand(),
        new BamCleanerCommand(),
        new SmallRNASequenceCountTableBuilderCommand(),
        new SeedTargetBuilderCommand(),
        new BedSorterOptionsCommand(),
        new VcfSlimProcessorCommand(),
        new VcfGenotypeTableBuilderCommand(),
        new VcfFilterProcessorCommand(),
        new GvcfValidationProcessorCommand(),
        new ValidFastqExtractorCommand(),
        new SmallRNAT2CMutationSummaryBuilderCommand(),
        new DatabaseReorderProcessorCommand(),
        new SmallRNABamInfoFixerCommand(),
        new SamExtractorCommand(),
        new SequenceCountTableBuilderCommand(),
        new CnMOPSCallProcessorCommand()
      }.ToDictionary(m => m.Name.ToLower());

      SoftwareInfo.SoftwareName = CQSToolsAssembly.Name;
      SoftwareInfo.SoftwareVersion = CQSToolsAssembly.Version;

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

        //Console.WriteLine("Current system = " + SystemUtils.CurrentSystem.ToString());

        ICommandLineCommand command;
        if (args.Length == 0)
        {
          ShowUsage(commands);
        }
        else if (commands.TryGetValue(args[0].ToLower(), out command))
        {
          if (command.Process(args.Skip(1).ToArray()))
          {
            Console.WriteLine("Done!");
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
      Console.WriteLine(Constants.GetSqhVanderbiltTitle(CQSToolsAssembly.Title, CQSToolsAssembly.Version));
      Console.WriteLine("Those commands are available :");
      (from c in commands.Values
       orderby c.Name
       select "\t" + c.Name + "\t" + c.Description).ToList().ForEach(Console.WriteLine);
    }
  }
}