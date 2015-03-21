# pswrdgen #
Every Systems and Network Admin needs a good random password generator.  pswrdgen is a semantic password generator that uses [WordNet](http://wordnet.princeton.edu/obtain) 2.1 for Windows and 3.0 for UNIX-like systems, random capitalization, and character swapping.  Passwords should not be so difficult that you can not remember them. pswrdgen is a 0.2.x Python project.  Generate random passwords on the fly.

Features:
  * Uses custom words or phrase lists
  * Random inserts of special or any characters
  * Supports optional character swapping / substitutions
  * Define character lengths to be returned
  * Define number of random capital letters to assign

pswrdgeniron is a Microsoft Windows(c) GUI that runs on [IronPython](http://www.codeplex.com/IronPython).  pswrdgeniron has been released. IronPython has limited support for Python25 and may produce errors. However, the pswrdgen.py module will still run in CLR for Python25.

# Downloads #
## pswrdgen: Python module ##
http://code.google.com/p/pswrdgen/downloads/list

## pswrdgeniron: Windows Install File ##
http://code.google.com/p/pswrdgen/downloads/list

(NOTE: Windows7 installs need to change the default install directory to 'C:\Program Files' or you will need to manually edit the .py file, then copy the WordNet index.noun file to the pswrdgeniron install folder and add that to the 'Current Word Files in use', then remove the old WordNet 2.1 index.noun file.)

### Python24 ###
pswrdgeniron needs: http://www.python.org/ftp/python/2.4.4/python-2.4.4.msi


# screenshots #
| ![http://joeswammi.com/python/docs/pswrdgen/pswrdgen262x391.jpg](http://joeswammi.com/python/docs/pswrdgen/pswrdgen262x391.jpg) | ![http://joeswammi.com/python/docs/pswrdgen/pswrdgeniron302x320.jpg](http://joeswammi.com/python/docs/pswrdgen/pswrdgeniron302x320.jpg)|
|:--------------------------------------------------------------------------------------------------------------------------------|:---------------------------------------------------------------------------------------------------------------------------------------|

