import sys
import os
import string
from os import chdir, getcwd, listdir, path
from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
import PyPDF2


def convertToText(pathToFile):
    directory = pathToFile


    list=[]

    for root,dirs,files in os.walk(directory):

        for filename in files:

            if filename.endswith('.pdf'):

                t=os.path.join(directory,filename)

                list.append(t)


    tempdir = "C:/Windows/Temp/temp/"

    count = 1
    for filepathtoitem in list: #loop for sabbai file
        if not os.path.exists(tempdir):
            os.makedirs(tempdir)

        total = os.path.basename(filepathtoitem)
        head,tail=os.path.split(total)

       

        tail=tail.replace(".pdf",".txt")

        name=head+tail

        content = ""

        

        pdf = PyPDF2.PdfFileReader(filepathtoitem, "rb")

        stop_words = set(stopwords.words("english"))
        table = str.maketrans({key: None for key in string.punctuation})

        for i in range(0, pdf.getNumPages()):

            

            content += pdf.getPage(i).extractText() + "\n"



        new_content = content.translate(table)
        words = word_tokenize(new_content)
        filtered_sentence = []
        for w in words :

        #if word not in stop words add to array
            if w not in stop_words:
                filtered_sentence.append(w)

        final_string = ','.join(filtered_sentence)
        print("Converting "+str(count)+"! Will be converted shortly")
        with open(tempdir+name,'w') as out:
            out.write(final_string)
            out.close()
        count += 1
    print("All Done")        

convertToText(sys.argv[1])
