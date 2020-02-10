CQS Bioinformatics Software Suite
==
* [Introduction](#Introduction)
* [Prerequisites](#Prerequisites)
* [Installation](#Installation)
* [Changes](#changes)

<a name="Introduction"/>

# Introduction

CQS bioinformatics software suite (cqstools) contains a bunch of tools used in genomics research, from preprocessing, format conversion, counting, summarizing to annotation, et al.

<a name="Prerequisites"/>

# Prerequisites

Although cqstools is developed by C#, it is majorly executed under linux through [mono] (https://github.com/mono/mono). So mono on your linux system is required for cqstools.
For people who doesn't have root permission to install mono, you may install mono into your own directory and add the bin directory of that installed directory into your path enviroment:

```
wget https://github.com/mono/mono/archive/mono-4.4.0.40.tar.gz
tar -xzvf mono-4.4.0.40.tar.gz
cd mono-mono-4.4.0.40
#here, I will install mono to my own directory /scratch/cqs/shengq1/mono4, change it to your directory
./autogen.sh --prefix=/scratch/cqs/shengq1/mono4 --with-large-heap=yes --with-ikvm-native=no --disable-shared-memory --enable-big-arrays
make get-monolite-latest
make EXTERNAL_MCS=${PWD}/mcs/class/lib/monolite/basic.exe
make install
```

<a name="Installation"/>

# Installation

User can download compiled version from [github](https://github.com/shengqh/CQS.Tools/releases). Download the file and decompress it to any folder you want, run "mono cqstools.exe" and have fun.

<a name="Changes"/>

# Changes

|Date|Version|Description|
|---|---|---|
|20200210| v1.8.10|Bugfix: compatible with lncRNA gene annotation file.|
|20200207| v1.8.9|Enhanced: compatible with lncRNA in hg38 gene annotation file.|
|20191017| v1.8.8|Enhanced: output absolute position file for rRNA/snoRNA and other smallRNA.|
|20191016| v1.8.7|Enhanced: output position file for other smallRNA.|
|20191015| v1.8.6|Bugfix: topFeature may be missed in smallRNATable read table.|
|20190917| v1.8.5|Enhanced: smallRNATable can export read table with corresponding features.|
|20190304| v1.8.4|Enhanced: smallRNATable can export tRNA only (for tRH analysis).|
|20181205| v1.8.3|Enhanced: treat mitochondria tRNA as mt_tRNA category.|
|||Bug fix: smallrna_database, parsing tRNA name from fasta file (Homo_sapiens_tRNA-Asn-GTT-chr1_KI270713v1_random-2 => random-2, should be tRNA-Asn-GTT-chr1_KI270713v1_random-2)|
|20181128| v1.8.2|Bugfix: fix the problem when the chrM and chrMT not matched between fasta and gff files in smallrna_database|
|||Enhanced: apply more strict criteria for parclip data|
|20181109| v1.8.1|Enhanced: parclip_mirna_target can use smallRNA fasta file as seed source file.|
|20180802| v1.8.0|Bugfix: smallrna_count with no_category option will ignore the reads with NTA. For parclip.|
|20180619| v1.7.9|Enhanced: data_table will export protein_coding genes table.|
|20180515| v1.7.8|Enhanced: smallrna_count can ignore reads in xml file. smallrna_count_table has noCategory option.|
|20180423| v1.7.7|Bugfix: smallRNADatabaseBuilder throw exception for no miRNA database assigned.|
|20171128| v1.7.6|Enhanced: output genome reads and too short reads for smallRNA counting.|
|20170714| v1.7.5|Enhanced: chromosome_count can accept chromosome pattern.|
|20170628| v1.7.4|Bugfix: parsing star mismatch with 'nM:i' tag.|
|20170222| v1.7.3|Enhanced: gtf2bed can use "Name" as key.|
|20170211| v1.7.2|Enhanced: smallrna_sequence_count_table: set exportContigDetails option to save time in large scale dataset.|
|20170203| v1.7.1|Enhanced: smallrna_count: consider yRNA, snRNA, snoRNA and rRNA individually.|
|||Enhanced: smallrna_count_table: output position files for each smallRNA category.|
|20161213| v1.7.0|Enhanced: smallrna_count: consider tRNA non-templated addition in smallRNA counting.|
|||Removed: FastqTrimmer: C# gzip library is not compatible with Gzip format from illumina, so this function may failed.|
|||Bugfix: smallrna_count_table: underestimated the read count whose sequence may belongs to multiple queries (maybe one from original and another from NTA) in read count table|
|20161202| v1.6.18|Enhanced: smallrna_sequence_count_table: group the top reads based on sequence similarity. The reads can be extended by maximum number of base per iteration.|
|||Enhanced: smallrna_sequence_count_table: add option to extract specific sequences only.|
|||Bugfix: chromosome_count_table: count error for read table. Failed when reading empty xml file.|
|||Bugfix: chromosome_count_table: output sequence error for read mapped to reverse strand.|
|20160822| v1.6.17|Enhanced: chromosome_count: add outputSequence option.|
|||Enhanced: data_table: add option to not generate FPKM table.|
|||Enhanced: chromosome_table: add option to output read contig table.|
|||Enhanced: export snoRNA and snRNA percentage based position coverage image.|
|20160822| v1.6.16|Enhanced: cnmops_merge: export cnvr file for depth visualization using ngsperl.|
|||Enhanced: data_table: export feature_name just before count table.|
|20160630| v1.6.15|Enhanced: chromosome_count: add KeepChrInName option.|
|20160516| v1.6.14|Enhanced: smallrna_sequence_count_table: group the top reads based on sequence similarity. The reads with more than 90% overlap will be merged as group.|
|20160510| v1.6.13|New feature: cnmops_merge: merge overlapped Cn.MOPS calls.|
|20160405| v1.6.12|Enhanced: smallrna_count: buf fix for parsing aminoacid from some tRNA names.|
|20160311| v1.6.11|Enhanced: chromosome_count: add namePattern as option for parsing category name from chromosome name.|
|20160303| v1.6.10|Enhanced: smallrna_database: ignore the smallRNA coordinates in ensembl gtf file which don't locate in major chromosomes (for example, 1..22, X,Y,MT).|
|20160302| v1.6.9|Bug fixed: chromosome_count|
|20160226| v1.6.8|New feature: bam_sequence_count_table: build sequence count table from bam files and count files|
|20160215| v1.6.7|Enhanced: smallRNA count/chromosome count|
|20151222| v1.6.6|Enhanced: file_def can automatically adjust the name (for example, CMS-1 and CMS-123, CMS-1 will be auto filled as CMS-001).|
|20151203| v1.6.5|Bug fixed: smallrna_count: the NTA reads will not be summed to total count when bam file contains mapped reads only. A tool smallrna_baminfo_fix can be used to fix old info files.|
|20151105| v1.6.4|Bug fixed: smallrna_count: the total read count will be taken from count file when bam file contains mapped reads only|
|||enhanced: fastq_identical: output query in order of count in dupcount file|
|20151030| v1.6.3|New feature: database_reorder|
|20150921| v1.6.2|New feature: smallrna_t2c_summary|
|20150915| v1.6.1|New feature: fastq_valid_extractor|
|20150910| v1.6.0|Update:tgirt_checkcca, tgirt_nta, tgirt_count|
|20150804| v1.5.9|New feature: fastq_trna: trimming CCA/CCAA from tRNA reads|
|20150429| v1.5.8|New feature: SmallRNA identical sequence count table builder|
|20150407| v1.5.7|New feature: Build summary of FastQC result|
|20150316| v1.5.6|New feature: Convert HTSeq count to FPKM|
|20150312| v1.5.5|New feature: GSE Matrix File Downloader|
|20150309| v1.5.4|Enhanced: gtf_buildmap will generate gene length based on exon|
|20150305| v1.5.3|Enhanced: fastq_trimmer supports pair-end data|
|20150303| v1.5.2|Enhanced: smallRNA counting: limit mismatch and length for reads mapped to lincRNA|
|20150210| v1.5.1|New feature: flip plink file by dbsnp and 1000 genome|
|20150114| v1.5.0|New feature: build smallRNA database|
|20141124| v1.4.9|New feature: impute2_distiller: extract target SNP from impute2 result|
|20141103| v1.4.8|New feature: unmapped_reads: extract unmapped read information|
|20141023| v1.4.7|Enhanced: mirna_nta_table: summerize miRNA count based on NTA and offset|
|20141013| v1.4.6|Enhanced: fastq_mirna: add information to record the trimmed nucleotides|
|20140912| v1.4.5|New feature: fastq_mirna: trimming last 1,2,3 bases from fastq file for miRNA analysis|
|20140911| v1.4.4|Enhanced: fastq_trimmer: can filter reads less than minimum length|
|20140829| v1.4.3|New feature: Chomosome count builder: group mapped reads based on chromosome, it is used for miRBase mapping result analysis now|
|20140703| v1.4.0|New feature: DepthProcessor: filter samtools depth result|
|20140624| v1.3.9|New feature: AlleleCountBuilder: extract allele count from bam file based on locus in VCF file|
|20140623| v1.3.8|Enhanced: Can use directory name as ID of file in file_def tool|
|20140326| v1.3.7|Enhanced: Can remove 'N' from both 5' and 3' of read when demultiplexing file|
|20140312| v1.3.6|New feature: RockhopperSummaryBuilder|
