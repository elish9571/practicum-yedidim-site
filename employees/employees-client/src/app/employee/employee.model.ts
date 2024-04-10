import { Job } from "../job/job.model"

export class Employee {
    firstName!:string
    lastName!: string
    tz!:string
    beginningOfWork!: Date  
    birthDate!:Date
    isMale!: boolean 
    jobs: Job[] = []   
}