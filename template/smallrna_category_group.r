#predefine_start
catfile<-"H:/shengquanhu/projects/vickers/20150219_smallRNA_3018-KCV-9_human/bowtie1_genome_1mm_NTA_smallRNA_category/result/3018-KCV-9.catcount"
outputdir<-"H:/shengquanhu/projects/vickers/20150219_smallRNA_3018-KCV-9_human/bowtie1_genome_1mm_NTA_smallRNA_category/result/"
ispdf<-0
#predefine_end

require(ggplot2)

print(paste0("reading from file ", catfile, "..."))
allcounts<-read.table(file=catfile, header=T, sep="\t")
sampleNames = unique(allcounts$SampleName)

#individual barplot and pie chart
for(sampleName in sampleNames){
  #sampleName<-sampleNames[1]
  print(sampleName)
  
  counts<-allcounts[allcounts$SampleName == sampleName,]
  level0<-counts[counts$Level==0,]
  level2<-counts[counts$Level==2,]
  
  categoryCount = length(unique(level2$Category))
  repc<-c(1:categoryCount)
  level2$Category <- factor(repc, labels=as.character(level2$Category), levels = c(1:categoryCount))
  
  cv<-level2
  cv$Color<-rainbow(nrow(cv))
  cv<-cv[cv$Count > 0,,drop=F]
  
  haspie<-nrow(cv) > 0
  hasbar<-nrow(level0) > 0
  if(!haspie & !hasbar){
    next
  }
  
  if(ispdf){
    graphfile<-paste0(outputdir, "/", sampleName, ".pdf")
    pdf(graphfile)
  }else{
    graphfile<-paste0(outputdir, "/", sampleName, ".png")
    if(haspie & hasbar){
      png(graphfile, width=6000, height=3000, res=300)
      par(mfrow=c(1,2))
    }else{
      png(graphfile, width=3000, height=3000, res=300)
    }
  }
  
  if(hasbar){
    par(mar=c(10,14,10,10), las=2)
    barX<-barplot(level0$Count,  space=0.5, names.arg=level0$Category, mar=c(10,10,10,10), col=rainbow(nrow(level0)))
    text(x=barX, y=level0$Count+par("cxy")[2], level0$Count, xpd=TRUE) 
    mtext("Counts", side=2, line=4, at=max(level0$Count)/2, cex=1.5, las=0)
    catname<-sampleName
  }else{
    catname<-paste0(sampleName, " [", sum(level1$Count), "]")
  }
  
  if(haspie){
    lbls<-cv$Category
    pct<-round(cv$Count/sum(cv$Count)*10000) / 100
    lbls<-paste0(lbls, " ", pct, "%") # add percents to labels 
    par(mar=c(2,2,2,8))
    pie(cv$Count, labels = lbls, col=cv$Color, cex=0.8)
  }
  par(oma=c(2,2,5,2)) 
  title(main = catname, outer = TRUE, cex.main = 3)
  
  dev.off()
}

gcounts<-allcounts[allcounts$Level==1,]
if(ispdf){
  graphfile<-paste0(outputdir, "/", basename(catfile), ".pdf")
  pdf(graphfile)
}else{
  graphfile<-paste0(outputdir, "/", basename(catfile), ".png")
  png(graphfile, width=4000, height=3000, res=300)
}

categoryCount = length(unique(gcounts$Category))
sampleCount = length(sampleNames)
repc<-rep(c(1:categoryCount), sampleCount)
gcounts$Category <- factor(repc, labels=as.character(gcounts$Category)[1:categoryCount], levels = c(1:3))

g<-ggplot(gcounts,aes(x=SampleName, y=Count,fill=Category))+geom_bar(stat="identity")+
  theme(axis.text.x=element_text(angle=90,hjust=1,vjust=0.5)) + 
  theme(legend.position = "top")
print(g)

dev.off()
