import { JobPosition } from "../jobPosition/jobPosition.model"

export class Employee {
    id!:number
    firstName!:string
    lastName!: string
    tz!:string
    beginningOfWork!: Date  
    birthDate!:Date
    isMale!: boolean 
    isDeleted!:boolean
    jobPositions:JobPosition[] = []   
}