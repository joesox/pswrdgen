"""config CONFIGURATION SETTINGS
GENCOUNT::10
MINLENGTH::8
MAXLENGTH::16
CAPLENGTH::2
SWAPS::{'h': 4, 's': 5}
ADDCHAR::'01234567890-_!@$%^&*(),.<>+='
ADDCOUNT::2
WORDFILES::
endconfig"""

### IRONPYTHON SUPPORT START #pswrdgeniron dependency ###
import sys
sys.path.append("C:\\Python24\\Lib")
### IRONPYTHON SUPPORT END   ###
import os, os.path, random, re, glob
__version__ = '0.4.10' #pswrdgeniron dependency
__author__ = "Joseph P. Socoloski III, Edward Saxton"
__url__ = 'http://pswrdgen.googlecode.com'
__doc__ = 'Semantic Password generator that uses WordNet, random capitalization, and character swapping.Prerequisite:WordNet'


def getint(msg, default, low):
    """
        Repeatedly ask the user the question <msg> until they
        provide an intger <= low or an empty line when the default is used
    """
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
    """
        Print a line of length <length> with a * at each end and <line> in the body
        <div> determins where the line should be justified
        1 right justified
        2 centered
        use any large number for left
    """
    pad = max(0, (length-len(line))/div)
    print "*%*s%-*s *" %(pad+1, ' ', length-pad, line)


def box(length, justify, *lines):
    """
        Disaply <lines> in a box of *'s width <length>
        Split each line at < >  if to long
        Justify gives the overall text justification
            c: center
            r: right
            default left
    """
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
    """
        Create a menu of width <width> from a tuple of one description, function/method per option
        Add an exit method at the end of the list
        Display with each option being given an integer key in order starting from 1
        Repeatedly ask for an option and call the linked function untill asked to stop
        The menu can also be left by entering 'exit'
    """
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
    #pswrdgeniron dependency
    """
    
    def __init__(self):
        """
        Decides what the operating system is and chooses the install directory of WordNet
        Assign the default values to the instance before calling run()
        """
        #Read the previous settings and load into vars
        self.loadsettings()

    def _find_wordnet(self)
        self.WORDFILELISTS = [] #pswrdgeniron dependency
        self.cache = False
        self.wordnetlist = set()
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
        self.addnounfile(WORDNETPATH)

    def do_setup(self):
        """Must leave method for pswrdgeniron backwards compatibility #pswrdgeniron dependency"""
        self.__init__()
    
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
                ('Add new word file', self._add_file),
                ('Remove word file', self._drop_file),
                ('Change all defaults', self.changedefaults),
                ('Display defaults', self.printdefaults),
                ('Save all defaults/settings', self._savesettings))
                
    def _input_count(self):
        """ self.GENCOUNT """
        self.GENCOUNT = getint("How many passwords do you wish to generate", self.GENCOUNT, 1) #pswrdgeniron dependency
    
    def _input_length(self):
        """ self.MINLENGTH, self.MAXLENGTH """
        self.MINLENGTH = getint("What is the minimum length of your password", self.MINLENGTH, 3) #pswrdgeniron dependency
        self.MAXLENGTH = getint("What is the maximum length of your password ", self.MAXLENGTH, self.MINLENGTH) #pswrdgeniron dependency
        self.cache = False
    
    def _cap_count(self):
        """ self.CAPLENGTH """
        self.CAPLENGTH = getint("How many capital letters in your password ", self.CAPLENGTH, 1) #pswrdgeniron dependency

    def _add_count(self):
        """ self.ADDCOUNT """
        self.ADDCOUNT = getint("How many extra numbers/punctuation in your password ", self.ADDCOUNT, 0) #pswrdgeniron dependency
        self.cache = False
    
    def _input_punctuation(self):
        """ self.ADDCHAR """
        try:
            userinput = raw_input("Type in your number and punctuation characters (default=%s)?: "%self.ADDCHAR)
            if userinput:
                self.ADDCHAR = userinput #pswrdgeniron dependency
        except (NameError, SyntaxError):
            pass # Ignore invalid user input
    
    def _input_swaps(self):
        """ self.SWAPS """
        try:
            userinput = input("Type in your swap rules dictionary(default=%s)?: "%self.SWAPS)
            if userinput:
                self.SWAPS = dict(userinput) #pswrdgeniron dependency
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

    def _add_file(self):
        """ text interface for adding a new word file """
        print
        print 'Current word files:'
        for s in self.WORDFILELISTS:
            print '\t%s'%s
        print
        userinput = raw_input("What file do you want to add: ").strip()
        if userinput:
            self.addnounfile(userinput)
            self.cache = False

    def _drop_file(self):
        """ text interface for dropping a new word file """
        print
        print 'Current word files:'
        for i, s in enumerate(self.WORDFILELISTS):
            print '\t%2i\t%s'%(i+1, s)
        print
        userinput = getint("Which file do you want to remove (0 or empty line to escape): ", 0, 0)
        if userinput:
            self.removenounfile(self.WORDFILELISTS[userinput-1])
            self.cache = False
    
    def _generate(self):
        """
        Generate self.GENCOUNT passwords in one go haveing the wordlist loaded fresh
        Display the words to the user or if none match explain this
        """
        for i in range(self.GENCOUNT):
            pswrd = self.run()
            if not pswrd:
                print 'There are no words that match your requirement'
                break
            print pswrd

    def printdefaults(self):
        """Print the configuration defaults to the console"""
        print "MINLENGTH: " + str(self.MINLENGTH)
        print "MAXLENGTH: " + str(self.MAXLENGTH)
        print "CAPLENGTH: " + str(self.CAPLENGTH)
        print "SWAPS: " + str(self.SWAPS)
        print "INSERT No.: " + str(self.ADDCOUNT)
        print "INSERT OPTIONS: " + str(self.ADDCHAR)
        print
        print 'Current word files:'
        for s in self.WORDFILELISTS:
            print '\t%s'%s
        print

    
    def addnounfile(self, source):
        """ Add a path+filename to the list of word files. #pswrdgeniron dependency """
        if os.path.exists(source) and source not in self.WORDFILELISTS:
            self.WORDFILELISTS.append(source)#pswrdgeniron dependency
            self.cache = False
    
    def removenounfile(self, source):
        """ Remove a path+filename from the list of word files. #pswrdgeniron dependency """
        if source in self.WORDFILELISTS:
            self.WORDFILELISTS.remove(source)#pswrdgeniron dependency
            self.cache = False

    def loadsettings(self):
        """
        loadsettings() reads the variable lines after '\"\"\"config' in this file
        then assigns them to there variables. This allows for custom settings to be saved
        #pswrdgeniron dependency
        """
        try:
            # IronPython WorkItemId=12283 workaround START...
            if sys.platform == 'cli':
                FS_ROOT = 'C:\\Program Files'
                thisfile = os.path.join( FS_ROOT, 'pswrdgeniron', 'pswrdgen.py')
            else:
                thisfile = sys.argv[0]
            # IronPython WorkItemId=12283 workaround END
            self.lineList = open(thisfile, 'r').readlines()
            # Find the first line of the settings '"""config'
            for i, line in enumerate(self.lineList):
                if '"""config' in line:
                    # Each setting is defined in order on a line in the form
                    # "header::value" with the value encoded as a string
                    self.GENCOUNT = int(self.lineList[i+1].split('::')[1].strip())
                    self.MINLENGTH = int(self.lineList[i+2].split('::')[1].strip())
                    self.MAXLENGTH = int(self.lineList[i+3].split('::')[1].strip())
                    self.CAPLENGTH = int(self.lineList[i+4].split('::')[1].strip())
                    self.SWAPS = eval(self.lineList[i+5].split('::')[1].strip())
                    self.ADDCHAR = self.lineList[i+6].split('::')[1].strip()
                    self.ADDCOUNT = int(self.lineList[i+7].split('::')[1].strip())
                    self.WORDFILELISTS = self.lineList[i+8].split('::')[1].strip().split('..')
                    self.WORDFILELISTS = [i for i in self.WORDFILELISTS if i]
                    if not self.WORDFILELISTS:
                        self._find_wordnet()
                    break
        except NameError, x:
            print 'Exception: ', x
            
    def _savesettings(self):
        """ Save the settings to this module file #pswrdgeniron dependency """
        try:
            # IronPython WorkItemId=12283 workaround START...#pswrdgeniron dependency
            if sys.platform == 'cli':
                FS_ROOT = 'C:\\Program Files'
                thisfile = os.path.join( FS_ROOT, 'pswrdgeniron', 'pswrdgen.py')
            else:
                thisfile = sys.argv[0]
            # IronPython WorkItemId=12283 workaround END

            files = '..'.join(self.WORDFILELISTS)
            for i, line in enumerate(self.lineList):
                if '"""config' in line :
                    for j, var in enumerate((self.GENCOUNT, self.MINLENGTH, self.MAXLENGTH, self.CAPLENGTH, self.SWAPS, self.ADDCHAR, self.ADDCOUNT, files)):
                        mark = i+j+1
                        header = self.lineList[mark].split('::')[0]
                        self.lineList[mark] = '%s::%s\n'%(header, var)
                    break
                
            modfile = open(thisfile, 'w')
            modfile.writelines(self.lineList)
            modfile.close()
            print "all defaults saved!"
        except NameError, x:
            print '_savesettings Exception: ', x
    
    def updatecache(self):
        """
        Build a list of all valid words in all files in the self.WORDFILELISTS and store in self.cache
        Each word appears only once in the list
        A word is a sequenc of x letters at the start of the line followed by a white space
        with the contraint self.MINLENGTH <= x-self.ADDCOUNT <= self.MAXLENGTH 
        """
        # Define what a word is (using the above def) in a RegExp
        low = self.MINLENGTH-self.ADDCOUNT
        high = self.MAXLENGTH-self.ADDCOUNT
        match = re.compile('^([a-zA-Z]{%i,%i})\s'%(low, high), re.M)

        allwords = set()    # Store the collection in a set to avoid duplicates
        for f in self.WORDFILELISTS: # for each file
            data = open(f, 'r')
            try:
                for l in data: # for each line
                    m = match.search(l) # look for a match
                    if m: # if there is one
                        allwords.add(m.group()) # add it
            finally:
                data.close()
        self.cache = list(allwords) # Convert from a set to a list for indexing

    def run(self):
        """Generate one password #pswrdgeniron dependency"""
        if not self.cache:
            self.updatecache()
        if not len(self.cache):
            return ''
        else:
            return self.modifyword(random.choice(self.cache))

    def modifyword(self, curword):
        """ Given a word returns is with the current mutations applied"""
        wordlength = len(curword)
        
        # Replacement swaps here
        for k, v in self.SWAPS.iteritems():
            curword = curword.replace(k, str(v))

        # Capitalise self.CAPLENGTH or all letters
        wordcharlist = list(curword)
        capitalise = min(self.CAPLENGTH, sum(1 for c in wordcharlist if c.isalpha() and c.islower()))
        while capitalise:
            randnum = random.randrange(0, len(curword))
            if wordcharlist[randnum].isalpha() and wordcharlist[randnum].islower():
                capitalise -= 1
                wordcharlist[randnum] = wordcharlist[randnum].upper()
        
        # Add extra characters
        for i in range(self.ADDCOUNT):
            randnum = random.randrange(0, len(wordcharlist))
            randchar = random.choice(self.ADDCHAR)
            wordcharlist = wordcharlist[:randnum] + [randchar] + wordcharlist[randnum:]

        # Recombine and return
        return ''.join(wordcharlist)


def test():
    i = pswrdgen()
    i.menu() 
    
if __name__ == '__main__':
    test()
