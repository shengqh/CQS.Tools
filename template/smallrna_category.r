catfile<-commandArgs()[7]
graphfile<-commandArgs()[8]
ispdf<-commandArgs()[9] == "1"

#catfile<-"H:/shengquanhu/projects/vangard/VANGARD00055_guoyan_mirna_v2/mouse/topN_bowtie1_genome_cutadapt_1mm_count_smallRNA_category/result/2570-KCV-01-20.catcount"
#graphfile<-"H:/shengquanhu/projects/vangard/VANGARD00055_guoyan_mirna_v2/mouse/topN_bowtie1_genome_cutadapt_1mm_count_smallRNA_category/result/2570-KCV-01-20.catcount.png"
#ispdf<-0

counts<-read.table(file=catfile, header=T, sep="\t")
rownames(counts)<-counts$Category
level0<-counts[counts$Level==0,]
level1<-counts[counts$Level==1,]

catname<-sub("([^.]+)(\\.[^.]+$)", "\\1", basename(catfile))

cv<-unlist(level1$Count)
lbls<-level1$Category
pct<-round(cv/sum(cv)*10000) / 100
lbls<-paste0(lbls, " ", pct, "%") # add percents to labels 

if(nrow(level0) > 0){
  if(ispdf){
    pdf(graphfile)
  }else{
    png(graphfile, width=6000, height=3000, res=300)
  }
  par(mfrow=c(1,2))
  par(mar=c(10,14,10,10))
  par(las=2)
  barX<-barplot(level0$Count,  space=0.5, names.arg=level0$Category, mar=c(10,10,10,10), col=rainbow(nrow(level0)))
  text(x=barX, y=level0$Count+par("cxy")[2], level0$Count, xpd=TRUE) 
  mtext("Counts", side=2, line=4, at=max(level0$Count)/2, cex=1.5, las=0)
  par(mar=c(4,2,4,10))
  pie(cv, labels = lbls, col=rainbow(length(lbls)), cex=0.8)
  par(oma=c(2,2,5,2)) 
  title(main = catname, outer = TRUE, cex.main = 3)
  dev.off()
}else{
  catname<-paste0(catname, " [", sum(level1$Count), "]")
  if(ispdf){
    pdf(graphfile)
  }else{
    png(graphfile, width=3000, height=3000, res=300)
  }
  pie(cv, labels = lbls, col=rainbow(length(lbls)), main=catname, cex=0.8)
  dev.off()
}
