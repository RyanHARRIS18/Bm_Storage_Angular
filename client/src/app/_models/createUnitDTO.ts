export class CreateUnitDTO {
    constructor (
       public UnitID : string,
       public UnitNumber : string,
       public UnitLocation : string,
       public UnitTypeName: string,
       public UnitDescription : string
    ){}
  
}