// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Reverse Complement Problem
// Rosalind ID: BA1C
// URL: http://rosalind.info/problems/ba1c/

import * as constants from "../utils/constants";
import * as service from "../utils/service";

const textFirst = constants.textComplementExampleFirst;
const textSecond = constants.textComplementExampleSecond;

const reverseComplementFirst=  service.getReverseComplement(textFirst)
const reverseComplementSecond=  service.getReverseComplement(textSecond)

console.log(`Reverse complement of ${textFirst} is ${reverseComplementFirst}`)
console.log(`Reverse complement of ${textSecond} is ${reverseComplementSecond}`)