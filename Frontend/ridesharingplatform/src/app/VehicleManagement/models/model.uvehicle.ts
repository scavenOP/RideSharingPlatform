export class UVehicle{
    registrationNo:String;
      inspectionStatus:String;
      inspectionByUserId:number;
      inspectedOn:Date
      constructor(registrationNo:String,
        inspectionStatus:String,
        inspectionByUserId:number,
        inspectedOn:Date){
            this.registrationNo=registrationNo;
      this.inspectionStatus=inspectionStatus;
      this.inspectionByUserId=inspectionByUserId;
      this.inspectedOn=inspectedOn;
        }

}