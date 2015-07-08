#!/usr/bin/env python
import re, libsbml, numpy, sys, sbml2sbtab

reader = libsbml.SBMLReader()
sbml   = reader.readSBML(sys.argv[1])
model  = sbml.getModel()
sbml_class = sbml2sbtab.SBMLDocument(model,sys.argv[1])
sbtabfiles = sbml_class.makeSBtabs()[0]

for i in range(0, len(sbtabfiles)): 
  tab = sbtabfiles[i]
  bla = open('{0}.tsv'.format(sbml2sbtab.allowed_sbtabs[i]),'w')
  
  for i in range(0, len(tab)-1):
    bla.write(tab[i])
  bla.write('\n')
  bla.close()      

