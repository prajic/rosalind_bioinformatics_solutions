import * as types from "./types";

function kmer(text: string, start: number, next: number): string {
  // get substring starting at i and next k letters
  return text
    .split("")
    .slice(start, start + next)
    .join("");
}

function getPatternCount(pattern: string, text: string) {
  // count occurances of pattern within a text
  let count: number = text
    .split("")
    .map((_, index) => kmer(text, index, pattern.length))
    .filter((el) => Boolean(el) && pattern.length == el.length)
    .filter((el) => el === pattern).length;

  return count;

  // this way has
}

function countAllKmers(text, k): types.PatternCount[] {
  let allPatterns: Object = {};
  text
    .split("")
    .map((_, index) => kmer(text, index, k))
    .filter((el) => Boolean(el) && k == el.length)
    .forEach((pattern) => {
      if (!allPatterns[pattern]) {
        allPatterns[pattern] = 1;
      } else {
        allPatterns[pattern]++;
      }
    });
  const arrayOfPatterns: types.PatternCount[] = Object.entries(allPatterns).map(
    ([key, value]) => {
      return { pattern: key, count: value };
    }
  );

  return arrayOfPatterns;
}

function getMostFrequentKmer(text, k): types.PatternCount {
  return countAllKmers(text, k).sort((a, b) => b.count - a.count)[0];
}

function getComplementOfCharacter(character: string): string {
  if (character.toUpperCase() === "A") {
    return "T";
  } else if (character.toUpperCase() === "G") {
    return "C";
  } else if (character.toUpperCase() === "T") {
    return "A";
  } else if (character.toUpperCase() === "C") {
    return "G";
  } else return character.toUpperCase();
}

function getReverseComplement(text: string): string {
  return text.split("").reverse().map(getComplementOfCharacter).join("");
}

function getPatternMatchesIndexes(pattern: string, text: string): string {
  let indexes = [];
  text
    .split("")
    .map((_, index) => kmer(text, index, pattern.length))
    .filter((el) => Boolean(el) && pattern.length == el.length)
    .forEach((el, index) => {
      if (el === pattern) {
        indexes.push(index);
      }
    });
  return indexes.join(" ");
}

function getDistinctKmersForminLTClamp(
  clumpExample: types.ClumpExample
): string {
  const resultPatterns = [];
  clumpExample.text
    .split("")
    .map((_, index) => kmer(clumpExample.text, index, clumpExample.L))
    .filter((el) => Boolean(el) && el.length === clumpExample.L)
    .forEach((pattern) => {
      let allPatterns = countAllKmers(pattern, clumpExample.k);
      allPatterns.forEach((kpattern) => {
        if (kpattern.count >= clumpExample.t) {
          if (!resultPatterns.includes(kpattern.pattern)) {
            resultPatterns.push(kpattern.pattern);
          }
        }
      });
    });

  return resultPatterns.join(" ");
}

function prefix(genome: string): number[] {
  let prefix = 0;
  return genome.split("").map((character) => {
    if (character.toUpperCase() === "G") {
      prefix++;
    } else if (character.toUpperCase() === "C") {
      prefix--;
    }
    return prefix;
  });
}

function skew(genome: string): number {
  let nbC = 0;
  let nbG = 0;

  genome.split("").forEach((character) => {
    if (character.toUpperCase() === "C") {
      nbC++;
    } else if (character.toUpperCase() === "G") {
      nbG++;
    }
  });

  return nbG - nbC;
}

function findIndexesMinimizingSkew(genome: string) {
  const results: number[] = [];
  const prefixedGenome = prefix(genome);
  const min = Math.min(...prefixedGenome);
  prefixedGenome.forEach((el, index) => {
    if (el === min) {
      results.push(index + 1);
    }
  });

  return results.join(" ");
}

function getHammingDistance(
  firstGenome: string,
  secondGenome: string
): number | string {
  if (firstGenome.length - secondGenome.length != 0)
    return "Wrong input parameters";
  const n = firstGenome.length;
  let hammingDistance = 0;

  for (let i = 0; i < n; i++) {
    if (firstGenome[i] != secondGenome[i]) {
      hammingDistance++;
    }
  }
  return hammingDistance;
}

function getApproximatePatternMatches({
  pattern,
  text,
  nbMismatches,
}: types.PatternMatchingProblem): string {
  const results: number[] = [];
  text
    .split("")
    .map((_, index) => kmer(text, index, pattern.length))
    .filter((el) => Boolean(el) && pattern.length === el.length)
    .forEach((el, index) => {
      if (getHammingDistance(pattern, el) <= nbMismatches) {
        results.push(index);
      }
    });
  return results.join(" ");
}


function getBaseKmers(k:number):string[]{
  const nucleotides = ["A", "T", "G", "C"];
  return nucleotides.map(nucleotide=>nucleotide.repeat(k))
}

function replaceKmerAtIndex(pattern:string,replacement:string,index:number){
  return pattern.substring(0, index) + replacement + pattern.substring(index + 1);
}

function generateAllKmers(k:number):string[]{
  const nucleotides = ["A", "T", "G", "C"];

  let allKmers:string[]=getBaseKmers(k)
  for(let i=0;i<k;i++){
    allKmers.forEach(pattern=>{
      nucleotides.forEach(nucleotide=>{
        let newPattern=replaceKmerAtIndex(pattern,nucleotide,i)
        if(!allKmers.includes(newPattern)){
          allKmers.push(newPattern)
        }
      })
      
    })
  }
  return allKmers
}


function countPatternUpToDMismatches(text:string,pattern:string,d:number):number{
  return text .split("")
  .map((_, index) => kmer(text, index, pattern.length))
  .filter((el) => Boolean(el) && pattern.length == el.length)
  .filter((el) => getHammingDistance(el,pattern)<=d).length;
}

function getReverseComplementCount(text:string,pattern){
  const reverseComplement=getReverseComplement(pattern)
  return getPatternCount(reverseComplement,text)
}

function getMostFrequentWordWithUpToDMismatches({
  text,
  k,
  d,
}: types.FrequentWordMismatchesProblem) {
  let results:string[]=[]

  let allPatterns=generateAllKmers(k)
  let allPatternsWithCount:types.PatternCount[]=[]

  allPatterns.forEach(pattern=>{
    allPatternsWithCount.push({pattern,count:countPatternUpToDMismatches(text,pattern,d)})
  })

  const max=allPatternsWithCount.sort((a, b) => b.count - a.count)[0].count

  allPatternsWithCount.forEach(pattern=>{
    if(pattern.count===max){
      results.push(pattern.pattern)
    }
  })
  return results.join(" ")

}

function getMostFrequentWordWithUpToDMismatchesAndComplement({
  text,
  k,
  d,
}: types.FrequentWordMismatchesProblem) {
  let results:string[]=[]

  let allPatterns=generateAllKmers(k)
  let allPatternsWithCount:types.PatternCount[]=[]
  allPatterns.forEach(pattern=>{
    allPatternsWithCount.push({pattern,count:countPatternUpToDMismatches(text,pattern,d)+countPatternUpToDMismatches(text,getReverseComplement(pattern),d)})
  })
  const max=allPatternsWithCount.sort((a, b) => b.count - a.count)[0].count

  allPatternsWithCount.forEach(pattern=>{
    if(pattern.count===max){
      results.push(pattern.pattern)
    }
  })
  return results.join(" ")

}
export {
  kmer,
  getPatternCount,
  getMostFrequentKmer,
  getReverseComplement,
  getPatternMatchesIndexes,
  getDistinctKmersForminLTClamp,
  findIndexesMinimizingSkew,
  getHammingDistance,
  getApproximatePatternMatches,
  getMostFrequentWordWithUpToDMismatches,
  getMostFrequentWordWithUpToDMismatchesAndComplement
};
