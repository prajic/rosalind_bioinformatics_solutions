// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Frequent Words with Mismatches and Reverse Complements Problem
// Rosalind ID: BA1J
// URL: http://rosalind.info/problems/ba1j/

import * as constants from "../utils/constants";
import * as service from "../utils/service";

const frequentWordMismatchesFirstExample=constants.taskBA1JFirstExample
const frequentWordMismatchesSecondExample=constants.taskBA1JSecondExample

const resultFirstExample=service.getMostFrequentWordWithUpToDMismatchesAndComplement(frequentWordMismatchesFirstExample)
const resultSecondExample = service.getMostFrequentWordWithUpToDMismatchesAndComplement(frequentWordMismatchesSecondExample);

console.log(resultFirstExample)
console.log(resultSecondExample);
