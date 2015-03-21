# Using pswrdgen with IronPython (IP) #

As of this writing, testing with Microsoft's IronPython has just begun.

# Using IronPython's Console with pswrdgen #
Here is an example on how to use pswrdgen with IP's command line interface:
```
IronPython console: IronPython 2.0A4 (2.0.10904.02) on .NET 2.0.50727.832
Copyright (c) Microsoft Corporation. All rights reserved.
>>> import pswrdgen
>>> i = pswrdgen.pswrdgen()
>>> i.menu()
********************************************
*                 pswrdgen                 *
*                  0.4.1                   *
*      http://pswrdgen.googlecode.com      *
* ---------------------------------------- *
*  Semantic Password generator that uses   *
*   WordNet, random capitalization, and    *
* character swapping.Prerequisite:WordNet  *
********************************************
**************************************************************************
* Choose one of the below:                                               *
* 1) Generate 10 password(s)                                             *
* 2) Change generate count (now 10)                                      *
* 3) Change password length (now 8<=length<=8)                           *
* 4) Change capitalisation count (now 2)                                 *
* 5) Change swap dictionary (now {'o': 0, 'i': 1})                       *
* 6) Change number/punctuation insertion (now 0)                         *
* 7) Change number/punctuation list (now '01234567890-_!@$%^&*(),.<>+=') *
* 8) Change all defaults                                                 *
* 9) Display defaults                                                    *
* 10) Save all defaults/settings                                         *
* 11) exit                                                               *
**************************************************************************
>
```

# pswrdgeniron's Official Webpage #
http://www.codeproject.com/useritems/pswrdgeniron.asp