export class Incident {

        incidentID: number;
    
        incidentType: string;
    
        description: string;
    
        status: string;
    
        incidentDate: Date;
    
        reportDate: Date;
    
        bookingId: number;
    
        incidentDetails:string;
    
        incidentReportedByUserId: number;
    
        resolutionETA:number;
    
        incidentSummary:string;
    
        investigatedByUserId:number;
    
     
    
        constructor(incidentID: number, incidentType: string, description: string, status: string, incidentDate: Date,
    
            incidentDetails:string, reportDate: Date, bookingId:number,incidentReportedByUserId:number,resolutionETA:number,incidentSummary:string,investigatedByUserId:number) {
    
            this.incidentID = incidentID;
    
            this.incidentType = incidentType;
    
            this.description = description;
    
            this.status = status;
    
            this.incidentDate = incidentDate;
    
            this.incidentDetails = incidentDetails;
    
            this.reportDate = reportDate;
    
            this.bookingId = bookingId;
    
            this.incidentReportedByUserId = incidentReportedByUserId;
    
            this.resolutionETA = resolutionETA;
    
            this.investigatedByUserId = investigatedByUserId;
    
            this.incidentSummary = incidentSummary
    
        }
    
      }