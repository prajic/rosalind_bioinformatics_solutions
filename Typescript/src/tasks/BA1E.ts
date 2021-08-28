// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Clump Finding Problem
// Rosalind ID: BA1E
// URL: http://rosalind.info/problems/ba1e/


import * as constants from "../utils/constants";
import * as service from "../utils/service";

const clumpExampleFirst=constants.taskBA1EFirstExample
const clumpExampleSecond=constants.taskBA1ESecondExample

const resultFirstExample=service.getDistinctKmersForminLTClamp(clumpExampleFirst)
const resultSecondExample=service.getDistinctKmersForminLTClamp(clumpExampleSecond)

console.log(resultFirstExample)
console.log(resultSecondExample)