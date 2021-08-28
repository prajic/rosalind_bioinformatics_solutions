// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Minimum Skew Problem
// Rosalind ID: BA1F
// URL: http://rosalind.info/problems/ba1f/

import * as types from "../utils/types"
import * as constants from "../utils/constants";
import * as service from "../utils/service";

const firstGenome=constants.taskBA1FFirstExample
const secondGenome=constants.taskBA1FSecondExample


const resultFirst=service.findIndexesMinimizingSkew(firstGenome)
const resultSecond=service.findIndexesMinimizingSkew(secondGenome)

console.log(resultFirst)
console.log(resultSecond)