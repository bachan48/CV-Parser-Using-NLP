import sys
import os
import string
from os import chdir, getcwd, listdir, path
from nltk.corpus import stopwords
from nltk.tokenize import word_tokenize
import PyPDF2

from time import strftime


def convertToText(pathToFile):
    folder = pathToFile


    list=[]

    directory=folder

    for root,dirs,files in os.walk(directory):

        for filename in files:

            if filename.endswith('.pdf'):

                t=os.path.join(directory,filename)

                list.append(t)


    tempdir = directory+"/temp"


    for item in list: #loop for sabbai file
        if not os.path.exists(tempdir):
            os.makedirs(tempdir)
        path=item

        head,tail=os.path.split(path)

        

       

        tail=tail.replace(".pdf",".txt")

        name=filename+tail

        content = ""

        

        pdf = PyPDF2.PdfFileReader(path, "rb")

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
        print("Converting! Will be converted shortly")
        print (tempdir)
        with open(tempdir+"/"+name,'w') as out:
            out.write(final_string)
            out.close()

convertToText(sys.argv[1])