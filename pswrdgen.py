import os, sys, random
sys.path.append("C:\\Program Files\\WordNet\\2.1\\dict")
__version__ = '0.1.1'
__author__ = "Joseph P. Socoloski III"
__url__ = 'www.joeswammi.com/python/docs/pswrdgen'
__doc__ = 'Semantic Password generator that uses WordNet 2.1, random capitalization, and character swapping. Needs WordNet 2.1'


def getint(msg, default, low):
    while True:
        userinput = raw_input(msg+" (default=%i, minimum=%i) ?: "%(default, low))
        if userinput == '':
            return default
        try:
            res = int(userinput)
            if low <= res:
                return res
        except Exception, e:
            print e


class pswrdgen:
    """
    Semantic Password generator that uses WordNet 2.1, random capitalization, and character swapping.
    """
    
    def init__(self):
        self.NOUNFILE = "" #WordNet Noun list to read
        self.wordnetlist =[]
        self.SWAPS = {}
        self.MINLENGTH = None
        self.MAXLENGTH = None
        self.CAPLENGTH = None
        self.GENCOUNT = None
        self.do_setup()

    def menu(self):
        """Main Menu loop"""

        print "*************************************"
        print "*              pswrdgen             *"
        print "* http://code.google.com/p/pswrdgen *"
        print "* --------------------------------- *"
        print "* Semantic Password generator that  *"
        print "* uses WordNet 2.1,random           *"
        print "* capitalization,and character      *"
        print "* swapping.                         *"
        print "*************************************"
        
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
                if(1 <= int(choice) < 7):
                    if(int(choice) == 1):
                        for y in range(self.GENCOUNT):
                            print self.run()
                    elif(int(choice) == 2):
                        self.GENCOUNT = getint("How many passwords do you wish to generate", self.GENCOUNT, 1)
                    elif(int(choice) == 3):
                        self.MINLENGTH = getint("What is the minimum length of your password", self.MINLENGTH, 3)
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

    def do_setup(self):
        """
        Assign the default values to the instance before calling run()
        You may manually change the default configuration here.
        """
        self.setnounfile("C:\\Program Files\\WordNet\\2.1\\dict\\index.noun") #WordNet Noun list to read
        # self.setnounfile('/usr/local/WordNet-3.0/dict/index.noun')
        self.SWAPS = {'h':4, 's':5}
        self.MINLENGTH = 8
        self.MAXLENGTH = 16
        self.CAPLENGTH = 2
        self.GENCOUNT = 10
    
    def changedefaults(self):
        """Change the configuration or except the default configuration."""
        self.MINLENGTH = getint("What is the minimum length of your password", self.MINLENGTH, 3)
        self.MAXLENGTH = getint("What is the maximum length of your password ", self.MAXLENGTH, max(5, self.MINLENGTH))
        self.CAPLENGTH = getint("How many capital letters in your password ", self.CAPLENGTH, 1)
            
        userinput = input("Type in your swap rules dictionary(default=%s)?: "%self.SWAPS)
        self.SWAPS = dict(userinput)

        print "DEFAULTS CHANGED TO:"
        self.printdefaults()

    def printdefaults(self):
        """Print the configuration defaults to the console"""
        print "NOUNFILE: " + self.NOUNFILE
        print "MINLENGTH: " + str(self.MINLENGTH)
        print "MAXLENGTH: " + str(self.MAXLENGTH)
        print "CAPLENGTH: " + str(self.CAPLENGTH)
        print "SWAPS: " + str(self.SWAPS) 
    
    def setnounfile(self, source):
        self.NOUNFILE = source
        
        #Read the noun list ignoring the first 212 as they are not words
        wordlist = open(source, 'rU').readlines()[213:]
        
        #If there are multiple words on a line take the first, ignore hyphenated words
        self.wordnetlist = [s.split(" ")[0] for s in wordlist if '-' not in s]

    def run(self):
        """Generate one password"""
        # Pick a random word of valid length
        while True:
            curword = self.wordnetlist[random.randrange(0, len(self.wordnetlist))]
            if (self.MINLENGTH <= len(curword) <= self.MAXLENGTH):
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
        while len(poslist) < self.CAPLENGTH:
            randnum = random.randrange(0, wordlength)
            if randnum not in poslist and wordcharlist[randnum].isalpha():
                poslist.append(randnum)
            
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
