#!/usr/bin/env python
import re, libsbml, numpy, sys, sbml2sbtab

def convertToSBtabs(filename, outdir): 
  
  reader = libsbml.SBMLReader()
  sbml   = reader.readSBML(filename)
  model  = sbml.getModel()
  sbml_class = sbml2sbtab.SBMLDocument(model,filename)
  sbtabfiles = sbml_class.makeSBtabs()[0]
  
  for i in range(0, len(sbtabfiles)): 
    tab = sbtabfiles[i]
    bla = open('{0}/{1}.tsv'.format(outdir, sbml2sbtab.allowed_sbtabs[i]),'w')
    
    for i in range(0, len(tab)-1):
      bla.write(tab[i])
    bla.write('\n')
    bla.close()      

if __name__ == '__main__':
  convertToSBtabs(sys.argv[1], sys.argv[2])