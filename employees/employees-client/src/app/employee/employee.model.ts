import { JobPosition } from "../jobPosition/jobPosition.model"

export class Employee {
    firstName!:string
    lastName!: string
    tz!:string
    beginningOfWork!: Date  
    birthDate!:Date
    isMale!: boolean 
    isDeleted!:boolean
    jobPositions: JobPosition[] = []   
}