//
// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Find the Most Frequent Words in a String
// Rosalind ID: BA1B
// URL: http://rosalind.info/problems/ba1b/
//


import * as constants from "../utils/constants";
import * as service from "../utils/service";

const pattern = constants.taskText.pattern;

const mostFreq=  service.getMostFrequentKmer(constants.taskText.text, pattern.length)

console.log(`Most frequent pattern is ${mostFreq.pattern} and it has occured ${mostFreq.count} times`)
