// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Pattern Matching Problem
// Rosalind ID: BA1D
// URL: http://rosalind.info/problems/ba1d/

import * as types from "../utils/types"
import * as constants from "../utils/constants";
import * as service from "../utils/service";

const firstExample=constants.taskBA1DFirstExample
const secondExample=constants.taskBA1DSecondExample

const patternMatchesFirst=service.getPatternMatchesIndexes(firstExample.pattern,firstExample.text)
const patternMatchesSecond=service.getPatternMatchesIndexes(secondExample.pattern,secondExample.text)

function writeMessageToConsole(patternMatchesResult:string,taskExample:types.TaskExample){
    console.log(`Matches of pattern ${taskExample.pattern} in text ${taskExample.text} are indexes ${patternMatchesResult}`)
}

writeMessageToConsole(patternMatchesFirst,constants.taskBA1DFirstExample)
writeMessageToConsole(patternMatchesSecond,constants.taskBA1DSecondExample)

