CQS Bioinformatics Software Suite
==
* [Introduction](#Introduction)
* [Prerequisites](#Prerequisites)
* [Installation](#Installation)
* [Changes](#changes)

<a name="Introduction"/>
#Introduction

CQS bioinformatics software suite (cqstools) contains a bunch of tools used in genomics research, from preprocessing, format conversion, counting, summarizing to annotation, et al.

<a name="Prerequisites"/>
#Prerequisites
Although cqstools is developed by C#, it is majorly executed under linux through [mono] (https://github.com/mono/mono). So mono on your linux system is required for cqstools.

<a name="Installation"/>
#Installation
###Binary File
User can download compiled version from [github](https://github.com/shengqh/CQS.Tools/releases). Download the file and decompress it to any folder you want, run "mono CQS.Tools.exe" and have fun.

<a name="Changes"/>
#Changes

|Date|Version|Description|
|---|---|---|
|20160226| v1.6.8|New feature: bam_sequence_count_table: build sequence count table from bam files and count files
|20160215| v1.6.7|Enhanced: smallRNA count/chromosome count
|20151222| v1.6.6|Enhanced: file_def can automatically adjust the name (for example, CMS-1 and CMS-123, CMS-1 will be auto filled as CMS-001).
|20151203| v1.6.5|Bug fixed: smallrna_count: the NTA reads will not be summed to total count when bam file contains mapped reads only. A tool smallrna_baminfo_fix can be used to fix old info files.
|20151105| v1.6.4|Bug fixed: smallrna_count: the total read count will be taken from count file when bam file contains mapped reads only
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