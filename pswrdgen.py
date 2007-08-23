import os, sys, random
sys.path.append("C:\\Program Files\\WordNet\\2.1\\dict")
__version__ = '0.1.1'
__author__ = "Joseph P. Socoloski III"
__url__ = 'www.joeswammi.com/python/docs/pswrdgen'
__doc__ = 'Semantic Password generator that uses WordNet 2.1, random capitalization, and character swapping. Needs WordNet 2.1'

"""
Semantic Password generator that uses WordNet 2.1, random capitalization, and character swapping.
"""
class pswrdgen:
    def init__(self):
        self.NOUNFILE = "" #WordNet Noun list to read
        self.wordnetlist =[]
        self.SWAPS = {}
        self.MINLENGTH = None
        self.MAXLENGTH = None
        self.CAPLENGTH = None
        self.GENCOUNT = None
        self.do_setup()

    """Main Menu loop"""
    def menu(self):
        print "*******************************"
        print "* pswrdgen - by JPSIII        *"
        print "* http://joeswammi.com/python *"
        print "* --------------------------- *"
        print "* Semantic Password generator *"
        print "* that uses WordNet 2.1,      *"
        print "* random capitalization,      *"
        print "* and character swapping.     *"
        print "*******************************"
        
        menu_on = True
        while(menu_on == True):
            print "*******************************"
            print "* Choose one of the below:    *"
            print "* 1) Generate password(s)     *"
            print "* 2) Change generate count    *"
            print "* 3) Change password length   *"
            print "* 4) Change all defaults      *"
            print "* 5) Display defaults         *"
            print "* 6) Exit                     *"
            print "*******************************"
            choice = raw_input("> ")
            if(choice.isdigit() == True):
                if(int(choice) >= 1 and int(choice) < 7):
                    if(int(choice) == 1):
                        for y in range(self.GENCOUNT):
                            print self.run()
                    if(int(choice) == 2):
                        newgencount = input("How many passwords do you wish to generate(current="+str(self.GENCOUNT)+")?: ")
                        if(newgencount > 0):
                            self.GENCOUNT = newgencount
                    if(int(choice) == 3):
                        mingood = False
                        while(mingood == False):
                            userinput = raw_input("What is the minimum length of your password(default="+str(self.MINLENGTH)+"(must be greater than 2))?: ")
                            if(userinput.isdigit() == True):
                                if(int(userinput) <= 2):
                                    mingood = False
                                else:
                                    self.MINLENGTH = int(userinput)
                                    mingood = True
                    if(int(choice) == 4):
                        self.changedefaults()
                    if(int(choice) == 5):
                        self.printdefaults()
                    if(int(choice) == 6):
                        menu_on = False
            else:
                #if a user types 'exit' try to breakout of menu loop
                if(str(choice).lower() == "exit"):
                    menu_on = False
                else:
                    menu_on = True

    """
    Assign the default values to the instance before calling run()
    You may manually change the default configuration here.
    """
    def do_setup(self):
        self.NOUNFILE = "C:\\Program Files\\WordNet\\2.1\\dict\\index.noun" #WordNet Noun list to read
        self.SWAPS = {'h':4, 's':5}
        self.MINLENGTH = 8
        self.MAXLENGTH = 16
        self.CAPLENGTH = 2
        self.GENCOUNT = 10
        
    """Change the configuration or except the default configuration."""
    def changedefaults(self):
        userinput = ""
        mingood = False
        while(mingood == False):
            userinput = raw_input("What is the minimum length of your password(default="+str(self.MINLENGTH)+"(must be greater than 2))?: ")
            if(userinput.isdigit() == True):
                if(int(userinput) <= 2):
                    mingood = False
                else:
                    self.MINLENGTH = int(userinput)
                    mingood = True

        maxgood = False
        while(maxgood == False):            
            userinput = raw_input("What is the maximum length of your password(default="+str(self.MAXLENGTH)+"(must be greater than 5))?: ")
            if(userinput.isdigit() == True):
                if(int(userinput) <= 5):
                    maxgood = False
                elif(int(userinput) < self.MINLENGTH):
                    print "MAXLENGTH can not be smaller than the MINLENGTH"
                    maxgood = False
                else:
                    self.MAXLENGTH = int(userinput)
                    maxgood = True
            
        userinput = raw_input("How many capital letters in your password(default="+str(self.CAPLENGTH)+")?: ")
        self.CAPLENGTH = int(userinput)
        if(self.CAPLENGTH <=0 or userinput.strip() == ""):
            userinput = raw_input("How many capital letters in your password(must be greater than 0)?: ")
            self.CAPLENGTH = int(userinput)
            
        userinput = input("Type in your swap rules dictionary(default="+str(self.SWAPS)+")?: ")
        self.SWAPS = dict(userinput)

        print "DEFAULTS CHANGED TO:"
        self.printdefaults()

    """Print the configuration defaults to the console"""
    def printdefaults(self):
        print "NOUNFILE: " + self.NOUNFILE
        print "MINLENGTH: " + str(self.MINLENGTH)
        print "MAXLENGTH: " + str(self.MAXLENGTH)
        print "CAPLENGTH: " + str(self.CAPLENGTH)
        print "SWAPS: " + str(self.SWAPS) 

    """Generate one password"""
    def run(self):
        password = ""
        #Read the noun list
        self.wordnetlist = open(self.NOUNFILE, 'rU').readlines()
        
        #Delete the first 212 because they are not words
        self.wordnetlist = self.wordnetlist[213:]

        #VALIDATE WORD...
        validword = False
        while (validword == False):
            #Choose a random line/word
            curline = self.wordnetlist[random.randrange(0, len(self.wordnetlist))]
            
            #Make sure it is just one word
            curword = curline.split(" ")[0]
            
            #if there is no '_' found, then look for other problems with the selected word
            if(curword.find('_') == -1):
                #Make sure it is not below MINLENGTH AND is not above MAXLENGTH
                validword = (len(curword) >= self.MINLENGTH) and (len(curword) <= self.MINLENGTH)
            else:
                validword = False
        
        #Prep for Capitalize random characters in the word...
        wordlength = len(curword)
        
        #DO replacement swaps here
        for c in curword:
            for k,v in self.SWAPS.iteritems():
                if(c == k):
                    curword = curword.replace(k,str(v))
        
        #Create a list of the characters in the word
        wordcharlist = []
        for c in curword:
            wordcharlist.append(c)
            
        #Figure out what char positions to convert to uppercase
        poslist = []
        x=0
        while (x < self.CAPLENGTH and x >= 0):
            randnum = random.randrange(0, wordlength)
            if((poslist.count(randnum) == 0) and (wordcharlist[randnum].isalpha)):
                poslist.append(randnum)
                x = x + 1
            else:
                x = x - 1
            
        #Perform the transfoms...
        for x in range(wordlength):
            if(x in poslist):
                password +=  wordcharlist[x].upper()
            else:
                password +=  wordcharlist[x]
            
        return password


def test():
    i = pswrdgen()
    i.do_setup()
    i.menu() 
    
if __name__ == '__main__':
  test()
