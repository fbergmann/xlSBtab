#!/usr/bin/env python
import re, libsbml, numpy, sys, sbtab2sbml

def convertToSBML(tabFile, sbmlFile):
  file = sbtab_reaction = open(tabFile,'r')
  document = file.read();
  file.close();
  sbtab_class = sbtab2sbml.SBtabDocument(document,tabFile)
  bla = sbtab_class.makeSBML()
  
  output = open(sbmlFile,'w')
  output.write(bla[0])
  
  output.close()
  

if __name__ == '__main__':
  convertToSBML(sys.argv[1],sys.argv[2])
