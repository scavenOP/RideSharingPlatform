export class Vehicle{
    registrationNo: string;
    belongsToUserId: number;
    vehicleTypeId: number;
    vehicleType: {
      id: number,
      type: string,
      maxPassengersAllowed: number,
      farePerKM: number
    };
    inspectionStatus: string;
    rtoName: string;
    registrationDate: Date|null;
    registrationExpiresOn: Date|null;
    insuranceCompanyName: string;
    insuranceNo: string;
    insurancedOn: Date|null;
    insuranceExpiresOn: Date|null;
    pucCertificateNo: number;
    pucIssuedOn: Date|null;
    pucValidUntil: Date|null;

    constructor(registrationNo: string,
    belongsToUserId: number,
    vehicleTypeId: number,
    vehicleType: {
      id: number,
      type: string,
      maxPassengersAllowed: number,
      farePerKM: number
    },
    inspectionStatus: string,
    rtoName: string,
    registrationDate: Date|null,
    registrationExpiresOn: Date|null,
    insuranceCompanyName: string,
    insuranceNo: string,
    insurancedOn: Date|null,
    insuranceExpiresOn: Date|null,
    pucCertificateNo: number,
    pucIssuedOn: Date|null,
    pucValidUntil: Date|null,
    ){
        this.registrationNo=registrationNo;
        this.belongsToUserId= belongsToUserId;
    this.vehicleTypeId= vehicleTypeId;
    this.vehicleType=vehicleType;
    this.inspectionStatus=inspectionStatus;
    this.rtoName=rtoName;
    this.registrationDate=registrationDate;
    this.registrationExpiresOn=registrationExpiresOn;
    this.insuranceCompanyName=insuranceCompanyName;
    this.insuranceNo=insuranceNo;
    this.insurancedOn=insurancedOn;
    this.insuranceExpiresOn=insuranceExpiresOn;
    this.pucCertificateNo=pucCertificateNo;
    this.pucIssuedOn=pucIssuedOn;
    this.pucValidUntil=pucValidUntil;
    }
}