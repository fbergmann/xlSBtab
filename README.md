## xlSBtab - an SBtab Excel 2013 Add-in 
This project hosts a basic Excel Plugin, for opening an [SBML](http://sbml.org) file within Excel and have it be converted to the SBtab format. Alternatively a file edited in the [SBtab](http://sbtab.net/) format can be exported as SBML file. 

### Dependencies
For the program to work, you will need to have the following installed: 

* a version of [python 2.x](http://python.org)
* the [libSBML python bindings](http://sbml.org/Software/libSBML) for that python version
* Excel 2013 to run the plugin
* a checkout of the [SBtab repository](https://github.com/derHahn/SBtab)

### Installation
After you installed the plugin, you will find a new tab called 'SBtab' in the Add-ins ribbon menu. On that tab, click settings to verify the python path, and the SBtab location. 

The add in has four options: 

![SBTab options](https://raw.githubusercontent.com/fbergmann/xlSBtab/master/images/addin_options.png)

* **Import SBML**: imports an SBML file and replaces the contents of the current sheet with SBtab tables representing that file.
* **Export SBML**: translates the tables of the current sheet back into an SBML file. 
* **Validate**: currently ensures only that the tables have the expected headers. It does not yet validate the entries in the table. 
* **Settings**: specify the path to the python interpreter, and the SBtab script directory. 

Once a model is imported it will be displayed like in the example below (here BioModel 10 was imported): 

![SBtab of BioModel 10](https://raw.githubusercontent.com/fbergmann/xlSBtab/master/images/screenshot.png)

## License

This project is open source and freely available under the [Simplified BSD](http://opensource.org/licenses/BSD-2-Clause) license. Should that license not meet your needs, please contact me. 

Copyright (c) 2015, Frank T. Bergmann  
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met: 

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer. 
2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.   
  
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.