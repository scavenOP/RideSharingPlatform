export class ApplicationRequest{
    userId:number;
    username:string;
    officialEmail:string;
    phoneNumber:string;
    designation:string;
    roleId:number;
    employeeeId:string;
    aadharNumber:string;
    companyId: number;
    licenseNo: string ="";
    expirationDate: Date | null;
    rta: string;
    alowedVehicles:string;
    applicationStatus:string;

    constructor(userId:number,
        username:string,
        officialEmail:string,
        phoneNumber:string,
        designation:string,
        roleId:number,
        employeeeId:string,
        aadharNumber:string,
        companyId: number,
        licenseNo: string,
        expirationDate: Date,
        rta: string,
        alowedVehicles:string){
            this.userId = userId;
    this.username=username;
    this.officialEmail=officialEmail;
    this.phoneNumber=phoneNumber;
    this.designation=designation;
    this.roleId=roleId;
    this.employeeeId=employeeeId;
    this.aadharNumber=aadharNumber;
    this.companyId =companyId;
    this.licenseNo=licenseNo;
    this.expirationDate=expirationDate;
    this.rta=rta;
    this.alowedVehicles=alowedVehicles;
        }
}