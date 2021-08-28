export interface TaskExample{
    text:string
    pattern:string
}
export interface PatternCount{
    pattern:string
    count:number
}

export interface ClumpExample{
    text:string,
    k:number,
    L:number,
    t:number
}

export interface TextPair{
    firstText:string,
    secondText:string
}

export interface PatternMatchingProblem{
    pattern:string,
    text:string,
    nbMismatches:number
}

export interface FrequentWordMismatchesProblem{
    text:string,
    k:number,
    d:number
}