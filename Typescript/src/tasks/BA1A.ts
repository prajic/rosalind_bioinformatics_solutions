// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Compute the Number of Times a Pattern Appears in a Text
// Rosalind ID: BA1A
// URL: http://rosalind.info/problems/ba1a/

import * as constants from "../utils/constants";
import * as service from "../utils/service";

const pattern = constants.taskText.pattern;

const countPattern = service.getPatternCount(pattern, constants.taskText.text);

console.log(`Pattern ${pattern} occured ${countPattern} times`)

