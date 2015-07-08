#!/usr/bin/env python
import re, libsbml, numpy, sys, sbtab2sbml

file = sbtab_reaction = open(sys.argv[1],'r')
document = file.read();
file.close();
sbtab_class = sbtab2sbml.SBtabDocument(document,sys.argv[1])
bla = sbtab_class.makeSBML()

output = open('new_sbml.xml','w')
output.write(bla[0])

output.close()