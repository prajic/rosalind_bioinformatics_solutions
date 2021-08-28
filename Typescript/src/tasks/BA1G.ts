// A solution to a ROSALIND bioinformatics problem.
// Problem Title: Hamming Distance Problem
// Rosalind ID: BA1G
// URL: http://rosalind.info/problems/ba1g/

import * as constants from "../utils/constants";
import * as service from "../utils/service";

const hammingDistanceFirstExample=constants.taskBA1GFirstExample
const hammingDistanceSecondExample=constants.taskBA1GSecondExample

const resultFirstExample=service.getHammingDistance(hammingDistanceFirstExample.firstText,hammingDistanceFirstExample.secondText)
const resultSecondExample=service.getHammingDistance(hammingDistanceSecondExample.firstText,hammingDistanceSecondExample.secondText)

console.log(resultFirstExample)
console.log(resultSecondExample)