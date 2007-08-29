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
        except ValueError:
            pass # User entered nether an integer or an empty line


def printline(length, div, line):
    pad = max(0, (length-len(line))/div)
    print "*%*s%-*s *" %(pad+1, ' ', length-pad, line)


def box(length, justify, *lines):
    div = {'c':2, 'r':1}.get(justify, 100)
    print "*"*(length+4)
    for line in lines:
        if len(line) <= length or ' ' not in line:
            printline(length, div, line)
        else: 
            store = ''
            for word in line.split():
                if len(store)+len(word) > length:
                    printline(length, div, store)
                    store = ''
                store = store+' '+word
            printline(length, div, store)
    print "*"*(length+4)


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
        box(40, 'c', 'pswrdgen', __version__, __url__, __author__, '-'*40, __doc__)
        while True:
            box(26, 'l', 'Choose one of the below:', '1) Generate password(s)',  '2) Change generate count',
                '3) Change password length', '4) Change all defaults' , '5) Display defaults', '6) Exit')
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
        self.GENCOUNT = getint("How many passwords do you wish to generate", self.GENCOUNT, 1)
        self.MINLENGTH = getint("What is the minimum length of your password", self.MINLENGTH, 3)
        self.MAXLENGTH = getint("What is the maximum length of your password ", self.MAXLENGTH, max(5, self.MINLENGTH))
        self.CAPLENGTH = getint("How many capital letters in your password ", self.CAPLENGTH, 1)
        
        try:
            userinput = input("Type in your swap rules dictionary(default=%s)?: "%self.SWAPS)
            if userinput:
                self.SWAPS = dict(userinput)
        except SyntaxError:
            pass # Ignore invalid user input
                
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
        
        data = open(source, 'rU')
        #discard lines until the start of usable words 
        for s in data:
            if s[0] == 'a':
                break
        
        #If there are multiple words on a line take the first, ignore words split by '_', ', or '.'
        self.wordnetlist = [s.split(" ")[0] for s in data if '_' not in s if '.' not in s if "'" not in s]

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
