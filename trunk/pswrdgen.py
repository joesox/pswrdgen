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

    def change_min(self):
        msg = "What is the minimum length of your password(default=%i(must be greater than 2))?: "
        while True:
            userinput = raw_input(msg%self.MINLENGTH)
            if userinput.isdigit() and not int(userinput) <= 2:
                self.MINLENGTH = int(userinput)
                break
    
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
        
        while True:
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
            if choice.isdigit():
                if(int(choice) >= 1 and int(choice) < 7):
                    if(int(choice) == 1):
                        for y in range(self.GENCOUNT):
                            print self.run()
                    elif(int(choice) == 2):
                        newgencount = input("How many passwords do you wish to generate(current="+str(self.GENCOUNT)+")?: ")
                        if(newgencount > 0):
                            self.GENCOUNT = newgencount
                    elif(int(choice) == 3):
                        self.change_min()
                    elif(int(choice) == 4):
                        self.changedefaults()
                    elif(int(choice) == 5):
                        self.printdefaults()
                    elif(int(choice) == 6):
                        break
            else:
                #if a user types 'exit' try to breakout of menu loop
                if(str(choice).lower() == "exit"):
                    break

    """
    Assign the default values to the instance before calling run()
    You may manually change the default configuration here.
    """
    def do_setup(self):
        self.NOUNFILE = "C:\\Program Files\\WordNet\\2.1\\dict\\index.noun" #WordNet Noun list to read
        # self.NOUNFILE = "/usr/local/WordNet-3.0/dict/index.noun"
        self.SWAPS = {'h':4, 's':5}
        self.MINLENGTH = 8
        self.MAXLENGTH = 16
        self.CAPLENGTH = 2
        self.GENCOUNT = 10
        
    """Change the configuration or except the default configuration."""
    def changedefaults(self):
        self.change_min()
        
        maxmsg = "What is the maximum length of your password(default=%i(must be greater than %i))?: "
        low = max(5, self.MINLENGTH)
        while true:            
            userinput = raw_input(maxmsg%(self.MAXLENGTH, low))
            if userinput.isdigit() and int(userinput) > low:
                self.MAXLENGTH = int(userinput)
                break
            
        userinput = raw_input("How many capital letters in your password(default=%i)?: "%self.CAPLENGTH)
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
        #Read the noun list
        self.wordnetlist = open(self.NOUNFILE, 'rU').readlines()
        
        #Delete the first 212 because they are not words
        self.wordnetlist = self.wordnetlist[213:]

        #VALIDATE WORD...
        while True:
            #Choose a random line/word
            curline = self.wordnetlist[random.randrange(0, len(self.wordnetlist))]
            
            #Make sure it is just one word
            curword = curline.split(" ")[0]
            
            #if there is no '_' found, then look for other problems with the selected word
            if('_' not in curword):
                #Make sure it is not below MINLENGTH AND is not above MAXLENGTH
                if (self.MINLENGTH <= len(curword) <= self.MINLENGTH):
                    break
        
        #Prep for Capitalize random characters in the word...
        wordlength = len(curword)
        
        #DO replacement swaps here
        for c in curword:
            for k,v in self.SWAPS.iteritems():
                if(c == k):
                    curword = curword.replace(k,str(v))
        
        #Create a list of the characters in the word
        wordcharlist = list(curword)
            
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
        for x in poslist:
            wordcharlist[x] = wordcharlist[x].upper()
            
        return ''.join(wordcharlist)


def test():
    i = pswrdgen()
    i.do_setup()
    i.menu() 
    
if __name__ == '__main__':
  test()
