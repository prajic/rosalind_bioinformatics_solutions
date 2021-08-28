// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Approximate Pattern Matching Problem
// Rosalind ID: BA1H
// URL: http://rosalind.info/problems/ba1h/

import * as constants from "../utils/constants";
import * as service from "../utils/service";

const patternMatchingFirstExample=constants.taskBA1HFirstExample
const patternMatchingSecondExample=constants.taskBA1HSecondExample

const resultFirstExample=service.getApproximatePatternMatches(patternMatchingFirstExample)
const resultSecondExample=service.getApproximatePatternMatches(patternMatchingSecondExample)

console.log(resultFirstExample)
console.log(resultSecondExample)