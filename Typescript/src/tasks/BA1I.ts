// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Frequent Words with Mismatches Problem
// Rosalind ID: BA1I
// URL: http://rosalind.info/problems/ba1i/

import * as constants from "../utils/constants";
import * as service from "../utils/service";

const frequentWordMismatchesFirstExample=constants.taskBA1IFirstExample

const resultFirstExample=service.getMostFrequentWordWithUpToDMismatches(frequentWordMismatchesFirstExample)

console.log(resultFirstExample)
