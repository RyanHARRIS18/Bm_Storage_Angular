import { ContractFile } from './contract';
import { UnitType } from './unitType';

export class Unit {
    constructor (
       public unitID : number,
       public unitNumber : number,
       public unitDescription : string,
       public unitLocation : string,
       public contractFiles: ContractFile[],
       public unitType: UnitType
    ){}
  
}