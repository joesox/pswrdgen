import os, sys, random
__version__ = '0.2.2'
__author__ = "Joseph P. Socoloski III"
__url__ = 'http://code.google.com/p/pswrdgen/'
__doc__ = 'Semantic Password generator that uses WordNet, random capitalization, and character swapping. Prerequisite:WordNet'


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
            for word in (s.strip() for s in line.split()):
                if len(store)+len(word)+1 > length:
                    printline(length, div, store)
                    store = ''
                store = store+' '+word if store or word
            printline(length, div, store)
    print "*"*(length+4)


class pswrdgen:
    """
    Semantic Password generator that uses WordNet 2.1, random capitalization, and character swapping.
    """
    
    def __init__(self):
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
        box(40, 'c', 'pswrdgen', __version__, __url__, '-'*40, __doc__)
        while True:
            box(26, 'l', 'Choose one of the below:', '1) Generate password(s)',  '2) Change generate count',
                '3) Change password length', '4) Change all defaults' , '5) Display defaults', '6) Exit')
            entered = raw_input("> ")
            try:
                choice = int(entered)
            except:
                if(str(entered).lower() == "exit"):
                    break
            else:
                if choice == 1:
                    for y in range(self.GENCOUNT):
                        print self.run()
                elif choice == 2:
                    self.GENCOUNT = getint("How many passwords do you wish to generate", self.GENCOUNT, 1)
                elif choice == 3:
                    self.MINLENGTH = getint("What is the minimum length of your password", self.MINLENGTH, 3)
                elif choice == 4:
                    self.changedefaults()
                elif choice == 5:
                    self.printdefaults()
                elif choice == 6:
                    break
                
    def do_setup(self):
        """
        Decides what the operating system is and chooses the install directory of WordNet
        Assign the default values to the instance before calling run()
        You may manually change the default configuration here.
        NOTE: The platform handling still needs testing from non-Windows users 8/30/07
        """
        # Platform support for Windows
        if sys.platform[:3] == 'win':
            FS_ROOT = 'C:\\Program Files'
            WORDNETPATH=os.path.join( FS_ROOT, 'WordNet', '2.1', 'dict' )
        # Platform support for IronPython. We are assuming here that we will not run into many 'cli' platforms
        elif sys.platform == 'cli':
            FS_ROOT = 'C:\\Program Files'
            WORDNETPATH=os.path.join( FS_ROOT, 'WordNet', '2.1', 'dict' )
        # Platform support for MacOS /usr/local/WordNet-3.0/dict/
        elif sys.platform == 'darwin':
            FS_ROOT = '/'
            WORDNETPATH=os.path.join( FS_ROOT, 'usr', 'local', 'WordNet-3.0', 'dict' )
        else:
            FS_ROOT = '/'
            WORDNETPATH=os.path.join( FS_ROOT, 'WordNet', '2.1', 'dict' )
        #WordNet Noun list to read
        sys.path.append(WORDNETPATH)
        self.setnounfile(os.path.join(WORDNETPATH, "index.noun"))
        
        #Manually change your default do_setup settings HERE...
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
        curword = ''
        while not (curword and self.MINLENGTH <= wordlength <= self.MAXLENGTH):
            curword = self.wordnetlist[random.randrange(0, len(self.wordnetlist))]
            wordlength = len(curword)
        
        #DO replacement swaps here
        for k, v in self.SWAPS.iteritems():
            curword = curword.replace(k, str(v))
        
        #Create a list of the characters in the word
        wordcharlist = list(curword)
            
        # Capitalise exactly self.CAPLENGTH letters
        poslist = []
        while len(poslist) < self.CAPLENGTH:
            randnum = random.randrange(0, wordlength)
            if randnum not in poslist and wordcharlist[randnum].isalpha():
                poslist.append(randnum)
                wordcharlist[randnum] = wordcharlist[randnum].upper()
            
        return ''.join(wordcharlist)


def test():
    i = pswrdgen()
    i.menu() 
    
if __name__ == '__main__':
  test()
