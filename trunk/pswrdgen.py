"""config CONFIGURATION SETTINGS
GENCOUNT::10
MINLENGTH::8
MAXLENGTH::16
CAPLENGTH::2
SWAPS::{'h': 4, 's': 5}
ADDCHAR::'01234567890-_!@$%^&*(),.<>+='
ADDCOUNT::2
endconfig"""

### IRONPYTHON SUPPORT START ###
import sys
sys.path.append("C:\\Python24\\Lib")
### IRONPYTHON SUPPORT END   ###
import os, random, re, glob
__version__ = '0.3.4'
__author__ = "Joseph P. Socoloski III"
__url__ = 'http://pswrdgen.googlecode.com'
__doc__ = 'Semantic Password generator that uses WordNet, random capitalization, and character swapping.Prerequisite:WordNet'


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
                if len(store)+len(word)+1 > length:
                    printline(length, div, store.strip())
                    store = ''
                store = store+' '+word
            printline(length, div, store.strip())
    print "*"*(length+4)


def run_menu(width, values, *options):
    while True:
        tmp = ['%i) %s'%(i+1, s[0]%values) for i, s in enumerate(options)]
        box(width, 'l', 'Choose one of the below:', *tmp+['%i) exit'%(len(options)+1)])
        entered = raw_input("> ")
        try:
            choice = int(entered)
        except:
            if(str(entered).lower() == "exit"):
                break
        else:
            if choice == len(options)+1:
                break
            elif 0 < choice <= len(options):
                options[choice-1][1]()


class pswrdgen:
    """
    Semantic Password generator that uses WordNet 2.1, random capitalization, and character swapping.
    """
    
    def __init__(self):
        """
        Decides what the operating system is and chooses the install directory of WordNet
        Assign the default values to the instance before calling run()
        You may manually change the default configuration here.
        NOTE: The platform handling still needs testing from non-Windows users 8/30/07
        """
        if sys.platform[:3] == 'win': #Windows
            FS_ROOT = 'C:\\Program Files'
        elif sys.platform == 'cli':  # IronPython
            FS_ROOT = 'C:\\Program Files'
        elif sys.platform == 'darwin': # MacOS
            FS_ROOT = '/'
        else:
            FS_ROOT = '/'
        #Find the WordNet Noun list to read
        a = os.path.join( FS_ROOT, 'WordNet', '[0-9].[0-9]', 'dict', 'index.noun')
        b = os.path.join( FS_ROOT, 'usr', 'local', 'WordNet-[0-9].[0-9]', 'dict', 'index.noun')
        WORDNETPATH = (glob.glob(a) or glob.glob(b))[0]
        self.setnounfile(WORDNETPATH)
        #Read the previous settings and load into vars
        self.loadsettings()

    def do_setup(self):
        """Must leave method for pswrdgeniron backwards compatibility"""
        pass
    
    def menu(self):
        """Main Menu loop"""
        box(40, 'c', 'pswrdgen', __version__, __url__, '-'*40, __doc__)
        run_menu(70, self.__dict__, 
                ('Generate %(GENCOUNT)i password(s)', self._generate),
                ('Change generate count (now %(GENCOUNT)i)', self._input_count),
                ('Change password length (now %(MINLENGTH)i<=length<=%(MAXLENGTH)i)', self._input_length),
                ('Change capitalisation count (now %(CAPLENGTH)i)', self._cap_count),
                ('Change swap dictionary (now %(SWAPS)s)', self._input_swaps),
                ('Change number/punctuation insertion (now %(ADDCOUNT)s)', self._add_count),
                ('Change number/punctuation list (now %(ADDCHAR)s)', self._input_punctuation),
                ('Change all defaults', self.changedefaults),
                ('Display defaults', self.printdefaults),
                    ('Save all defaults/settings', self._savesettings))
                
    def _input_count(self):
        self.GENCOUNT = getint("How many passwords do you wish to generate", self.GENCOUNT, 1)
    
    def _input_length(self):
        self.MINLENGTH = getint("What is the minimum length of your password", self.MINLENGTH, 3)
        self.MAXLENGTH = getint("What is the maximum length of your password ", self.MAXLENGTH, max(self.MINLENGTH, self.MINLENGTH))
    
    def _cap_count(self):
        self.CAPLENGTH = getint("How many capital letters in your password ", self.CAPLENGTH, 1)
    
    def _generate(self):
        for i in range(self.GENCOUNT):
            print self.run()

    def _add_count(self):
        self.ADDCOUNT = getint("How many extra numbers/punctuation in your password ", self.ADDCOUNT, 0)
    
    def _input_punctuation(self):
        try:
            userinput = raw_input("Type in your number and punctuation characters (default=%s)?: "%self.ADDCHAR)
            if userinput:
                self.ADDCHAR = userinput
        except (NameError, SyntaxError):
            pass # Ignore invalid user input
    
    def _input_swaps(self):
        try:
            userinput = input("Type in your swap rules dictionary(default=%s)?: "%self.SWAPS)
            if userinput:
                self.SWAPS = dict(userinput)
        except (NameError, SyntaxError):
            pass # Ignore invalid user input

    def changedefaults(self):
        """Change the configuration or accept the default configuration."""
        self._input_count()
        self._input_length()
        self._cap_count()
        self._input_punctuation()
        self._add_count()
        self._input_swaps()

    def printdefaults(self):
        """Print the configuration defaults to the console"""
        print "NOUNFILE: " + self.NOUNFILE
        print "MINLENGTH: " + str(self.MINLENGTH)
        print "MAXLENGTH: " + str(self.MAXLENGTH)
        print "CAPLENGTH: " + str(self.CAPLENGTH)
        print "SWAPS: " + str(self.SWAPS)
        print "INSERT No.: " + str(self.ADDCOUNT)
        print "INSERT OPTIONS: " + str(self.ADDCHAR)
    
    def setnounfile(self, source):
        """Set and load a text file, ignoring inherantly invalid words"""
        self.NOUNFILE = source
        match = re.compile('^([a-zA-Z]{3,}) ', re.M)
        data = open(source, 'r')
        
        self.wordnetlist = sorted(set(match.findall('\n'.join(data))))
        self.wordlengthcap = max(len(s) for s in self.wordnetlist)
    
    def loadsettings(self):
        """
        loadsettings() reads the variable lines after '\"\"\"config' in this file
        then assigns them to there variables. This allows for custom settings to be saved
        """
        try:
            # IronPython WorkItemId=12283 workaround START...
            if sys.platform == 'cli':
                FS_ROOT = 'C:\\Program Files'
                thisfile = os.path.join( FS_ROOT, 'pswrdgeniron', 'pswrdgen.py')
            else:
                thisfile = sys.argv[0]
            # IronPython WorkItemId=12283 workaround END
            # Create the list of lines
            self.lineList = open(thisfile, 'r').readlines()
            # Find the first line of the settings '"""config'
            i = 0
            completed = False
            for line in self.lineList:
                if((line.find('"""config') != -1) and (completed == False)):
                    #We found the first line, so go to the next b/c they are settings
                    i = i + 1  # index tracking
                    ##Assign the settings...
                    ivalue = self.lineList[i].split('::') #split in two
                    self.GENCOUNT = int(ivalue[1].replace("\n", "").strip())
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.GENCOUNT) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    self.MINLENGTH = int(ivalue[1].replace("\n", "").strip())
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.MINLENGTH) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    self.MAXLENGTH = int(ivalue[1].replace("\n", "").strip())
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.MAXLENGTH) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    self.CAPLENGTH = int(ivalue[1].replace("\n", "").strip())
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.CAPLENGTH) + "\n"
        
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    tempstr = ivalue[1].replace("\n", "").strip()
                    self.SWAPS = {}            ## w/IPA4 exception:SyntaxError: unexpected token '<'
                    self.SWAPS = eval(tempstr) ## asking IronPython team about this one
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.SWAPS) + "\n"
        
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    self.ADDCHAR = ivalue[1].replace("\n", "").strip()
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.ADDCHAR) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    self.ADDCOUNT = int(ivalue[1].replace("\n", "").strip())
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.ADDCOUNT) + "\n"
        
                    # Make sure we stop looking at the rest of the .py mod or we will get errors
                    completed = True
                else:
                    i = i + 1  # index tracking
        except NameError, x:
            print 'Exception: ', x
            
    def _savesettings(self):
        try:
            # IronPython WorkItemId=12283 workaround START...
            if sys.platform == 'cli':
                FS_ROOT = 'C:\\Program Files'
                thisfile = os.path.join( FS_ROOT, 'pswrdgeniron', 'pswrdgen.py')
            else:
                thisfile = sys.argv[0]
            # IronPython WorkItemId=12283 workaround END
            
            modfile = open(thisfile, 'w')
            i = 0
            completed = False
            for line in self.lineList:
                if((line.find('"""config') != -1) and (completed == False)):
                    #We found the first line, so go to the next b/c they are settings
                    i = i + 1  # index tracking
                    ##Assign the settings...
                    ivalue = self.lineList[i].split('::') #split in two
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.GENCOUNT) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.MINLENGTH) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.MAXLENGTH) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.CAPLENGTH) + "\n"
        
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.SWAPS) + "\n"
        
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.ADDCHAR) + "\n"
                    
                    i = i + 1  # index tracking
                    ivalue = self.lineList[i].split('::') #split in two
                    #Rewrite the setting line
                    self.lineList[i] = ivalue[0] + "::" + str(self.ADDCOUNT) + "\n"
        
                    # Make sure we stop looking at the rest of the .py mod or we will get errors
                    completed = True
                else:
                    i = i + 1  # index tracking
            modfile.writelines(self.lineList)
            modfile.close()     
            print "all defaults saved!"
        except NameError, x:
            print '_savesettings Exception: ', x

    def run(self):
        """Generate one password"""
        # Pick a random word of valid length
        curword = ''
        maxlength = min(self.MAXLENGTH, self.wordlengthcap) - self.ADDCOUNT
        while True:
            curword = self.wordnetlist[random.randrange(0, len(self.wordnetlist))]
            if (self.MINLENGTH <= len(curword) <= self.MAXLENGTH):
                break #Make sure we break no matter what
        wordlength = len(curword)
        
        #DO replacement swaps here
        for k, v in self.SWAPS.iteritems():
            curword = curword.replace(k, str(v))
        
        # Capitalise self.CAPLENGTH or all letters
        wordcharlist = list(curword)
        capitalise = min(self.CAPLENGTH, sum(1 for c in wordcharlist if c.isalpha() and c.islower()))
        while capitalise:
            randnum = random.randrange(0, wordlength)
            if wordcharlist[randnum].isalpha() and wordcharlist[randnum].islower():
                capitalise -= 1
                wordcharlist[randnum] = wordcharlist[randnum].upper()
        
        for i in range(self.ADDCOUNT):
            randnum = random.randrange(0, len(wordcharlist))
            randchar = random.randrange(0, len(self.ADDCHAR))
            wordcharlist = wordcharlist[:randnum] + [self.ADDCHAR[randchar]] + wordcharlist[randnum:]
            
        return ''.join(wordcharlist)


def test():
    i = pswrdgen()
    i.menu() 
    
if __name__ == '__main__':
    test()
