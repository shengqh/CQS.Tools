if(!require(ggplot2)) { 
  install.packages("ggplot2"); 
  require(ggplot2)
} 

if(!require(scales)) { 
  install.packages("scales"); 
  require(scales)
} 

#print(commandArgs())
catfile<-commandArgs()[7]
pdffile<-commandArgs()[8]
#catfile<-"H:/shengquanhu/projects/vangard/VANGARD00055_guoyan_mirna_v2/human/categories/2570-KCV-01-19.catcount"
counts<-read.table(file=catfile, row.names=1, header=T)
counts<-counts[order(counts[,1], decreasing=T), ,drop=F]

catname<-sub("([^.]+)(\\.[^.]+$)", "\\1", catfile)
catname<-paste0(catname, " [", sum(counts), "]")

cv<-unlist(counts[,1])
lbls<-rownames(counts)
pct <- round(cv/sum(cv)*10000) / 100
lbls <- paste0(lbls, " ", pct, "%") # add percents to labels 

pdf(pdffile)
#pie(cv, labels = lbls, col=rainbow(length(lbls)), main=catname, cex=0.5)
counts<-read.table(file=catfile, header=T)
counts$Category <- factor(c(1:nrow(counts)), labels=as.character(counts$Category), levels = c(1:nrow(counts)))
ggplot(counts) + 
  geom_bar(aes(x=Category, y=(counts$Count)/sum(counts$Count), fill=Category), stat="identity") + 
  scale_y_continuous(labels = percent_format()) + 
  labs(title = catname) + 
  ylab("Percentage")
dev.off()

