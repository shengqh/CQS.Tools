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

If you don't have administrator permission, you may consider to install mono into your own directory. For example:

    wget https://github.com/mono/mono/archive/mono-3.6.0.39.tar.gz
	tar -xzvf mono-3.6.0.39.tar.gz
	cd mono-3.6.0.39
	./autogen.sh --prefix=/${your_home}/local
	make
	make install

<a name="Installation"/>
#Installation
###Binary File
User can download compiled version from [github](https://github.com/shengqh/CQS.Tools/releases). Download the file and decompress it to any folder you want, run "mono CQS.Tools.exe" and have fun.

<a name="Changes"/>
#Changes

|Date|Version|Description|
|---|---|---|
|20140829| v1.4.3|New feature: Chomosome count builder: group mapped reads based on chromosome, it is used for miRBase mapping result analysis now|
|20140703| v1.4.0|New feature: DepthProcessor: filter samtools depth result|
|20140624| v1.3.9|New feature: AlleleCountBuilder: extract allele count from bam file based on locus in VCF file|
|20140623| v1.3.8|Enhanced: Can use directory name as ID of file in file_def tool|
|20140326| v1.3.7|Enhanced: Can remove 'N' from both 5' and 3' of read when demultiplexing file|
|20140312| v1.3.6|New feature: RockhopperSummaryBuilder|